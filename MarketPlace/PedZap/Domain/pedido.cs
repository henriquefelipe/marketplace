using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedZap.Domain
{
    public class pedido
    {
        public pedido()
        {
            pedido_Items = new List<pedido_item>();
        }

        public int ped_id { get; set; }
        public string ped_tipo { get; set; }
        public int? ped_referencia { get; set; }
        public string ped_hash { get; set; }
        public string ped_origem { get; set; }
        public int? ped_cep { get; set; }
        public string ped_endereco { get; set; }
        public string ped_numero { get; set; }
        public string ped_complemento { get; set; }
        public string ped_bairro { get; set; }
        public string ped_cidade { get; set; }
        public string ped_estado { get; set; }
        public string ped_pontoreferencia { get; set; }
        public int ped_tempo { get; set; }
        public string ped_formapagamento { get; set; }
        public decimal? ped_trocopara { get; set; }
        public decimal? ped_custoentrega { get; set; }
        public decimal? ped_kilometragem { get; set; }
        public string ped_observacoes { get; set; }
        public int ped_breakpoint { get; set; }
        public bool ped_agendamento { get; set; }
        public string ped_status { get; set; }
        public string ped_datacadastral { get; set; }
        public string ped_datapreparo { get; set; }
        public string ped_dataentrega { get; set; }
        public int ped_errosprocesso { get; set; }
        public bool ped_cupomfiscal { get; set; }
        public string ped_cupomfiscal_nome_razao { get; set; }
        public string ped_cupomfiscal_cpf_cnpj { get; set; }
        public int cli_id { get; set; }
        public string cli_nome { get; set; }
        public string cli_telefone { get; set; }
        public string cli_datacadastral { get; set; }
        public int? ent_id { get; set; }
        public bool pedidos_itens { get; set; }
        public decimal ped_desconto { get; set; }
        public string ped_desconto_cupom { get; set; }

        public List<pedido_item> pedido_Items { get; set; }
    }
}
