using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GestaoVendas.Domain.Validators.Common
{
    public static class EmailValidator
    {
        public static bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }
    }
}
