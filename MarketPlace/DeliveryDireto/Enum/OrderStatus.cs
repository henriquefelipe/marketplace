using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Enum
{
    public class OrderStatus
    {
        public const string EM_ESPERA = "00";
        public const string ACEITO = "01";
        public const string EM_TRANSITO = "02";
        public const string ENTREGUE = "03";
        public const string RETIRADO = "04";
        public const string RECUSADO = "05";
        public const string OCULTO = "06";
        public const string ATENCAO = "07";
        public const string CANCELADO = "08";
    }
}
