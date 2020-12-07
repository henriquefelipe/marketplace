using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Enum
{
    public class PaymentType
    {
        public const string DINHEIRO = "cash";
        public const string RAPPI_PAY = "rappi_pay";
        public const string CARTAO_CREDITO = "cc";
        public const string CARTAO_DEBITO = "dc";
        public const string GOOGLE_PAY = "google_pay";
        public const string APPLE_PAY = "apple_pay";
    }
}
