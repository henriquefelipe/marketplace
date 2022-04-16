using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Enum
{
    public class order_state
    {
        public const string AGUARDANDO_ACEITE = "AGUARDANDO_ACEITE";
        public const string EM_PREPARO = "EM_PREPARO";
        public const string SAIU_ENTREGA = "SAIU_ENTREGA";
        public const string PRONTO_AGUARDANDO_RETIRADA = "PRONTO_AGUARDANDO_RETIRADA";
        public const string RETIRADO_BALCAO = "RETIRADO_BALCAO";
        public const string CANCELADO = "CANCELADO";
        public const string RECUSADO = "RECUSADO ";
    }
}
