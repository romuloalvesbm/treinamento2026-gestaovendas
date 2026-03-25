using GestaoVendas.API.Helpers;
using GestaoVendas.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestaoVendas.API.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Configurações para validar o token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true, // Valida a expiração do token
                    ValidateIssuerSigningKey = true, // Valida a chave de assinatura do token
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            configuration.GetValue<string>("JwtTokenSettings:SecretKey")!
                        )
                    )
                };
            });

            services.AddSingleton<JwtTokenHelper>();
            services.Configure<JwtTokenSettings>(configuration.GetSection("JwtTokenSettings"));            

            return services;
        }
    }
}
