using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CresceVendas.Enum
{
    public class PaymentSplits
    {
        public const int A_VISTA = 1;
        public const int OUTROS = 2; // Quantidade de formas de pagamento, caso o usuário tenha utilizado mais de uma. Pode ser cartões diferentes ou mesmo uma parte em dinheiro e outra em cheque (ou qualquer combinação). Deve ser um inteiro entre 1 e 9     
    }
}
