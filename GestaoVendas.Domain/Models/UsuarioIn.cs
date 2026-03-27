using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Models
{
    public class UsuarioIn
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
