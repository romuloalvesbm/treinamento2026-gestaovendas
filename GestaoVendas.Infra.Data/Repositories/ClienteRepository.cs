using GestaoVendas.Domain.Entitieis;
using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Infra.Data.Repositories
{
    public class ClienteRepository(DataContext dataContext) : BaseRepository<Cliente, int>(dataContext), IClienteRepository
    {

    }
}
