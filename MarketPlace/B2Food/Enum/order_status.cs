using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Food.Enum
{
    public class order_status
    {
        public const byte PENDENTE = 1;
        public const byte ACEITO = 2;
        public const byte CONCLUIDO = 3;
        public const byte REJEITADO = 4;
        public const byte PERDIDO = 5;
        public const byte CANCELADO = 6;
        public const byte SOLICITACAO_DE_CANCELAMENTO = 7;
        public const byte EM_ROTA_ENTREGA = 8;
        public const byte AGUARDANDO_RETIRADA = 9;
    }
}
