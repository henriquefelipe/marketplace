﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logaroo.Enum
{
    public static class PaymentCode
    {     
        public const string Dinheiro = "1";
        public const string CartaoDeCreditoPagamentoNaEntrega = "2";
        public const string CartaoDeDebitoPagamentoNaEntrega = "3";
        public const string PagamentoOnline = "4";
        public const string CartaoDeCreditoPagamentoOnline = "5";
        public const string CartaoDeDebitoPagamentoOnline = "6";
        public const string VoucherLojista = "7";
        public const string VoucherRestaurante = "8";
        public const string LogarooCartaoCredito = "9";
        public const string LogarooCartaoDebito = "10";
        public const string MercadoPago = "11";
        public const string PayPal = "12";
        public const string PicPay = "13";
        public const string Pix = "14";
    }
}
