using AnotaAi.Service;
using Cinddi.Service;
using DeliveryApp.Service;
using GloriaFood.Service;
using Logaroo.Enum;
using MeuCardapioAi.Service;
using Newtonsoft.Json;
using OnPedido.Domain;
using OnPedido.Service;
using PedZap.Enum;
using PedZap.Service;
using Rappi.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        #region Variaveis

        private string _anotaAiSelected { get; set; }
        private string _anotaAiToken { get; set; }
        private List<AnotaAi.Domain.order> _anotaAiOrders { get; set; }
        private string _deliveryAppToken { get; set; }
        private List<DeliveryApp.Domain.order> _deliveryAppOrders { get; set; }
        private string _ifoodToken { get; set; }
        private List<Ifood.Domain.order> _ifoodOrders { get; set; }
        private string _ifoodReferenceSelected { get; set; }
        private string _gloriaToken { get; set; }
        private List<GloriaFood.Domain.order> _gloriaOrders { get; set; }
        private string _meuCardapioAiToken { get; set; }
        private string _meuCardapioAiSelected { get; set; }
        private string _meuCardapioAiUltimoPedido { get; set; }
        private List<MeuCardapioAi.Domain.order> _meuCardapioAiOrders { get; set; }
        private string _superMenuToken { get; set; }
        private List<SuperMenu.Domain.order> _superMenuOrders { get; set; }
        private string _superMenuReferenceSelected { get; set; }

        private string _pedzap { get; set; }
        private List<PedZap.Domain.pedido> _pedzapPedidos { get; set; }
        private int _pedzapReferenceSelected { get; set; }

        private string _rappiToken { get; set; }
        private string _rappiSelected { get; set; }
        private List<Rappi.Domain.order_detail> _rappiOrders { get; set; }

        private string _onPedidoToken { get; set; }
        private List<Id> _onPedidoPedidos { get; set; }
        private string _onPedidoSelected { get; set; }

        private string _cinddiToken { get; set; }
        private List<Cinddi.Domain.ResponseOrders> _cinddiPedidos { get; set; }
        private string _cinddiSelected { get; set; }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\MarketPlace.json"))
            {
                //Verifica se existe o arquivo de configuração
                using (StreamReader sr = new StreamReader(@"C:\MarketPlace.json"))
                {
                    string fileJson = sr.ReadToEnd();
                    if (!string.IsNullOrEmpty(fileJson))
                    {
                        var marketPlace = JsonConvert.DeserializeObject<MarketPlaceConfig>(fileJson);
                        if (marketPlace != null)
                        {
                            if (marketPlace.AnotaAi != null)
                            {
                                txtAnotaAiToken.Text = marketPlace.AnotaAi.Token;
                            }

                            if (marketPlace.Cinddi != null)
                            {
                                txtCinddiToken.Text = marketPlace.Cinddi.Token;
                            }

                            if (marketPlace.DeliveryApp != null)
                            {
                                txtDeliveryAppToken.Text = marketPlace.DeliveryApp.Token;
                            }

                            if (marketPlace.Ifood != null)
                            {
                                txtIfoodClient_ID.Text = marketPlace.Ifood.Client_ID;
                                txtIfoodClient_Secret.Text = marketPlace.Ifood.Client_SECRET;
                                txtIfoodMerchantId.Text = marketPlace.Ifood.MerchantId;
                                txtIfoodUsuario.Text = marketPlace.Ifood.Usuario;
                                txtIfoodSenha.Text = marketPlace.Ifood.Senha;
                            }

                            if (marketPlace.Gloria != null)
                            {
                                txtGloriaFoodToken.Text = marketPlace.Gloria.Token;
                            }

                            if (marketPlace.MeuCardapioAi != null)
                            {
                                txtMeuCardapioAiClient_ID.Text = marketPlace.MeuCardapioAi.Client_ID;
                                txtMeuCardapioAiClient_SECRET.Text = marketPlace.MeuCardapioAi.Client_SECRET;
                                txtMeuCardapioAiURL.Text = marketPlace.MeuCardapioAi.Url;
                            }

                            if (marketPlace.Logaroo != null)
                            {
                                txtLogarooMerchantId.Text = marketPlace.Logaroo.MerchantId;
                                txtLogarooEmail.Text = marketPlace.Logaroo.Usuario;
                                txtLogarooSenha.Text = marketPlace.Logaroo.Senha;
                            }

                            if (marketPlace.OnPedido != null)
                            {
                                txtOnPedidoToken.Text = marketPlace.OnPedido.Token;
                            }

                            if (marketPlace.Rappi != null)
                            {
                                txtRappiClientID.Text = marketPlace.Rappi.Client_ID;
                                txtRappiSECRET.Text = marketPlace.Rappi.Client_SECRET;
                                txtRappiURL.Text = marketPlace.Rappi.Url;
                            }

                            if (marketPlace.SuperMenu != null)
                            {
                                txtSuperMenuToken.Text = marketPlace.SuperMenu.Token;
                            }
                        }
                    }
                }
            }

            _anotaAiOrders = new List<AnotaAi.Domain.order>();
            gridAnotaAi.DataSource = _anotaAiOrders.ToList();
            gridAnotaAi.Refresh();

            _deliveryAppOrders = new List<DeliveryApp.Domain.order>();
            gridDeliveryApp.DataSource = _deliveryAppOrders.ToList();
            gridDeliveryApp.Refresh();

            _ifoodOrders = new List<Ifood.Domain.order>();
            gridIfood.DataSource = _ifoodOrders.ToList();
            gridIfood.Refresh();

            _gloriaOrders = new List<GloriaFood.Domain.order>();
            gridGloriaGood.DataSource = _gloriaOrders.ToList();
            gridGloriaGood.Refresh();

            _meuCardapioAiOrders = new List<MeuCardapioAi.Domain.order>();
            gridMeuCardapioAi.DataSource = _meuCardapioAiOrders.ToList();
            gridMeuCardapioAi.Refresh();

            _rappiOrders = new List<Rappi.Domain.order_detail>();
            gridRappi.DataSource = _rappiOrders.ToList();
            gridRappi.Refresh();

            _superMenuOrders = new List<SuperMenu.Domain.order>();
            gridSuperMenu.DataSource = _superMenuOrders.ToList();
            gridSuperMenu.Refresh();

            _pedzapPedidos = new List<PedZap.Domain.pedido>();

            _onPedidoPedidos = new List<Id>();
            gridOnPedido.DataSource = _onPedidoPedidos.ToList();
            gridOnPedido.Refresh();
        }

        #region Ifood
        private void btnIfoodIniciar_Click(object sender, EventArgs e)
        {
            IfoodIniciar();
        }

        public async void IfoodIniciar()
        {
            if (string.IsNullOrEmpty(txtIfoodClient_ID.Text))
            {
                MessageBox.Show("Campo Client_ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIfoodClient_Secret.Text))
            {
                MessageBox.Show("Campo Client_Secret Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIfoodMerchantId.Text))
            {
                MessageBox.Show("Campo MerchantId Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIfoodUsuario.Text))
            {
                MessageBox.Show("Campo Usuario Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIfoodSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            txtIfoodClient_ID.Enabled = false;
            txtIfoodClient_Secret.Enabled = false;
            txtIfoodMerchantId.Enabled = false;
            txtIfoodUsuario.Enabled = false;
            txtIfoodSenha.Enabled = false;

            btnIfoodIniciar.Enabled = false;
            btnIfoodParar.Enabled = true;

            await Task.Run(() => ifood());
        }

        private void ifood()
        {
            var ifoodService = new Ifood.Service.IfoodService();

            try
            {
                var eventTentatives = 0;

                while (btnIfoodParar.Enabled)
                {
                    if (eventTentatives == 0)
                    {
                        var oathTokenResult = ifoodService.OathToken(txtIfoodClient_ID.Text, txtIfoodClient_Secret.Text, txtIfoodUsuario.Text, txtIfoodSenha.Text);
                        if (oathTokenResult.Success)
                        {
                            _ifoodToken = oathTokenResult.Result.access_token;
                        }
                        else
                        {
                            MessageBox.Show(oathTokenResult.Message);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(_ifoodToken))
                    {
                        var eventPollingResult = ifoodService.EventPolling(_ifoodToken);

                        if (eventPollingResult.Success)
                        {
                            var eventsIds = new List<Ifood.Domain.eventAcknowledgment>();

                            foreach (var poolingEvent in eventPollingResult.Result)
                            {
                                if (poolingEvent.code == Ifood.Domain.PoolingEventStatusCode.PLACED)
                                {
                                    var orderResult = ifoodService.Orders(_ifoodToken, poolingEvent.correlationId);
                                    if (orderResult.Success)
                                    {
                                        var order = _ifoodOrders.FirstOrDefault(f => f.id == orderResult.Result.id);
                                        if (order == null)
                                        {
                                            _ifoodOrders.Add(orderResult.Result);
                                        }

                                        WriteGridIfood();
                                    }
                                    else
                                    {
                                        MessageBox.Show(orderResult.Message);
                                        return;
                                    }
                                }

                                eventsIds.Add(new Ifood.Domain.eventAcknowledgment { id = poolingEvent.id });
                            }

                            var eventAcknowledgmentResult = ifoodService.EventAcknowledgment(_ifoodToken, eventsIds);
                            if (!eventAcknowledgmentResult.Success)
                            {
                                MessageBox.Show(eventAcknowledgmentResult.Message);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(eventPollingResult.Message);
                            return;
                        }
                    }

                    // O ifood solicita que a requisição do event pooling seja feito a cada 30 segundos
                    Thread.Sleep(30000);

                    eventTentatives++;

                    //A cada uma hora eu faço ser chamado de novo o oath para pegar o novo token
                    if (eventTentatives >= 119)
                    {
                        eventTentatives = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private void btnIfoodParar_Click(object sender, EventArgs e)
        {
            ifoodParar();
        }

        void ifoodParar()
        {
            txtIfoodClient_ID.Enabled = true;
            txtIfoodClient_Secret.Enabled = true;
            txtIfoodMerchantId.Enabled = true;
            txtIfoodUsuario.Enabled = true;
            txtIfoodSenha.Enabled = true;

            btnIfoodIniciar.Enabled = true;
            btnIfoodParar.Enabled = false;
        }

        private void btnIfoodIntegrado_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.OrdersIntegration(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Integrado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodConfirmado_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.OrdersConfirmation(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Confirmado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodSaiuParaSerEntregue_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.OrdersDispatch(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Saiu para entrega com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodRejeitado_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.OrdersRejection(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido rejeitado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodCancelamento_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var codeCancelament = (short)Ifood.Enum.CancelamentCode.Outro_descricao_obrigatoria;

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.CancellationRequested(_ifoodToken, _ifoodReferenceSelected, codeCancelament, "Cancelando..");
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodCancelamentoAceita_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.CancellationAccepted(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodCancelamentoRejeita_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_ifoodReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.CancellationDenied(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private delegate void WritelstGridIfoodDelegate();
        private void WriteGridIfood()
        {
            if (gridIfood.InvokeRequired)
            {
                var d = new WritelstGridIfoodDelegate(WriteGridIfood);
                Invoke(d, new object[] { });
            }
            else
            {
                gridIfood.DataSource = _ifoodOrders.ToList();
                gridIfood.Refresh();
            }
        }

        private void gridIfood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridIfood.Rows.Count)
            {
                _ifoodReferenceSelected = gridIfood.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        #endregion

        #region Gloria Food
        private void btnGloriaFoodIniciar_Click(object sender, EventArgs e)
        {
            gloriaIniciar();
        }

        public async void gloriaIniciar()
        {
            if (string.IsNullOrEmpty(txtGloriaFoodToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtGloriaFoodToken.Enabled = false;

            btnGloriaFoodIniciar.Enabled = false;
            btnGloriaFoodParar.Enabled = true;
            _gloriaToken = txtGloriaFoodToken.Text;
            await Task.Run(() => gloria());
        }

        private void btnGloriaFoodParar_Click(object sender, EventArgs e)
        {
            gloriaParar();
        }

        void gloriaParar()
        {
            txtGloriaFoodToken.Enabled = true;

            btnGloriaFoodIniciar.Enabled = true;
            btnGloriaFoodParar.Enabled = false;
        }

        private void gloria()
        {
            var gloriaService = new GloriaFoodService();

            try
            {
                while (btnGloriaFoodParar.Enabled)
                {
                    var orderResult = gloriaService.Polling(_gloriaToken);
                    if (orderResult.Success)
                    {
                        _gloriaOrders.AddRange(orderResult.Result);

                        WriteGridGloria();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    // O gloria food solicita que a requisição do pooling seja feito a cada 10 segundos
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridGloriaDelegate();
        private void WriteGridGloria()
        {
            if (gridIfood.InvokeRequired)
            {
                var d = new WritelstGridGloriaDelegate(WriteGridGloria);
                Invoke(d, new object[] { });
            }
            else
            {
                gridGloriaGood.DataSource = _gloriaOrders.ToList();
                gridGloriaGood.Refresh();
            }
        }

        private void btnGloriaFoodMenu_Click(object sender, EventArgs e)
        {
            if (btnGloriaFoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia primeiro o gloria food");
                return;
            }

            var gloriaService = new GloriaFoodService();
            var menu = gloriaService.Menu(_gloriaToken);
            if (menu.Success)
            {
                gridGloriaGood.DataSource = menu.Result.categories.ToList();
                gridGloriaGood.Refresh();
            }
            else
            {
                MessageBox.Show(menu.Message);
                return;
            }
        }

        #endregion

        #region Logaroo

        private string _urlLogarooDesenvolvimento = "https://api.dev.logaroo.com.br/v1/";
        private void btnLogarooLogin_Click(object sender, EventArgs e)
        {
            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Login(txtLogarooEmail.Text, txtLogarooSenha.Text);
            if (result.Success)
            {
                txtLogarooToken.Text = result.Result.data.token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooBuscarFormaPagamentos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Payments(txtLogarooToken.Text);
            if (result.Success)
            {
                gridLogaroo.DataSource = result.Result.data.items;
                gridLogaroo.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooListarPedidos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Orders(txtLogarooToken.Text, new Logaroo.Domain.orderfilter());
            if (result.Success)
            {
                gridLogaroo.DataSource = result.Result.data.items;
                gridLogaroo.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooCriarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            if (string.IsNullOrEmpty(txtLogarooMerchantId.Text))
            {
                MessageBox.Show("Digite o MerchantId");
                return;
            }

            Random randNum = new Random();
            var reference_id = randNum.Next();

            var pedido = new Logaroo.Domain.order();
            pedido.birth = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            pedido.delivery_forecast = DateTime.Now.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss");
            pedido.city = "Fortaleza";
            pedido.customer_email = "sa@bo.lc";
            pedido.customer_id_number = "9221";
            pedido.customer_name = "IzzyWay Tecnologia";
            pedido.customer_phone = "+5585981972243";

            var item1 = new Logaroo.Domain.orderitem();
            item1.name = "teste1";
            item1.quantity = 1;
            item1.cod = "1";
            item1.seq = 1;
            item1.observation = "com gelo";
            pedido.items.Add(item1);

            var item2 = new Logaroo.Domain.orderitem();
            item2.name = "teste2";
            item2.quantity = 2;
            item2.cod = "2";
            item2.seq = 2;
            item2.observation = "";
            pedido.items.Add(item2);

            pedido.lat = "-3.82660311645193";
            pedido.lng = "-38.49187777079774";
            pedido.merchant_id = txtLogarooMerchantId.Text;
            pedido.neighborhood = "Aldeota";
            pedido.number = "9862";
            pedido.origin = "iPOS";
            pedido.payment_code = "2";
            pedido.reference_id = reference_id.ToString();
            pedido.sale_channel = OrderReferenceName.CALL_CENTER;
            pedido.state = "CE";
            pedido.street = "test";
            pedido.sub_total = 8.01m;
            pedido.total_price = 8.01m;
            pedido.zipcode = "60000000";
            pedido.status = Logaroo.Enum.OrderStatus.PedidoFoiCapturado;

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Order(txtLogarooToken.Text, pedido);
            if (result.Success)
            {
                txtLogarooNumeroPedido.Text = result.Result.data.id.ToString();
                MessageBox.Show("Criado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooPedidoProntoParaColeta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            if (string.IsNullOrEmpty(txtLogarooNumeroPedido.Text))
            {
                MessageBox.Show("Digite o Nº do pedido");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.OrderStatus(txtLogarooToken.Text, txtLogarooNumeroPedido.Text, Logaroo.Enum.OrderStatus.PedidoProntoParaColeta);
            if (result.Success)
            {
                MessageBox.Show("Alterado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooEmProducao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            if (string.IsNullOrEmpty(txtLogarooNumeroPedido.Text))
            {
                MessageBox.Show("Digite o Nº do pedido");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.OrderStatus(txtLogarooToken.Text, txtLogarooNumeroPedido.Text, Logaroo.Enum.OrderStatus.PedidoSaiuParaEntrega);
            if (result.Success)
            {
                MessageBox.Show("Alterado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            if (string.IsNullOrEmpty(txtLogarooNumeroPedido.Text))
            {
                MessageBox.Show("Digite o Nº do pedido");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.GetOrder(txtLogarooToken.Text, txtLogarooNumeroPedido.Text);
            if (result.Success)
            {
                gridLogaroo.DataSource = result.Result.data;
                gridLogaroo.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooLogout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Logout(txtLogarooToken.Text);
            if (result.Success)
            {
                txtLogarooToken.Text = "";
                MessageBox.Show("Logout com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnLogarooPedidoEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            if (string.IsNullOrEmpty(txtLogarooNumeroPedido.Text))
            {
                MessageBox.Show("Digite o Nº do pedido");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.GetOrder(txtLogarooToken.Text, txtLogarooNumeroPedido.Text);
            if (result.Success)
            {
                if (result.Result.data.status == OrderStatus.PedidoEntregueAoCliente ||
                    result.Result.data.status == OrderStatus.PedidoComprovanteDePagamentoEntregueAoLojista)
                {
                    MessageBox.Show("Pedido entregue");
                }
                else
                {
                    MessageBox.Show(result.Result.data.status);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Super Menu
        private void btnSuperMenuIniciar_Click(object sender, EventArgs e)
        {
            superMenuIniciar();
        }

        public async void superMenuIniciar()
        {
            if (string.IsNullOrEmpty(txtSuperMenuToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtSuperMenuToken.Enabled = false;

            btnSuperMenuIniciar.Enabled = false;
            btnSuperMenuParar.Enabled = true;
            _superMenuToken = txtSuperMenuToken.Text;
            await Task.Run(() => superMenu());
        }

        private void btnSuperMenuParar_Click(object sender, EventArgs e)
        {
            superMenuParar();
        }

        void superMenuParar()
        {
            txtSuperMenuToken.Enabled = true;

            btnSuperMenuIniciar.Enabled = true;
            btnSuperMenuParar.Enabled = false;
        }

        private void superMenu()
        {
            var superMenuService = new SuperMenu.Service.SuperMenuService();

            try
            {
                while (btnSuperMenuParar.Enabled)
                {
                    var eventPollingResult = superMenuService.EventPolling(_superMenuToken);

                    if (eventPollingResult.Success)
                    {
                        var eventsIds = new List<SuperMenu.Domain.eventAcknowledgment>();

                        foreach (var poolingEvent in eventPollingResult.Result)
                        {
                            if (!poolingEvent.integrated && poolingEvent.code == SuperMenu.Domain.PoolingEventStatusCode.PENDING_APPROVAL)
                            {
                                var orderResult = superMenuService.Order(_superMenuToken, poolingEvent.correlationId);
                                if (orderResult.Success)
                                {
                                    var order = _superMenuOrders.FirstOrDefault(f => f.id == orderResult.Result.id);
                                    if (order == null)
                                    {
                                        _superMenuOrders.Add(orderResult.Result);
                                    }

                                    WriteGridSuperMenu();
                                }
                                else
                                {
                                    MessageBox.Show(orderResult.Message);
                                    return;
                                }
                            }

                            eventsIds.Add(new SuperMenu.Domain.eventAcknowledgment { id = poolingEvent.id });
                        }

                        if (eventsIds.Any())
                        {
                            var eventAcknowledgmentResult = superMenuService.EventAcknowledgment(_superMenuToken, eventsIds);
                            if (!eventAcknowledgmentResult.Success)
                            {
                                MessageBox.Show(eventAcknowledgmentResult.Message);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(eventPollingResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridSuperMenuDelegate();
        private void WriteGridSuperMenu()
        {
            if (gridIfood.InvokeRequired)
            {
                var d = new WritelstGridSuperMenuDelegate(WriteGridSuperMenu);
                Invoke(d, new object[] { });
            }
            else
            {
                gridSuperMenu.DataSource = _superMenuOrders.ToList();
                gridSuperMenu.Refresh();
            }
        }

        private void gridSuperMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridSuperMenu.Rows.Count)
            {
                _superMenuReferenceSelected = gridSuperMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnSuperMenuConfirmar_Click(object sender, EventArgs e)
        {
            if (btnSuperMenuIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_superMenuReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var superMenuService = new SuperMenu.Service.SuperMenuService();
            var result = superMenuService.StatusEdit(_superMenuToken, _superMenuReferenceSelected, SuperMenu.Domain.PoolingEventStatusCode.APPROVED);
            if (result.Success)
            {
                MessageBox.Show("Pedido confirmado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSuperMenuSaiuParaSerEntregue_Click(object sender, EventArgs e)
        {
            if (btnSuperMenuIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_superMenuReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var superMenuService = new SuperMenu.Service.SuperMenuService();
            var result = superMenuService.StatusEdit(_superMenuToken, _superMenuReferenceSelected, SuperMenu.Domain.PoolingEventStatusCode.OUT_FOR_DELIVERY);
            if (result.Success)
            {
                MessageBox.Show("Pedido saiu para entregue com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSuperMenuRejeitar_Click(object sender, EventArgs e)
        {
            if (btnSuperMenuIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_superMenuReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var superMenuService = new SuperMenu.Service.SuperMenuService();
            var result = superMenuService.StatusEdit(_superMenuToken, _superMenuReferenceSelected, SuperMenu.Domain.PoolingEventStatusCode.REFUSED);
            if (result.Success)
            {
                MessageBox.Show("Pedido rejeitado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSuperMenuCancelar_Click(object sender, EventArgs e)
        {
            if (btnSuperMenuIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_superMenuReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var superMenuService = new SuperMenu.Service.SuperMenuService();
            var result = superMenuService.StatusEdit(_superMenuToken, _superMenuReferenceSelected, SuperMenu.Domain.PoolingEventStatusCode.CANCELLED);
            if (result.Success)
            {
                MessageBox.Show("Pedido cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        private void btnTeste_Click(object sender, EventArgs e)
        {
            var json = @"{'count':1,'orders':[{'instructions':null,'coupons':[],'tax_list':[],'missed_reason':null,'id':114412588,'total_price':59,'sub_total_price':50,'tax_value':0,'persons':0,'latitude':0,'longitude':0,'client_first_name':'Paulo','client_last_name':'Roberto','client_email':'raffaella_lidiany@outlook.com','client_phone':'+5584987460755','restaurant_name':'Divino Camarão','currency':'BRL','type':'delivery','status':'accepted','source':'mobile_web','pin_skipped':true,'accepted_at':'2020-06-05T21:17:02.000Z','tax_type':'NET','tax_name':'Sales Tax','fulfill_at':'2020-06-05T22:12:02.000Z','reference':null,'restaurant_id':120883,'client_id':7876195,'updated_at':'2020-06-05T21:17:02.000Z','restaurant_phone':'+55 84 2030 7074','restaurant_timezone':'America/Fortaleza','company_account_id':692661,'pos_system_id':13381,'restaurant_key':'bdJYkIErqujJ9qmV3J','restaurant_country':'Brazil','restaurant_city':'Natal','restaurant_state':'Rio Grande do Norte','restaurant_zipcode':'59066-035','restaurant_street':'Av. da Integração, 3491- Candelária','restaurant_latitude':'-5.842292073108915','restaurant_longitude':'-35.22011252883607','restaurant_token':'','gateway_transaction_id':null,'gateway_type':null,'api_version':2,'payment':'CARD','for_later':false,'client_address':'Rua Antônio carolino, n° 100. Residencial Ária, Casa 09, Terminal de ônibus da Conceição , 59074-330, Felipe camarão ','client_address_parts':{'street':'Rua Antônio carolino, n° 100. Residencial Ária, Casa 09','city':'Felipe camarão ','zipcode':'59074-330','more_address':'Terminal de ônibus da Conceição '},'items':[{'id':144328153,'name':'DELIVERY_FEE','total_item_price':9,'price':9,'quantity':1,'instructions':null,'type':'delivery_fee','type_id':243971,'tax_rate':0,'tax_value':0,'parent_id':null,'item_discount':0,'cart_discount_rate':0,'cart_discount':0,'tax_type':'NET','options':[]},{'id':144329357,'name':'Promoção Sexta/ Camarão internacional','total_item_price':50,'price':50,'quantity':1,'instructions':'','type':'item','type_id':4098465,'tax_rate':0,'tax_value':0,'parent_id':null,'item_discount':0,'cart_discount_rate':0,'cart_discount':0,'tax_type':'NET','options':[]}]}]}";
            var t = JsonConvert.DeserializeObject<GloriaFood.Domain.polling>(json);
        }

        #region PedZap

        public async void pedZaoIniciar()
        {
            if (string.IsNullOrEmpty(txtPedZapToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtPedZapToken.Enabled = false;

            btnPedZapIniciar.Enabled = false;
            btnPedZapParar.Enabled = true;
            _pedzap = txtPedZapToken.Text;
            await Task.Run(() => pedzap());
        }

        void pedZapParar()
        {
            txtPedZapToken.Enabled = true;

            btnPedZapIniciar.Enabled = true;
            btnPedZapParar.Enabled = false;
        }

        private void pedzap()
        {
            var pedZapService = new PedZapService();

            try
            {
                while (btnPedZapParar.Enabled)
                {
                    var orderResult = pedZapService.Pedidos(_pedzap, PedidoStatus.PENDENTE, 0);
                    if (orderResult.Success)
                    {
                        _pedzapPedidos.AddRange(orderResult.Result);

                        WritePedZap();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(100000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridPedZapDelegate();
        private void WritePedZap()
        {
            if (gridPedZap.InvokeRequired)
            {
                var d = new WritelstGridPedZapDelegate(WritePedZap);
                Invoke(d, new object[] { });
            }
            else
            {
                gridPedZap.DataSource = _pedzapPedidos.ToList();
                gridPedZap.Refresh();
            }
        }

        private void gridPedZap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridPedZap.Rows.Count)
            {
                _pedzapReferenceSelected = Convert.ToInt32(gridPedZap.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void btnPedZapIniciar_Click(object sender, EventArgs e)
        {
            pedZaoIniciar();
        }

        private void btnPedZapParar_Click(object sender, EventArgs e)
        {
            pedZapParar();
        }

        private void btnPedZapBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido(_pedzap, _pedzapReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido buscado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedZapAceito_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido_Status(_pedzap, _pedzapReferenceSelected, PedidoStatus.ACEITO, 1);
            if (result.Success)
            {
                MessageBox.Show("Pedido aceito com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedZapRejeitado_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido_Status(_pedzap, _pedzapReferenceSelected, PedidoStatus.REJEITADO, 1);
            if (result.Success)
            {
                MessageBox.Show("Pedido rejeitado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedZapPreparado_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido_Status(_pedzap, _pedzapReferenceSelected, PedidoStatus.PREPARADO, 1);
            if (result.Success)
            {
                MessageBox.Show("Pedido preparado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedZapEntregue_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido_Status(_pedzap, _pedzapReferenceSelected, PedidoStatus.ENTREGUE, 1);
            if (result.Success)
            {
                MessageBox.Show("Pedido entregue com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedZapDesistencia_Click(object sender, EventArgs e)
        {
            if (btnPedZapIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_pedzapReferenceSelected == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var pedzapService = new PedZap.Service.PedZapService();
            var result = pedzapService.Pedido_Status(_pedzap, _pedzapReferenceSelected, PedidoStatus.DESISTENCIA, 1);
            if (result.Success)
            {
                MessageBox.Show("Pedido desistido com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }



        #endregion

        #region DeliveryApp
        private void btnDeliveryAppIniciar_Click(object sender, EventArgs e)
        {
            deliveryAppIniciar();
        }

        private void btnDeliveryAppParar_Click(object sender, EventArgs e)
        {
            deliveryAppParar();
        }

        public async void deliveryAppIniciar()
        {
            if (string.IsNullOrEmpty(txtDeliveryAppToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtDeliveryAppToken.Enabled = false;

            btnDeliveryAppIniciar.Enabled = false;
            btnDeliveryAppParar.Enabled = true;
            _deliveryAppToken = txtDeliveryAppToken.Text;
            await Task.Run(() => deliveryApp());
        }

        private void deliveryApp()
        {
            var deliveryAppService = new DeliveryAppService();

            try
            {
                while (btnDeliveryAppParar.Enabled)
                {
                    var orderResult = deliveryAppService.Order(_deliveryAppToken);
                    if (orderResult.Success)
                    {
                        _deliveryAppOrders.AddRange(orderResult.Result);

                        WriteGridDeliveryApp();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridDeliveryAppDelegate();
        private void WriteGridDeliveryApp()
        {
            if (gridDeliveryApp.InvokeRequired)
            {
                var d = new WritelstGridDeliveryAppDelegate(WriteGridDeliveryApp);
                Invoke(d, new object[] { });
            }
            else
            {
                gridDeliveryApp.DataSource = _deliveryAppOrders.ToList();
                gridDeliveryApp.Refresh();
            }
        }

        void deliveryAppParar()
        {
            txtDeliveryAppToken.Enabled = true;

            btnDeliveryAppIniciar.Enabled = true;
            btnDeliveryAppParar.Enabled = false;
        }

        #endregion

        #region Meu Cardápio Ai

        private void btnMeuCardapioAiToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMeuCardapioAiClient_ID.Text))
            {
                MessageBox.Show("Campo Client ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtMeuCardapioAiClient_SECRET.Text))
            {
                MessageBox.Show("Campo Client SECRET Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtMeuCardapioAiURL.Text))
            {
                MessageBox.Show("Campo URl Obrigatório");
                return;
            }

            var meuCardapioAiService = new MeuCardapioAiService(txtMeuCardapioAiURL.Text);
            var result = meuCardapioAiService.Token(txtMeuCardapioAiClient_ID.Text, txtMeuCardapioAiClient_SECRET.Text);
            if (result.Success)
            {
                txtMeuCardapioAiToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnMeuCardapioAiIniciar_Click(object sender, EventArgs e)
        {
            meuCardapioAiIniciar();
        }

        private void btnMeuCardapioAiParar_Click(object sender, EventArgs e)
        {
            meuCardapioAiParar();
        }

        public async void meuCardapioAiIniciar()
        {
            if (string.IsNullOrEmpty(txtMeuCardapioAiToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtMeuCardapioAiClient_ID.Enabled = false;
            txtMeuCardapioAiClient_SECRET.Enabled = false;
            txtMeuCardapioAiURL.Enabled = false;

            btnMeuCardapioAiIniciar.Enabled = false;
            btnMeuCardapioAiParar.Enabled = true;
            _meuCardapioAiToken = txtMeuCardapioAiToken.Text;
            _meuCardapioAiUltimoPedido = txtMeuCardapioAiUltimoPedido.Text;
            await Task.Run(() => meuCardapioAi());
        }

        private void meuCardapioAi()
        {
            var meuCardapioAiService = new MeuCardapioAiService(txtMeuCardapioAiURL.Text);

            try
            {
                while (btnMeuCardapioAiParar.Enabled)
                {
                    var orderResult = meuCardapioAiService.Orders(_meuCardapioAiToken, _meuCardapioAiUltimoPedido);
                    if (orderResult.Success)
                    {
                        _meuCardapioAiOrders.AddRange(orderResult.Result.data.pedidos);

                        WriteGridMeuCardapioAi();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridWriteGridMeuCardapioAiDelegate();
        private void WriteGridMeuCardapioAi()
        {
            if (gridMeuCardapioAi.InvokeRequired)
            {
                var d = new WritelstGridWriteGridMeuCardapioAiDelegate(WriteGridMeuCardapioAi);
                Invoke(d, new object[] { });
            }
            else
            {
                gridMeuCardapioAi.DataSource = _meuCardapioAiOrders.ToList();
                gridMeuCardapioAi.Refresh();
            }
        }

        void meuCardapioAiParar()
        {
            btnMeuCardapioAiIniciar.Enabled = true;
            btnMeuCardapioAiParar.Enabled = false;
        }

        private void gridMeuCardapioAi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridMeuCardapioAi.Rows.Count)
            {
                _meuCardapioAiSelected = gridMeuCardapioAi.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnMeuCardapioAiBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnMeuCardapioAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_meuCardapioAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var meuCardapioAiService = new MeuCardapioAiService(txtMeuCardapioAiURL.Text);
            var result = meuCardapioAiService.Order(_meuCardapioAiToken, _meuCardapioAiSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnMeuCardapioAiSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (btnMeuCardapioAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_meuCardapioAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var meuCardapioAiService = new MeuCardapioAiService(txtMeuCardapioAiURL.Text);
            var result = meuCardapioAiService.Status(_meuCardapioAiToken, _meuCardapioAiSelected, MeuCardapioAi.Enum.OrderStatus.SAIU_PARA_ENTREGA);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnMeuCardapioAiCancelar_Click(object sender, EventArgs e)
        {
            if (btnMeuCardapioAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_meuCardapioAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var meuCardapioAiService = new MeuCardapioAiService(txtMeuCardapioAiURL.Text);
            var result = meuCardapioAiService.Status(_meuCardapioAiToken, _meuCardapioAiSelected, MeuCardapioAi.Enum.OrderStatus.CANCELADO);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Anota Ai
        private void btnAnotaAiIniciar_Click(object sender, EventArgs e)
        {
            anotaAiIniciar();
        }

        private void btnAnotaAiParar_Click(object sender, EventArgs e)
        {
            anotaAiParar();
        }

        public async void anotaAiIniciar()
        {
            if (string.IsNullOrEmpty(txtAnotaAiToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtAnotaAiToken.Enabled = false;

            btnAnotaAiIniciar.Enabled = false;
            btnAnotaAiParar.Enabled = true;
            _anotaAiToken = txtAnotaAiToken.Text;
            await Task.Run(() => anotaAi());
        }

        private void anotaAi()
        {
            var anotaAiService = new AnotaAiService();

            try
            {
                while (btnAnotaAiParar.Enabled)
                {
                    var orderResult = anotaAiService.Orders(_anotaAiToken);
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result.info.docs)
                        {
                            _anotaAiOrders.Add(new AnotaAi.Domain.order
                            {
                                id = item._id,
                                check = item.check
                            });
                        }

                        WriteGridAnotaAi();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(30000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridAnotaAiDelegate();
        private void WriteGridAnotaAi()
        {
            if (gridAnotaAi.InvokeRequired)
            {
                var d = new WritelstGridAnotaAiDelegate(WriteGridAnotaAi);
                Invoke(d, new object[] { });
            }
            else
            {
                gridAnotaAi.DataSource = _anotaAiOrders.ToList();
                gridAnotaAi.Refresh();
            }
        }

        void anotaAiParar()
        {
            txtAnotaAiToken.Enabled = true;

            btnAnotaAiIniciar.Enabled = true;
            btnAnotaAiParar.Enabled = false;
        }

        private void gridAnotaAi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridAnotaAi.Rows.Count)
            {
                _anotaAiSelected = gridAnotaAi.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnAnotaAiBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnAnotaAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_anotaAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var anotaAiService = new AnotaAiService();
            var result = anotaAiService.Order(_anotaAiToken, _anotaAiSelected);
            if (result.Success)
            {
                MessageBox.Show("Buscando pedido com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAnotaAiAceitar_Click(object sender, EventArgs e)
        {
            if (btnAnotaAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_anotaAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var anotaAiService = new AnotaAiService();
            var result = anotaAiService.Accept(_anotaAiToken, _anotaAiSelected);
            if (result.Success)
            {
                MessageBox.Show("Aceito com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAnotaAiPedidoPronto_Click(object sender, EventArgs e)
        {
            if (btnAnotaAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_anotaAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var anotaAiService = new AnotaAiService();
            var result = anotaAiService.Ready(_anotaAiToken, _anotaAiSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido pronto com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAnotaAiSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (btnAnotaAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_anotaAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var anotaAiService = new AnotaAiService();
            var result = anotaAiService.Finalize(_anotaAiToken, _anotaAiSelected);
            if (result.Success)
            {
                MessageBox.Show("Finalizado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAnotaAiCancelar_Click(object sender, EventArgs e)
        {
            if (btnAnotaAiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_anotaAiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var anotaAiService = new AnotaAiService();
            var result = anotaAiService.Cancel(_anotaAiToken, _anotaAiSelected, "Teste de Api");
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        #endregion

        #region Rappi

        private void btnRappiToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRappiClientID.Text))
            {
                MessageBox.Show("Campo Client ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtRappiSECRET.Text))
            {
                MessageBox.Show("Campo Client SECRET Obrigatório");
                return;
            }


            var rappiService = new RappiService("");
            var result = rappiService.Token(txtRappiClientID.Text, txtRappiSECRET.Text, true);
            if (result.Success)
            {
                txtRappiToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnRappiIniciar_Click(object sender, EventArgs e)
        {
            rappiIniciar();
        }

        private void btnRappiParar_Click(object sender, EventArgs e)
        {
            rappiParar();
        }


        public async void rappiIniciar()
        {
            if (string.IsNullOrEmpty(txtRappiToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtRappiClientID.Enabled = false;
            txtRappiSECRET.Enabled = false;
            txtRappiURL.Enabled = false;

            btnRappiIniciar.Enabled = false;
            btnRappiParar.Enabled = true;
            _rappiToken = txtRappiToken.Text;
            await Task.Run(() => rappi());
        }

        private void rappi()
        {
            var rappiService = new RappiService(txtRappiURL.Text);

            try
            {
                while (btnRappiParar.Enabled)
                {
                    var orderResult = rappiService.Orders(_rappiToken);
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result)
                        {
                            if (item.order_Detail != null)
                            {
                                _rappiOrders.Add(item.order_Detail);
                                WriteGridMeuRappi();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridWriteGridRappiDelegate();
        private void WriteGridMeuRappi()
        {
            if (gridRappi.InvokeRequired)
            {
                var d = new WritelstGridWriteGridRappiDelegate(WriteGridMeuRappi);
                Invoke(d, new object[] { });
            }
            else
            {
                gridRappi.DataSource = _rappiOrders.ToList();
                gridRappi.Refresh();
            }
        }

        void rappiParar()
        {
            btnRappiIniciar.Enabled = true;
            btnRappiParar.Enabled = false;
        }

        private void gridRappi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridRappi.Rows.Count)
            {
                _rappiSelected = gridRappi.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnRappiAceitarPedido_Click(object sender, EventArgs e)
        {
            if (btnRappiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_rappiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var rappiService = new RappiService(txtRappiURL.Text);
            var result = rappiService.Take(_rappiToken, _rappiSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnRappiPedidoPronto_Click(object sender, EventArgs e)
        {
            if (btnRappiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_rappiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var rappiService = new RappiService(txtRappiURL.Text);
            var result = rappiService.ReadForPickup(_rappiToken, _rappiSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnRappiRejeitado_Click(object sender, EventArgs e)
        {
            if (btnRappiIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_rappiSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var rappiService = new RappiService(txtRappiURL.Text);
            var result = rappiService.Reject(_rappiToken, _rappiSelected, "Teste", Rappi.Enum.CancelType.ORDER_MISSING_ADDRESS_INFORMATION);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region OnPedido

        private void btnOnPedidoIniciar_Click(object sender, EventArgs e)
        {
            onPedidoIniciar();
        }

        private void btnOnPedidoParar_Click(object sender, EventArgs e)
        {
            onPedidoParar();
        }

        public async void onPedidoIniciar()
        {
            if (string.IsNullOrEmpty(txtOnPedidoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            btnOnPedidoIniciar.Enabled = false;
            btnOnPedidoParar.Enabled = true;
            _onPedidoToken = txtOnPedidoToken.Text;
            await Task.Run(() => onPedido());
        }

        private void onPedido()
        {
            var onPedidoService = new OnPedidoService();

            try
            {
                while (btnOnPedidoParar.Enabled)
                {
                    var orderResult = onPedidoService.Orders(_onPedidoToken);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result.status != null && orderResult.Result.status.pedidos != null)
                        {
                            if (orderResult.Result.status.pedidos.NaoRecebidos != null)
                            {
                                foreach (var item in orderResult.Result.status.pedidos.NaoRecebidos.IDs)
                                {
                                    var id = Convert.ToInt32(item);
                                    var existe = _onPedidoPedidos.Any(a => a.pedido == id);
                                    if (!existe)
                                        _onPedidoPedidos.Add(new Id { pedido = id, cliente = (byte)OnPedido.Enum.OrderStatus.Nenhum });
                                }
                            }

                            if (orderResult.Result.status.pedidos.Confirmados != null)
                            {
                                foreach (var item in orderResult.Result.status.pedidos.Confirmados.IDs)
                                {
                                    var id = Convert.ToInt32(item);
                                    var existe = _onPedidoPedidos.Any(a => a.pedido == id);
                                    if (!existe)
                                        _onPedidoPedidos.Add(new Id { pedido = id, cliente = (byte)OnPedido.Enum.OrderStatus.Confirmado });
                                }
                            }

                            if (orderResult.Result.status.pedidos.Cancelados != null)
                            {
                                foreach (var item in orderResult.Result.status.pedidos.Cancelados.IDs)
                                {
                                    var id = Convert.ToInt32(item);
                                    var existe = _onPedidoPedidos.Any(a => a.pedido == id);
                                    if (!existe)
                                        _onPedidoPedidos.Add(new Id { pedido = id, cliente = (byte)OnPedido.Enum.OrderStatus.Cancelado });
                                }
                            }

                            if (orderResult.Result.status.pedidos.Despachados != null)
                            {
                                foreach (var item in orderResult.Result.status.pedidos.Despachados.IDs)
                                {
                                    var id = Convert.ToInt32(item);
                                    var existe = _onPedidoPedidos.Any(a => a.pedido == id);
                                    if (!existe)
                                        _onPedidoPedidos.Add(new Id { pedido = id, cliente = (byte)OnPedido.Enum.OrderStatus.Despachado });
                                }
                            }

                            if (orderResult.Result.status.pedidos.Entregues != null)
                            {
                                foreach (var item in orderResult.Result.status.pedidos.Entregues.IDs)
                                {
                                    var id = Convert.ToInt32(item);
                                    var existe = _onPedidoPedidos.Any(a => a.pedido == id);
                                    if (!existe)
                                        _onPedidoPedidos.Add(new Id { pedido = id, cliente = (byte)OnPedido.Enum.OrderStatus.Entregue });
                                }
                            }

                            WriteGridOnPedido();
                        }
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridWriteGridOnPedidoDelegate();
        private void WriteGridOnPedido()
        {
            if (gridOnPedido.InvokeRequired)
            {
                var d = new WritelstGridWriteGridOnPedidoDelegate(WriteGridOnPedido);
                Invoke(d, new object[] { });
            }
            else
            {
                gridOnPedido.DataSource = _onPedidoPedidos.ToList();
                gridOnPedido.Refresh();
            }
        }

        void onPedidoParar()
        {
            btnOnPedidoIniciar.Enabled = true;
            btnOnPedidoParar.Enabled = false;
        }

        private void gridOnPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridOnPedido.Rows.Count)
            {
                _onPedidoSelected = gridOnPedido.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnOnPedidoBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            onPedidoService.Order(_onPedidoToken, _onPedidoSelected);
        }

        private void btnOnPedidoRecebido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            var result = onPedidoService.Status(_onPedidoToken, _onPedidoSelected, ((byte)OnPedido.Enum.OrderStatus.Recebido).ToString());
            if(result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnOnPedidoConfirmado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            var result = onPedidoService.Status(_onPedidoToken, _onPedidoSelected, ((byte)OnPedido.Enum.OrderStatus.Confirmado).ToString());
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnOnPedidoSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            var result = onPedidoService.Status(_onPedidoToken, _onPedidoSelected, ((byte)OnPedido.Enum.OrderStatus.Despachado).ToString());
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnOnPedidoEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            var result = onPedidoService.Status(_onPedidoToken, _onPedidoSelected, ((byte)OnPedido.Enum.OrderStatus.Entregue).ToString());
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnOnPedidoCancelado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_onPedidoSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var onPedidoService = new OnPedidoService();
            var result = onPedidoService.Status(_onPedidoToken, _onPedidoSelected, ((byte)OnPedido.Enum.OrderStatus.Cancelado).ToString());
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Cinddi
        private void btnCinddiIniciar_Click(object sender, EventArgs e)
        {
            cinddiIniciar();
        }

        private void btnCinddiParar_Click(object sender, EventArgs e)
        {
            cinddiParar();
        }

        public async void cinddiIniciar()
        {
            if (string.IsNullOrEmpty(txtCinddiToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            btnCinddiIniciar.Enabled = false;
            btnCinddiParar.Enabled = true;
            _cinddiToken = txtCinddiToken.Text;
            await Task.Run(() => cinddi());
        }

        private void cinddi()
        {
            var service = new CinddiService();

            try
            {
                while (btnCinddiParar.Enabled)
                {
                    var orderResult = service.Orders(_cinddiToken);
                    if (orderResult.Success)
                    {
                        _cinddiPedidos = new List<Cinddi.Domain.ResponseOrders>();
                        _cinddiPedidos.AddRange(orderResult.Result);
                        WriteGridCinddi();                        
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridWriteGridCinddiDelegate();
        private void WriteGridCinddi()
        {
            if (gridCinddi.InvokeRequired)
            {
                var d = new WritelstGridWriteGridCinddiDelegate(WriteGridCinddi);
                Invoke(d, new object[] { });
            }
            else
            {
                gridCinddi.DataSource = _cinddiPedidos.ToList();
                gridCinddi.Refresh();
            }
        }

        void cinddiParar()
        {
            btnCinddiIniciar.Enabled = true;
            btnCinddiParar.Enabled = false;
        }

        private void gridCinddi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridCinddi.Rows.Count)
            {
                _cinddiSelected = gridCinddi.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }


        private void btnCinddiBuscarPedido_Click(object sender, EventArgs e)
        {

        }

        private void btnCinddiPreparo_Click(object sender, EventArgs e)
        {

        }

        private void btnCinddiEntrega_Click(object sender, EventArgs e)
        {

        }

        private void btnCinddiFinalizado_Click(object sender, EventArgs e)
        {

        }

        private void btnCinddiCancelar_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
