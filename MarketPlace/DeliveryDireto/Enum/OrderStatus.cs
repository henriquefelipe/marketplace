using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Enum
{
    public class OrderStatus
    {
        public const string WAITING = "WAITING"; // ESPERANDO
        public const string APPROVED = "APPROVED"; // APROVADO
        public const string DONE = "DONE"; // FINALIZADO
        public const string REJECTED = "REJECTED"; // REJEITADO
        public const string HIDDEN = "HIDDEN"; // APAGADO
        public const string IN_TRANSIT = "IN_TRANSIT"; // EM TRÂNSITO
        public const string WARNING = "WARNING"; // ERRO NO PAGAMENTO ONLINE
    }
}
