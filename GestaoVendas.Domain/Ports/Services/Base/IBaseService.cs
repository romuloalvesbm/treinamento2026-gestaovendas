using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Ports.Services.Base
{
    public interface IBaseService<TIn, TOut>
    where TIn : class
    where TOut : class
    {
        Task<TOut> CriarAsync(TIn input);
        Task<TOut> AtualizarAsync(int id, TIn input);
        Task<TOut> InativarAsync(int id);
        Task<TOut?> ObterPorIdAsync(int id);
        Task<List<TOut>> ConsultarAsync(int pagina, int tamanho);
    }
}
