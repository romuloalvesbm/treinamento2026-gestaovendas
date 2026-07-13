using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GestaoVendas.API.Helpers
{
    /// <summary>
    /// ⚠️ AVISO: Modelo Legado de Autorização
    /// Esta implementação customizada de autorização está obsoleta.
    /// 
    /// RECOMENDAÇÃO: Use o modelo nativo do ASP.NET Core com AddPolicy e [Authorize(Policy = "...")].
    /// 
    /// Motivos para migração:
    /// - Padrão oficial do .NET
    /// - Melhor testabilidade e manutenibilidade
    /// - Suporte a cenários complexos (múltiplas claims, roles, requirements)
    /// - Melhor integração com Swagger/OpenAPI
    /// - Centralização das políticas de autorização
    /// 
    /// As policies já estão configuradas em JwtBearerExtension.cs
    /// </summary>
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {

            return context.User.Identity != null && context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value == claimValue);

        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
