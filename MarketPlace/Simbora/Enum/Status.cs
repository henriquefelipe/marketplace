using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Enum
{
    public class Status
    {
        public const string ROUTELESS = "ROUTELESS"; // (Indica que o pedido está sem uma rota, pedidos novos recebem esse status
        public const string WAITING_ROUTE = "WAITING_ROUTE"; // (Indica que o pedido foi enviado ao roteirizador está aguardando a rota ser gerada
        public const string ROUTED = "ROUTED"; // (Indica que o pedido foi roteirizado e pertence a uma rota
        public const string ONSEARCHING = "ONSEARCHING"; // (Indica que o pedido está sendo alocado a um entregador)
        public const string FAILED_SEARCH = "FAILED_SEARCH"; // (Indica que não foi possível alocar um entregador ao pedido usualmente ocorre devido a falta de entregadores disponíveis
        public const string ONGOING = "ONGOING";//(Indica que o entregador está a caminho de coletar o pedido
        public const string ONROUTE = "ONROUTE"; // (Indica que o entregador coletou o pedido e está a caminho)
        public const string GOINGBACK = "GOINGBACK"; // Indica que o entregador deve retornar ao estabelecimento para finalizar o pedido
        public const string DELIVERED = "DELIVERED"; // (Indica que o entregador finalizou a entrega
        public const string CANCELED = "CANCELED"; //(Indica que o pedido foi cancelado pelo estabelecimento


    }
}
