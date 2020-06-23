using GloriaFood.Service;
using Newtonsoft.Json;
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
        private string _ifoodToken { get; set; }
        private List<Ifood.Domain.order> _ifoodOrders { get; set; }
        private string _ifoodReferenceSelected { get; set; }
        private string _gloriaToken { get; set; }
        private List<GloriaFood.Domain.order> _gloriaOrders { get; set; }
        private string _superMenuToken { get; set; }
        private List<SuperMenu.Domain.order> _superMenuOrders { get; set; }
        private string _superMenuReferenceSelected { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

                        if (marketPlace.Logaroo != null)
                        {
                            txtLogarooMerchantId.Text = marketPlace.Logaroo.MerchantId;
                            txtLogarooEmail.Text = marketPlace.Logaroo.Usuario;
                            txtLogarooSenha.Text = marketPlace.Logaroo.Senha;
                        }

                        if (marketPlace.SuperMenu != null)
                        {
                            txtSuperMenuToken.Text = marketPlace.SuperMenu.Token;
                        }
                    }
                }
            }

            _ifoodOrders = new List<Ifood.Domain.order>();
            gridIfood.DataSource = _ifoodOrders.ToList();
            gridIfood.Refresh();

            _gloriaOrders = new List<GloriaFood.Domain.order>();
            gridGloriaGood.DataSource = _gloriaOrders.ToList();
            gridGloriaGood.Refresh();

            _superMenuOrders = new List<SuperMenu.Domain.order>();
            gridSuperMenu.DataSource = _superMenuOrders.ToList();
            gridSuperMenu.Refresh();
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
            if(btnGloriaFoodIniciar.Enabled)
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
            if(result.Success)
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
            if(string.IsNullOrEmpty(txtLogarooToken.Text))
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
            var result = logarooService.Orders(txtLogarooToken.Text);
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
            pedido.city = "Fortaleza";
            pedido.customer_email = "sa@bo.lc";
            pedido.customer_id_number = "9221";
            pedido.customer_name = "Marcos Tertuliano Saraiva Martins";
            pedido.customer_phone = "+5585981972243";

            var itens = new List<Logaroo.Domain.orderitem>();
            var item1 = new Logaroo.Domain.orderitem();
            item1.name = "teste1";
            item1.quantity = 1;
            item1.code = "1";
            item1.seq = 1;
            item1.observation = "com gelo";
            itens.Add(item1);

            var item2 = new Logaroo.Domain.orderitem();
            item2.name = "teste2";
            item2.quantity = 2;
            item2.code = "2";
            item2.seq = 2;
            item2.observation = "";
            itens.Add(item2);

            pedido.addItems(itens);

            pedido.lat = "-3.82660311645193";
            pedido.lng = "-38.49187777079774";
            pedido.merchant_id = txtLogarooMerchantId.Text;
            pedido.neighborhood = "Aldeota";
            pedido.number = "9862";
            pedido.origin = "iPOS";
            pedido.payment_code = "2";
            pedido.reference_id = reference_id.ToString();
            pedido.reference_name = "iPOS";
            pedido.state = "CE";
            pedido.street = "test";
            pedido.sub_total = 8.01m;
            pedido.total_price = 8.01m;
            pedido.zipcode = "60000000";
            pedido.status = Logaroo.Enum.OrderStatus.PedidoEmProducao;

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var result = logarooService.Order(txtLogarooToken.Text, pedido);
            if (result.Success)
            {
                txtLogarooNumeroPedido.Text = reference_id.ToString();
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

        private void btnLogarooSaiuParaEntrega_Click(object sender, EventArgs e)
        {

        }

        private void btnLogarooRecebido_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Saiu com sucesso");
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

        
    }
}
