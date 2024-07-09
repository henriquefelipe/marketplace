using System;
using System.Collections.Generic;
using System.Text;

namespace Fidelizi.Domain
{
    public class configuracao
    {
        public configuracao()
        {
            premios_fidelidade = new List<configuracao_premios_fidelidade>();
        }

        public string label {  get; set; }
        public int validade { get; set; }
        public string descricao { get; set; }
        public string chamada { get; set; }
        public string observacao { get; set; }
        public string id_parceiro { get; set; }
        public string carencia_ponto { get; set; }
        public configuracao_conversao_dinheiro conversao_dinheiro { get; set; }
        public configuracao_travas_seguranca travas_seguranca { get; set; }
        public configuracao_atendentes atendentes { get; set; }
        public List<configuracao_premios_fidelidade> premios_fidelidade { get; set; }
    }

    public class configuracao_conversao_dinheiro
    {
        public int ativo { get; set; }
        public int pontos { get; set; }
        public decimal valor { get; set; }
    }

    public class configuracao_travas_seguranca
    {
        public int interacoes_dia { get; set; }
        public int intervalo_interacoes { get; set; }
        public int minimo_pontos_interacao { get; set; }
        public int maximo_pontos_interacao { get; set; }
    }

    public class configuracao_atendentes
    {
        public int solicitar_senha_pontuar { get; set; }
        public int solicitar_senha_resgate { get; set; }
    }

    public class configuracao_premios_fidelidade
    {
        public int id_premio { get; set; }
        public int id_parceiro { get; set; }
        public string nome { get; set; }
        public decimal preco_odometro { get; set; }
        public string resgate_mesmo_dia { get; set; }
        public string tipo_beneficio { get; set; }
        public decimal? valor_beneficio { get; set; }
        public string identificador {  get; set; }
    }
}
