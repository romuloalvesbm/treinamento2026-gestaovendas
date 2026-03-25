using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GestaoVendas.API.Extensions
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Title = $"Gestao Vendas App {description.ApiVersion}", 
                    Version = description.ApiVersion.ToString(),
                    Description = "API Description.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rômulo Alves",
                        Email = "romuloalves.br@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/rômulo-alves-a4144113b/")
                    }
                };

                if (description.IsDeprecated)
                {
                    info.Description += " Esta versão está descontinuada.";
                }

                options.SwaggerDoc(description.GroupName, info);
            }

            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme."
            });
            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("bearer", document)] = []
            });
        }
    }
}
