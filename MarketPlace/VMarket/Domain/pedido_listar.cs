using System;
using System.Collections.Generic;
using System.Text;

namespace VMarket.Domain
{
    public class pedido_listar
    {
        public int id_pedido { get; set; }
        public int id_pedido_colecao { get; set; }
        //"id_pedido_erp": null,
        public int id_fornecedor { get; set; }
        public int id_pedido_status { get; set; }
        public int fl_aguardar_aprovacao { get; set; }
        //"id_precotacao": null,
        public decimal frete { get; set; }
        public decimal acrescimo { get; set; }
        public decimal decrescimo { get; set; }
        public string comentario { get; set; }
        //"comentario_avaliacao": null,
        //"avaliacao": null,
        public string cod_erp { get; set; }
        public string id_cotacao_sisfood { get; set; }
        public DateTime dt_inclusao { get; set; }
        public DateTime? dt_entrega { get; set; }
        public DateTime dt_edicao { get; set; }
        public string origem { get; set; }
        //"id_entrega": null,
        public string token { get; set; }
        public string url_relatorio { get; set; }
        public string url_nfe { get; set; }
        public string obs_relatorio { get; set; }
        public decimal total_nfe { get; set; }
        public int fl_editado { get; set; }
        //"almoxarifado_erp": null,
        public string observacao { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
        public string cnpj { get; set; }
        public int id_fornecedor_filial { get; set; }
        //"id_fornecedor_matriz": null

        public List<pedido_item_retorno> itens {  get; set; }
    }
}
