using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Enum
{
    public enum CancelamentCode
    {
        [Description("Pedido em duplicidade")]
        Pedido_em_duplicidade = 502,

        [Description("Item indisponível")]
        Item_indisponível = 503,

        [Description("")]
        Restaurante_sem_motoboy = 504,

        [Description("Cardápio desatualizado")]
        Cardápio_desatualizado = 505,

        [Description("Pedido fora da área de entrega")]
        Pedido_fora_da_area_de_entrega = 506,

        [Description("Trote")]
        Trote = 507,

        [Description("Fora do horário do delivery")]
        Fora_do_horario_do_delivery = 508,

        [Description("Dificuldades do restaurante")]
        Dificuldades_do_restaurante = 509,

        [Description("Área de risco")]
        Area_de_risco = 511,

        [Description("Restaurante abrirá mais tarde")]
        Restaurante_abrira_mais_tarde = 512,

        [Description("Restaurante fechou mais cedo")]
        Restaurante_fechou_mais_cedo = 513,

        [Description("Outro (descrição obrigatória)")]
        Outro_descricao_obrigatoria = 801,

        [Description("Menu não disponível")]
        Menu_nao_disponivel = 803,

        //[Description("Restaurante sem motoboy")]
        //Restaurante_sem_motoboy = 805,

        [Description("Cliente final solicitou o cancelamento do pedido")]
        Cliente_final_solicitou_o_cancelamento_do_pedido = 817
    }
}
