using FluentValidation;
using GestaoVendas.API.Common;
using GestaoVendas.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace GestaoVendas.API.Middlewares
{
    public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
        {
            context.Response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            string message = "Erro interno no servidor";
            IEnumerable<string>? errors = null;

            switch (ex)
            {
                case ClienteNaoEncontradoException:
                case PedidoNaoEncontradoException:
                    statusCode = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case CpfJaCadastradoException:
                case EmailJaCadastradoException:
                    statusCode = HttpStatusCode.Conflict;
                    message = ex.Message;
                    break;

                case ValidationException validationEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Erro de validação";
                    errors = validationEx.Errors.Select(e => e.ErrorMessage);
                    break;

                default:
                    errors = ["Ocorreu um erro interno no servidor."];                    
                    logger.LogError(ex, "Erro inesperado: {Message}", ex.Message);
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = ApiResponse<object>.Fail(message, errors);

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
