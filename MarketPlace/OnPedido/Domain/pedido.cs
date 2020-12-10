namespace OnPedido.Domain
{
    public class pedido
    {
        public pedido_info info { get; set; }
        public pedido_cliente cliente { get; set; }
       
        public pedido_produto produtos { get; set; }
        public pedido_valor valor { get; set; }
    }
}
