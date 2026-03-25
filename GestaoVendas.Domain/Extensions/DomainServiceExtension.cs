using GestaoVendas.Domain.Ports.Services;
using GestaoVendas.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoVendas.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)

        {
            services.AddTransient<IClienteService, ClienteService>();
            //services.AddTransient<IPedidoService, PedidoService>();
            return services;
        }
    }
}
