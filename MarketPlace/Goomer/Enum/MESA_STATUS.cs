using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Enum
{
    public class MESA_STATUS
    {
        public const string AVAILABLE = "AVAILABLE"; // Disponível: Não está em uso. Aceita lançar pedidos
        public const string CONSUMING = "CONSUMING"; //Consumindo: Em uso. Aceita lançar pedidos
        public const string IN_PAYMENT = "IN_PAYMENT"; //Em pagamento: Não aceita lançar pedidos
        public const string CLOSED = "CLOSED"; //Fechada:  Um novo pedido abre uma nova conta.  Os campos obrigatórios de total, subtotal, service e discount, podem ser preenchidos com 0,00. Já o campo products pode ser enviado como um array vazio
        public const string CANCELED = "CANCELED";  //Cancelada: Pedido cancelado. Os campos obrigatórios podem ser enviados da mesma maneira que no CLOSED
    }
}
