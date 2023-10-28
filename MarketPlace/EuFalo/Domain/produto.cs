using System;
using System.Collections.Generic;
using System.Text;

namespace EuFalo.Domain
{
    public class produto
    {
        public string produtoCI { get; set; }
        public string ean { get; set; }
        public string nomeProduto { get; set; }
        public string descricao { get; set; }
        public string link { get; set; }
        public string linkImagem { get; set; }
        public decimal preco { get; set; }
        public decimal precoPromocional { get; set; }
        public int estoque { get; set; }
        public bool ativo { get; set; }
        public string fabricanteCI { get; set; }
        public string categoriaProdutoCI { get; set; }
        public string produtoUnidadeMedida { get; set; }
        public int unidadeMedida { get; set; }
    }
}
