namespace MeuCardapioAi.Domain
{
    public class adicionais_campo
    {
        public string nome { get; set; }
        public decimal valor { get; set; }
        public bool disponivel { get; set; }
        public string descricao { get; set; }
        public int id { get; set; }
        public string template { get; set; }
        public string linkImagem { get; set; }
        public string codigoPdv { get; set; }
        public adicionais_campo_adicional adicional { get; set; }
    }
}
