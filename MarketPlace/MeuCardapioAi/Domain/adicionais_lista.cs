using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Domain
{
    public class adicionais_lista
    {
        public adicionais_lista()
        {
            opcoes = new List<adicionais_lista_opcao>();
        }

        public decimal valorTotal { get; set; }
        public string tipoDeCobranca { get; set; }
        public List<adicionais_lista_opcao> opcoes { get; set; }
    }

    public class adicionais_lista_opcao
    {
        public string nome { get; set; }
        public decimal valor { get; set; }
        public string codigoPdv { get; set;}
        public int qtde { get; set; }
        public decimal valorTotal { get; set; }
    }
}
