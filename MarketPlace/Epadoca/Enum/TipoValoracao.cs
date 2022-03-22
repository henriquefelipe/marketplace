using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epadoca.Enum
{
    public enum TipoValoracao
    {
        [Description("Não Informado")]
        NaoInformado = 0,

        [Description("Gramas (gr)")]
        Grama = 1,

        [Description("Quilo (kg)")]
        Quilo = 2,

        [Description("Litro (l)")]
        Litro = 3,

        [Description("Unidade (un)")]
        Unidade = 4
    }
}
