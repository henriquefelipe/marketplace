using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class resgate
    {
        public bool success {  get; set; }
        public string message { get; set; }
        public resgate_data data { get; set; }
    }

    public class resgate_data
    {
        public int id_cliente { get; set; }
        public int id_premio { get; set; }
        public string date_validade { get; set; }
        public string date_retirada { get; set; }
        public int id_parceiro_origem_retirada { get; set; }
        public string date_ganhou { get; set; }
        public int? id_parceiro_origem { get; set; }
        public string client_check_id { get; set; }
        public int id_premio_cliente { get; set; }
        public int id_ponto_gasto { get; set; }
        public bool esta_vencido { get; set; }
        public bool foi_resgatado { get; set; }
        public resgate_data_premio premio { get; set; }
        public resgate_ponto_gasto ponto_gasto { get; set; }

        public string motivo_estorno { get; set; }
        public string estornada_em { get; set; }
    }

    public class resgate_data_premio
    {
        public int id_premio { get; set; }
        public string nome { get; set; }
        public string tipo_beneficio { get; set; }
        public decimal valor_beneficio { get; set; }
    }

    public class resgate_ponto_gasto
    {
        public int ponto_gasto_id { get; set; }
        public int qtd_ponto_gasto { get; set; }
        public string date_ponto_gasto { get; set; }
        public int id_parceiro_origem { get; set; }
    }
}
