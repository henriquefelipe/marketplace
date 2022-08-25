using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Domain
{
    public class retorno_bonus_disponivel
    {
        public retorno_bonus_disponivel()
        {
            historico = new List<retorno_bonus_disponivel_historico>();
        }

        public bool tem_bonus { get; set; }
        public decimal saldo_bonus { get; set; }
        public string produtos { get; set; }
        public string ids_bonus { get; set; }
        public bool restricao_horario { get; set; }
        public bool flag_acumular_bonus { get; set; }
        public string question_acumular_bonus { get; set; }
        public bool is_multi_resgate { get; set; }
        public string primeira_data_valida { get; set; }
        public string msg_venda_prime { get; set; }
        public string msg_venda_prime_obrigado { get; set; }
        public List<retorno_bonus_disponivel_historico> historico { get; set; }

        public string msg { get; set; }
    }

    public class retorno_bonus_disponivel_historico
    {
        public string validade_inicio { get; set; }
        public string validade_fim { get; set; }
        public decimal valor { get; set; }
    }
}
