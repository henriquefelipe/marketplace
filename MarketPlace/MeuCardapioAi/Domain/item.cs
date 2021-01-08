namespace MeuCardapioAi.Domain
{
    public class item
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string codigoPDV { get; set; }
        public decimal qtde { get; set; }
        public decimal valor { get; set; }
        public decimal total { get; set; }
        public item_produto produto { get; set; }
        public string unidade { get; set; }
        public string observacao { get; set; }
        public adicionais adicionais { get; set; }
    }
}
