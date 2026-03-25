using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi;

namespace GestaoVendas.API.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
               
                options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
          
            services.AddSwaggerGen();
            
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();

            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions.OrderByDescending(x => x.ApiVersion))
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                            $"Gestao Vendas App {description.ApiVersion}");
                }
            });

            return app;
        }
    }
}
