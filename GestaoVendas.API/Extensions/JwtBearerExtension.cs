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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Cliente.GetAll", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.GetAll"));

                options.AddPolicy("Cliente.GetbyId", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.GetbyId"));

                options.AddPolicy("Cliente.Create", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.Create"));

                options.AddPolicy("Cliente.Update", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.Update"));

                options.AddPolicy("Cliente.Inactive", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.Inactive"));

                options.AddPolicy("Cliente.GetAll2", policy =>
                    policy.RequireClaim("CustomizePermission", "Cliente.GetAll2"));
            });

            services.Configure<JwtTokenSettings>(configuration.GetSection("JwtTokenSettings"));
            services.AddSingleton<JwtTokenHelper>();

            return services;
        }
    }
}
