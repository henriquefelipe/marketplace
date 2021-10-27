using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Domain
{
    public class store
    {
        public string guid { get; set; }
        public bool isOnline { get; set; }
        public string nomeFantasia { get; set; }
        public long tempoMedioEntregaTicks { get; set; }
        public bool isReceberEncomenda { get; set; }
        public bool isReceberPedidoAgendado { get; set; }
        public bool isReceberPedido { get; set; }
        public bool isReceberPedidoMesa { get; set; }
        public bool isServicoLogistica { get; set; }
        public bool isPedidoMesaDesabilitarPainelPedidos { get; set; }        
    }
}
