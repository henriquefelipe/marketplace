namespace OnPedido.Domain
{
    public class pedido_cliente_endereco
    {
        public string cep { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string complemento { get; set; }
        public string referencia { get; set; }
        public string uf { get; set; }
        public string formatado { get; set; }
    }
}
