namespace OnPedido.Domain
{
    public interface IItem
    {
        string DescricaoItem { get; }

        string QuantidadeItem { get; }

        string ValorItem { get; }
    }
}
