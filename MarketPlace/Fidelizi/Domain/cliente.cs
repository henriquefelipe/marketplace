using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class cliente
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string codigo_indicador { get; set; }
        public string origem_cadastro { get; set; }
        public int pontos_conquistados_total { get; set; }
        public cliente_cartela_atual cartela_atual { get; set; }
        public cliente_frequencia frequencia { get; set; }
        public cliente_avaliacoes avaliacoes { get; set; }
        public cliente_gastos gastos { get; set; }
        public List<cliente__premios_conquistados> premios_conquistados { get; set; }

    }

    public class cliente_cartela_atual
    {
        public int id_cartela_cliente { get; set; }
        public int id_cliente { get; set; }
        public int id_parceiro_origem { get; set; }
        public string proxima_validade_data { get; set; }
        public int proxima_validade_pontos { get; set; }
        //"vencimentos": [],
        public int saldo { get; set; }
        public int saldo_carencia { get; set; }
    }

    public class cliente_frequencia
    {
        public decimal frequencia_mes_atual { get; set; }
        public decimal frequencia_mes_passado { get; set; }
        public int visitas_mes_atual { get; set; }
        public int visitas_mes_passado { get; set; }
    }

    public class cliente_avaliacoes
    {
        public int media { get; set; }
        //"todos": []
    }

    public class cliente_gastos
    {
        public decimal total { get; set; }
        public decimal ticket_medio_desde_inicio { get; set; }
        public decimal ticket_medio_mes_atual { get; set; }
        public decimal ticket_medio_mes_passado { get; set; }
    }

    public class cliente__premios_conquistados
    {
        public int id_premio_cliente { get; set; }
        public int id_premio { get; set; }
        public int id_cliente { get; set; }
        public string date_validade { get; set; }
        public string date_retirada { get; set; }
        public string date_ganhou { get; set; }
        public string estornada_em { get; set; }
        public string motivo_estorno { get; set; }
        public bool esta_vencido { get; set; }
        public bool foi_resgatado { get; set; }
        public cliente__premios_conquistados_premio premio { get; set; }
    }

    public class cliente__premios_conquistados_premio
    {
        public int id_premio { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string tipo_beneficio { get; set; }
        public decimal valor_beneficio { get; set; }
    }

}
