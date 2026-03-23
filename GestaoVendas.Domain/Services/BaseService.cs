using GestaoVendas.Domain.Ports.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Services
{
    public abstract class BaseService<TIn, TOut> : IBaseService<TIn, TOut>
    where TIn : class
    where TOut : class
    {
        public virtual Task<TOut> CriarAsync(TIn input)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TOut> AtualizarAsync(int id, TIn input)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TOut> InativarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TOut?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<TOut>> ConsultarAsync(int pagina, int tamanho)
        {
            throw new NotImplementedException();
        }        
    }
}
