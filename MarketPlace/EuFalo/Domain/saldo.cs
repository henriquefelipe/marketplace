using System;
using System.Collections.Generic;
using System.Text;

namespace EuFalo.Domain
{
    public class saldo
    {
        public saldo()
        {
            success = new List<saldo_detalhe>();
            errors = new List<saldo_detalhe>();
        }

        public List<saldo_detalhe> success { get; set; }
        public List<saldo_detalhe> errors { get; set; }
    }

    public class saldo_detalhe
    {
        public string cpf;
        public decimal saldo;
    }
}
