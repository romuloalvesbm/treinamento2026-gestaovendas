using GestaoVendas.Domain.Entities;
using GestaoVendas.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Cliente, ClienteOut>
               .NewConfig().TwoWays();

            TypeAdapterConfig<ClienteIn, Cliente>
              .NewConfig()
              .MapWith(src => Cliente.Create(
                  src.Nome,
                  src.Email,
                  src.Cpf
                  ));

            TypeAdapterConfig<PedidoIn, Pedido>
              .NewConfig().TwoWays();
        }
    }
}
