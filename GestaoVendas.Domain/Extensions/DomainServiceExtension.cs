using FluentValidation;
using GestaoVendas.Domain.Mappings;
using GestaoVendas.Domain.Ports.Services;
using GestaoVendas.Domain.Services;
using GestaoVendas.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoVendas.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)

        {
            services.AddValidatorsFromAssembly(typeof(UsuarioValidator).Assembly);

            MapsterConfig.RegisterMappings();

            services.AddTransient<IClienteService, ClienteService>();
            //services.AddTransient<IPedidoService, PedidoService>();
            return services;
        }
    }
}
