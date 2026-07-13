using FluentValidation.AspNetCore;
using GestaoVendas.API.Common;
using GestaoVendas.API.Extensions;
using GestaoVendas.API.Middlewares;
using GestaoVendas.Domain.Extensions;
using GestaoVendas.Infra.Data.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddRouting(map => map.LowercaseUrls = true);

builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainService();
builder.Services.AddAuthorization();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var erros = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var response = ApiResponse<string>.Fail("Erro de validação", erros);

        return new BadRequestObjectResult(response);
    };
});
builder.Services.AddControllers();

// Ativa a validação automática e os adaptadores client-side
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

//Configuração para geração dos LOGS
builder.Logging.ClearProviders(); 
builder.Host.UseSerilog((context, config) =>
{
    config
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext();
});

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerDoc();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
