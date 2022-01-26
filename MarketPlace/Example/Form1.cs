using Accon.Service;
using Aipedi.Service;
using Aiqfome.Service;
using AnotaAi.Service;
using Cinddi.Service;
using DeliveryApp.Service;
using DeliveryDireto.Service;
using Epadoca.Service;
using GloriaFood.Service;
using Goomer.Service;
using IDelivery.Service;
using Ifood.Enum;
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

        private List<Accon.Domain.order> _acconOrders { get; set; }
        private string _acconSelected { get; set; }
        private string _anotaAiSelected { get; set; }
        private string _anotaAiToken { get; set; }
        private List<AnotaAi.Domain.order> _anotaAiOrders { get; set; }
        private string _deliveryAppToken { get; set; }
        private string _deliveryAppReferenceSelected { get; set; }
        private List<DeliveryApp.Domain.order> _deliveryAppOrders { get; set; }
        private List<DeliveryDireto.Domain.order> _deliveryDiretoOrders { get; set; }
        private string _deliveryDiretoReferenceSelected { get; set; }
        private string _ifoodToken { get; set; }
        private List<Ifood.Domain.order> _ifoodOrders { get; set; }
        private string _ifoodReferenceSelected { get; set; }
        private string _gloriaToken { get; set; }
        private List<GloriaFood.Domain.order> _gloriaOrders { get; set; }
        private List<Goomer.Domain.order> _goomerOrders { get; set; }
        private string _goomerSelected { get; set; }
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

        private List<Aipedi.Domain.order> _pedreiroDigitalOrders { get; set; }
        private string _pedreiroDigitalReferenceSelected { get; set; }

        private List<IDelivery.Domain.order> _iDeliveryOrders { get; set; }
        private string _iDeliveryReferenceSelected { get; set; }

        private List<UberEats.Domain.order_result> _uberOrders { get; set; }
        private string _uberEaTSSelected { get; set; }

        private List<Aiqfome.Domain.orders_result_order> _aiqfomeOrders { get; set; }
        private string _aiqfomeSSelected { get; set; }

        private string _epadocaSelected { get; set; }
        private List<Epadoca.Domain.order> _epadocaOrders { get; set; }

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
                            if (marketPlace.Accon != null)
                            {
                                txtAcconUsuario.Text = marketPlace.Accon.Usuario;
                                txtAcconSenha.Text = marketPlace.Accon.Senha;
                                txtAcconRede.Text = marketPlace.Accon.Rede;
                            }

                            if (marketPlace.Aiqfome != null)
                            {
                                txtAiqfomeAgente.Text = marketPlace.Aiqfome.MerchantId;
                                txtAiqfomeSenha.Text = marketPlace.Aiqfome.Senha;
                                txtAiqfomeAuthorization.Text = marketPlace.Aiqfome.Token;
                                txtAiqfomeUsuario.Text = marketPlace.Aiqfome.Usuario;
                                txtAiqfomeURL.Text = marketPlace.Aiqfome.Url;
                            }

                            if (marketPlace.AnotaAi != null)
                            {
                                txtAnotaAiToken.Text = marketPlace.AnotaAi.Token;
                            }

                            if (marketPlace.AtivMob != null)
                            {
                                txtAtivMobToken.Text = marketPlace.AtivMob.Token;
                                txtAtivMobURL.Text = marketPlace.AtivMob.Url;
                                txtAtivMobMerchantId.Text = marketPlace.AtivMob.MerchantId;
                            }

                            if (marketPlace.Cinddi != null)
                            {
                                txtCinddiToken.Text = marketPlace.Cinddi.Token;
                            }

                            if (marketPlace.DeliveryApp != null)
                            {
                                txtDeliveryAppToken.Text = marketPlace.DeliveryApp.Token;
                            }

                            if (marketPlace.DeliveryDireto != null)
                            {
                                txtDeliveryDiretoToken.Text = marketPlace.DeliveryDireto.Token;
                                txtDeliveryDiretoMerchandId.Text = marketPlace.DeliveryDireto.MerchantId;
                                txtDeliveryDiretoUsuario.Text = marketPlace.DeliveryDireto.Usuario;
                                txtDeliveryDiretoSenha.Text = marketPlace.DeliveryDireto.Senha;
                            }

                            if (marketPlace.Epadoca != null)
                            {
                                txtEpadocaUsuario.Text = marketPlace.Epadoca.Usuario;
                                txtEpadocaSenha.Text = marketPlace.Epadoca.Senha;
                                txtEpadocaMerchantId.Text = marketPlace.Epadoca.MerchantId;
                                txtEpadocaUrl.Text = marketPlace.Epadoca.Url;
                            }

                            if (marketPlace.Ifood != null)
                            {
                                txtIfoodClient_ID.Text = marketPlace.Ifood.Client_ID;
                                txtIfoodClient_Secret.Text = marketPlace.Ifood.Client_SECRET;
                                txtIfoodMerchantId.Text = marketPlace.Ifood.MerchantId;
                                txtIfoodMerchantGUID.Text = marketPlace.Ifood.Usuario;
                                txtIfoodDistribuidoAuthorizationCode.Text = marketPlace.Ifood.AuthorizationCode;
                                txtIfoodDistribuidoAuthorizationCodeVerificier.Text = marketPlace.Ifood.AuthorizationCodeVerifier;
                            }

                            if (marketPlace.Gloria != null)
                            {
                                txtGloriaFoodToken.Text = marketPlace.Gloria.Token;
                            }

                            if (marketPlace.Goomer != null)
                            {
                                txtGoomerToken.Text = marketPlace.Goomer.Token;
                                txtGoomerStore.Text = marketPlace.Goomer.MerchantId;
                                txtGoomerURL.Text = marketPlace.Goomer.Url;
                                txtGoomerCLIENT_ID.Text = marketPlace.Goomer.Client_ID;
                                txtGoomerCLIENT_SECRET.Text = marketPlace.Goomer.Client_SECRET;
                            }

                            if (marketPlace.IDelivery != null)
                            {
                                txtIDeliveryToken.Text = marketPlace.IDelivery.Token;
                                txtIDeliveryMerchantId.Text = marketPlace.IDelivery.MerchantId;
                                txtIDeliveryURL.Text = marketPlace.IDelivery.Url;
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

                            if (marketPlace.PedreiroDigital != null)
                            {
                                txtPedreiroDigitalToken.Text = marketPlace.PedreiroDigital.Token;
                                txtPedreiroDigitalMerchantId.Text = marketPlace.PedreiroDigital.MerchantId;
                                txtPedreiroDigitalURL.Text = marketPlace.PedreiroDigital.Url;
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

                            if (marketPlace.UberEats != null)
                            {
                                txtUberEatsCLIENT_ID.Text = marketPlace.UberEats.Client_ID;
                                txtUberEatsCLIENT_SECRET.Text = marketPlace.UberEats.Client_SECRET;
                                txtUberEatsMerchantId.Text = marketPlace.UberEats.MerchantId;
                            }
                        }
                    }
                }
            }

            _acconOrders = new List<Accon.Domain.order>();
            gridAccon.DataSource = _acconOrders.ToList();
            gridAccon.Refresh();

            _anotaAiOrders = new List<AnotaAi.Domain.order>();
            gridAnotaAi.DataSource = _anotaAiOrders.ToList();
            gridAnotaAi.Refresh();

            _deliveryAppOrders = new List<DeliveryApp.Domain.order>();
            gridDeliveryApp.DataSource = _deliveryAppOrders.ToList();
            gridDeliveryApp.Refresh();

            _deliveryDiretoOrders = new List<DeliveryDireto.Domain.order>();
            gridDeliveryDireto.DataSource = _deliveryDiretoOrders.ToList();
            gridDeliveryDireto.Refresh();

            _epadocaOrders = new List<Epadoca.Domain.order>();
            gridEpadoca.DataSource = _epadocaOrders.ToList();
            gridEpadoca.Refresh();

            _ifoodOrders = new List<Ifood.Domain.order>();
            gridIfood.DataSource = _ifoodOrders.ToList();
            gridIfood.Refresh();

            _gloriaOrders = new List<GloriaFood.Domain.order>();
            gridGloriaGood.DataSource = _gloriaOrders.ToList();
            gridGloriaGood.Refresh();

            _goomerOrders = new List<Goomer.Domain.order>();
            gridGoomer.DataSource = _goomerOrders.ToList();
            gridGoomer.Refresh();

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

            _pedreiroDigitalOrders = new List<Aipedi.Domain.order>();
            gridPedreiroDigital.DataSource = _pedreiroDigitalOrders.ToList();
            gridPedreiroDigital.Refresh();

            _iDeliveryOrders = new List<IDelivery.Domain.order>();
            gridiDelivery.DataSource = _iDeliveryOrders.ToList();
            gridiDelivery.Refresh();

            _uberOrders = new List<UberEats.Domain.order_result>();
            gridUberEats.DataSource = _uberOrders.ToList();
            gridUberEats.Refresh();

            _aiqfomeOrders = new List<Aiqfome.Domain.orders_result_order>();
            gridAiqfome.DataSource = _aiqfomeOrders.ToList();
            gridAiqfome.Refresh();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            var json = @"{'count':1,'orders':[{'instructions':null,'coupons':[],'tax_list':[],'missed_reason':null,'id':114412588,'total_price':59,'sub_total_price':50,'tax_value':0,'persons':0,'latitude':0,'longitude':0,'client_first_name':'Paulo','client_last_name':'Roberto','client_email':'raffaella_lidiany@outlook.com','client_phone':'+5584987460755','restaurant_name':'Divino Camarão','currency':'BRL','type':'delivery','status':'accepted','source':'mobile_web','pin_skipped':true,'accepted_at':'2020-06-05T21:17:02.000Z','tax_type':'NET','tax_name':'Sales Tax','fulfill_at':'2020-06-05T22:12:02.000Z','reference':null,'restaurant_id':120883,'client_id':7876195,'updated_at':'2020-06-05T21:17:02.000Z','restaurant_phone':'+55 84 2030 7074','restaurant_timezone':'America/Fortaleza','company_account_id':692661,'pos_system_id':13381,'restaurant_key':'bdJYkIErqujJ9qmV3J','restaurant_country':'Brazil','restaurant_city':'Natal','restaurant_state':'Rio Grande do Norte','restaurant_zipcode':'59066-035','restaurant_street':'Av. da Integração, 3491- Candelária','restaurant_latitude':'-5.842292073108915','restaurant_longitude':'-35.22011252883607','restaurant_token':'','gateway_transaction_id':null,'gateway_type':null,'api_version':2,'payment':'CARD','for_later':false,'client_address':'Rua Antônio carolino, n° 100. Residencial Ária, Casa 09, Terminal de ônibus da Conceição , 59074-330, Felipe camarão ','client_address_parts':{'street':'Rua Antônio carolino, n° 100. Residencial Ária, Casa 09','city':'Felipe camarão ','zipcode':'59074-330','more_address':'Terminal de ônibus da Conceição '},'items':[{'id':144328153,'name':'DELIVERY_FEE','total_item_price':9,'price':9,'quantity':1,'instructions':null,'type':'delivery_fee','type_id':243971,'tax_rate':0,'tax_value':0,'parent_id':null,'item_discount':0,'cart_discount_rate':0,'cart_discount':0,'tax_type':'NET','options':[]},{'id':144329357,'name':'Promoção Sexta/ Camarão internacional','total_item_price':50,'price':50,'quantity':1,'instructions':'','type':'item','type_id':4098465,'tax_rate':0,'tax_value':0,'parent_id':null,'item_discount':0,'cart_discount_rate':0,'cart_discount':0,'tax_type':'NET','options':[]}]}]}";
            var t = JsonConvert.DeserializeObject<GloriaFood.Domain.polling>(json);
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

            txtIfoodClient_ID.Enabled = false;
            txtIfoodClient_Secret.Enabled = false;
            txtIfoodMerchantId.Enabled = false;
            txtIfoodMerchantGUID.Enabled = false;

            btnIfoodIniciar.Enabled = false;
            btnIfoodParar.Enabled = true;
            await Task.Run(() => ifood());
        }

        private void ifood()
        {           
            var ifoodService = new Ifood.Service.IfoodService();
            _ifoodOrders = new List<Ifood.Domain.order>();

            try
            {
                var eventTentatives = 0;

                while (btnIfoodParar.Enabled)
                {
                    if (eventTentatives == 0)
                    {
                        var centralizado = rbtIfoodTipoCentralizado.Checked;
                        var authorizationCode = "";
                        var authorizationCodeVerifier = "";
                        var refreshToken = "";
                        if(!centralizado)
                        {
                            authorizationCode = txtIfoodDistribuidoAuthorizationCode.Text;
                            authorizationCodeVerifier = txtIfoodDistribuidoAuthorizationCodeVerificier.Text;
                        }

                        var oathTokenResult = ifoodService.OathToken(centralizado, txtIfoodClient_ID.Text, txtIfoodClient_Secret.Text, authorizationCode, authorizationCodeVerifier, refreshToken);
                        if (oathTokenResult.Success)
                        {
                            _ifoodToken = oathTokenResult.Result.accessToken;
                        }
                        else
                        {
                            MessageBox.Show(oathTokenResult.Message);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(_ifoodToken))
                    {
                        var eventPollingResult = ifoodService.EventPolling(_ifoodToken, txtIfoodMerchantGUID.Text);

                        if (eventPollingResult.Success)
                        {
                            var eventsIds = new List<Ifood.Domain.eventAcknowledgment>();

                            foreach (var poolingEvent in eventPollingResult.Result)
                            {
                                if (poolingEvent.fullCode == Ifood.Domain.PoolingEventStatusCode.PLACED)
                                {
                                    var orderResult = ifoodService.Orders(_ifoodToken, poolingEvent.orderId);
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

                            if (eventsIds.Any())
                            {
                                //var eventAcknowledgmentResult = ifoodService.EventAcknowledgment(_ifoodToken, eventsIds);
                                //if (!eventAcknowledgmentResult.Success)
                                //{
                                //    MessageBox.Show(eventAcknowledgmentResult.Message);
                                //    return;
                                //}
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
            txtIfoodMerchantGUID.Enabled = true;

            btnIfoodIniciar.Enabled = true;
            btnIfoodParar.Enabled = false;
        }

        private void btnIfoodGerarUserCode_Click(object sender, EventArgs e)
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

            if(!rbtIfoodTipoDistribuido.Checked)
            {
                MessageBox.Show("Selecione o tipo distribuido");
                return;
            }            

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.UserCode(txtIfoodClient_ID.Text);
            if(result.Success)
            {
                txtIfoodDistribuidoUrl.Text = result.Result.verificationUrlComplete;
                txtIfoodDistribuidoCode.Text = result.Result.userCode;
            }
            else
            {
                MessageBox.Show(result.Message);
            }

        }

        private void btnIfoodStatus_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.Status(_ifoodToken, txtIfoodMerchantGUID.Text);
            if (result.Success)
            {
                var retorno = result.Result[0];
                if (retorno.state == StatusState.OK)
                {
                    MessageBox.Show("Loja OK");
                }
                else
                {
                    MessageBox.Show($"{retorno.message.title} - {retorno.message.subtitle}");
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
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

            //var ifoodService = new Ifood.Service.IfoodService();
            //var result = ifoodService.OrdersIntegration(_ifoodToken, _ifoodReferenceSelected);
            //if (result.Success)
            //{
            //    MessageBox.Show("Integrado com sucesso");
            //}
            //else
            //{
            //    MessageBox.Show(result.Message);
            //}
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

        private void btnIfoodEmPreparacao_Click(object sender, EventArgs e)
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
            var result = ifoodService.OrdersStarPreparation(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Em preparação");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIfoodPedidoPronto_Click(object sender, EventArgs e)
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
            var result = ifoodService.OrdersReadyToPickup(_ifoodToken, _ifoodReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido Pronto");
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
                _ifoodReferenceSelected = gridIfood.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnIfoodVendas_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
            
            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.Sales(_ifoodToken, txtIfoodMerchantId.Text);
            if (result.Success)
            {
                MessageBox.Show("Pedido rejeitado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
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
            //var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var logarooService = new Logaroo.Service.LogarooService();
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

            //var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            var logarooService = new Logaroo.Service.LogarooService();
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
                    var orderResult = deliveryAppService.Orders(_deliveryAppToken, (byte)DeliveryApp.Enum.OrderStatus.NovoPedido);
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

        private void gridDeliveryApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridDeliveryApp.Rows.Count)
            {
                _deliveryAppReferenceSelected = gridDeliveryApp.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnDeliveryAppBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnDeliveryAppIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_deliveryAppReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new DeliveryAppService();
            var result = service.Order(_deliveryAppToken, _deliveryAppReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryAppSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (btnDeliveryAppIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_deliveryAppReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new DeliveryAppService();
            var result = service.Status(_deliveryAppToken, _deliveryAppReferenceSelected, (byte)DeliveryApp.Enum.OrderStatus.Enviado);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryAppCancelar_Click(object sender, EventArgs e)
        {
            if (btnDeliveryAppIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_deliveryAppReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new DeliveryAppService();
            var result = service.Status(_deliveryAppToken, _deliveryAppReferenceSelected, (byte)DeliveryApp.Enum.OrderStatus.Cancelado);
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
            var result = rappiService.Token(txtRappiClientID.Text, txtRappiSECRET.Text, false);
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
            if (result.Success)
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
            if (string.IsNullOrEmpty(_cinddiSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new CinddiService();
            service.Order(_cinddiToken, _cinddiSelected);
        }

        private void btnCinddiPreparo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_cinddiSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new CinddiService();
            service.Status(_cinddiToken, _cinddiSelected, Cinddi.Enum.OrderStatus.PREPARO);
        }

        private void btnCinddiEntrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_cinddiSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new CinddiService();
            service.Status(_cinddiToken, _cinddiSelected, Cinddi.Enum.OrderStatus.ENTREGA);
        }

        private void btnCinddiFinalizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_cinddiSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new CinddiService();
            service.Status(_cinddiToken, _cinddiSelected, Cinddi.Enum.OrderStatus.FINALIZADO);
        }

        private void btnCinddiCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_cinddiSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new CinddiService();
            service.Status(_cinddiToken, _cinddiSelected, Cinddi.Enum.OrderStatus.CANCELADO);
        }

        #endregion

        #region Delivery Direto

        private void btnDeliveryDiretoIniciar_Click(object sender, EventArgs e)
        {
            onDeliveryDiretoIniciar();
        }

        public async void onDeliveryDiretoIniciar()
        {
            if (string.IsNullOrEmpty(txtDeliveryDiretoUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoMerchandId.Text))
            {
                MessageBox.Show("Campo MerchandId Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            btnDeliveryDiretoIniciar.Enabled = false;
            btnDeliveryDiretoParar.Enabled = true;

            await Task.Run(() => deliveryDireto());
        }

        private void deliveryDireto()
        {
            var service = new DeliveryDiretoService(txtDeliveryDiretoUsuario.Text, txtDeliveryDiretoSenha.Text,
                                txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoToken.Text);

            try
            {
                while (btnDeliveryDiretoParar.Enabled)
                {
                    var orderResult = service.Orders(DateTime.Now);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            foreach (var item in orderResult.Result)
                            {
                                var order = new DeliveryDireto.Domain.order();
                                order.codPedido = item;
                                _deliveryDiretoOrders.Add(order);
                            }
                            WriteGridDeliveryDireto();
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

        private delegate void WritelstGridWriteGridDeliveryDiretoDelegate();
        private void WriteGridDeliveryDireto()
        {
            if (gridDeliveryDireto.InvokeRequired)
            {
                var d = new WritelstGridWriteGridDeliveryDiretoDelegate(WriteGridDeliveryDireto);
                Invoke(d, new object[] { });
            }
            else
            {
                gridDeliveryDireto.DataSource = _deliveryDiretoOrders.ToList();
                gridDeliveryDireto.Refresh();
            }
        }

        void deliveryDiretoParar()
        {
            btnDeliveryDiretoIniciar.Enabled = true;
            btnDeliveryDiretoParar.Enabled = false;
        }

        private void gridDeliveryDireto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridDeliveryDireto.Rows.Count)
            {
                _deliveryDiretoReferenceSelected = gridDeliveryDireto.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnDeliveryDiretoParar_Click(object sender, EventArgs e)
        {
            deliveryDiretoParar();
        }

        private void btnDeliveryDiretoBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnDeliveryDiretoIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_deliveryDiretoReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new DeliveryDiretoService(txtDeliveryDiretoUsuario.Text, txtDeliveryDiretoSenha.Text,
                                txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoToken.Text);
            var result = service.Order(_deliveryDiretoReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoAprovar_Click(object sender, EventArgs e)
        {
            if (btnDeliveryDiretoIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_deliveryDiretoReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new DeliveryDiretoService(txtDeliveryDiretoUsuario.Text, txtDeliveryDiretoSenha.Text,
                                txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoToken.Text);
            var result = service.Status(_deliveryDiretoReferenceSelected, DeliveryDireto.Enum.OrderStatusProcessing.PEDIDO_APROVADO_EM_PRODUCAO);
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

        #region Ai Pedi

        private void btnPedreiroDigitalIniciar_Click(object sender, EventArgs e)
        {
            pedreiroDigitalIniciar();
        }

        private void btnPedreiroDigitalParar_Click(object sender, EventArgs e)
        {
            pedreiroDigitalParar();
        }

        private void btnPedreiroDigitalAprovar_Click(object sender, EventArgs e)
        {
            if (btnPedreiroDigitalIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_pedreiroDigitalReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new AipediService(txtPedreiroDigitalURL.Text,
                                txtPedreiroDigitalMerchantId.Text, txtPedreiroDigitalToken.Text);

            var result = service.Status(_pedreiroDigitalReferenceSelected, (byte)Aipedi.Enum.OrderStatus.Confirmado);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedreiroDigitalEmProducao_Click(object sender, EventArgs e)
        {
            if (btnPedreiroDigitalIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_pedreiroDigitalReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new AipediService(txtPedreiroDigitalURL.Text,
                                txtPedreiroDigitalMerchantId.Text, txtPedreiroDigitalToken.Text);

            var result = service.Status(_pedreiroDigitalReferenceSelected, (byte)Aipedi.Enum.OrderStatus.PedidoPronto);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnPedreiroDigitalEntregue_Click(object sender, EventArgs e)
        {
            if (btnPedreiroDigitalIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            _pedreiroDigitalReferenceSelected = "60d4bb51f4e3964a8fd4fdcd";
            if (string.IsNullOrEmpty(_pedreiroDigitalReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new AipediService(txtPedreiroDigitalURL.Text,
                                txtPedreiroDigitalMerchantId.Text, txtPedreiroDigitalToken.Text);

            var result = service.Status(_pedreiroDigitalReferenceSelected, (byte)Aipedi.Enum.OrderStatus.Entregue);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        public async void pedreiroDigitalIniciar()
        {
            if (string.IsNullOrEmpty(txtPedreiroDigitalToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtPedreiroDigitalURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoMerchandId.Text))
            {
                MessageBox.Show("Campo MerchandId Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            btnPedreiroDigitalIniciar.Enabled = false;
            btnPedreiroDigitalParar.Enabled = true;

            await Task.Run(() => pedreiroDigital());
        }

        private void pedreiroDigital()
        {
            var service = new AipediService(txtPedreiroDigitalURL.Text, txtPedreiroDigitalMerchantId.Text,
                                    txtPedreiroDigitalToken.Text);

            try
            {
                while (btnPedreiroDigitalParar.Enabled)
                {
                    var orderResult = service.Orders((byte)Aipedi.Enum.OrderStatus.Pendente);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            _pedreiroDigitalOrders.AddRange(orderResult.Result.requests);
                            WriteGridPedreiroDigital();
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

        private delegate void WritelstGridWriteGridPedreiroDigitalDelegate();
        private void WriteGridPedreiroDigital()
        {
            if (gridPedreiroDigital.InvokeRequired)
            {
                var d = new WritelstGridWriteGridPedreiroDigitalDelegate(WriteGridPedreiroDigital);
                Invoke(d, new object[] { });
            }
            else
            {
                gridPedreiroDigital.DataSource = _pedreiroDigitalOrders.ToList();
                gridPedreiroDigital.Refresh();
            }
        }

        void pedreiroDigitalParar()
        {
            btnPedreiroDigitalIniciar.Enabled = true;
            btnPedreiroDigitalParar.Enabled = false;
        }

        private void gridPedreiroDigital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridPedreiroDigital.Rows.Count)
            {
                _pedreiroDigitalReferenceSelected = gridPedreiroDigital.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }


        #endregion

        #region IDelivery

        private void btnIDeliveryIniciar_Click(object sender, EventArgs e)
        {
            iDeliveryIniciar();
        }

        private void btnIDeliveryParar_Click(object sender, EventArgs e)
        {
            iDeliveryParar();
        }

        private void btnIDeliveryAprovar_Click(object sender, EventArgs e)
        {
            if (btnIDeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_iDeliveryReferenceSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new IDeliveryService(txtIDeliveryURL.Text, txtIDeliveryMerchantId.Text,
                                    txtIDeliveryToken.Text);
            var result = service.Status(Convert.ToInt32(_iDeliveryReferenceSelected), (int)IDelivery.Enum.OrderStatus.Aprovado);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        public async void iDeliveryIniciar()
        {
            if (string.IsNullOrEmpty(txtIDeliveryToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIDeliveryURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtIDeliveryMerchantId.Text))
            {
                MessageBox.Show("Campo MerchandId Obrigatório");
                return;
            }


            btnIDeliveryIniciar.Enabled = false;
            btnIDeliveryParar.Enabled = true;

            await Task.Run(() => iDelivery());
        }

        private void iDelivery()
        {
            var service = new IDeliveryService(txtIDeliveryURL.Text, txtIDeliveryMerchantId.Text,
                                    txtIDeliveryToken.Text);

            try
            {
                while (btnIDeliveryParar.Enabled)
                {
                    var orderResult = service.Orders(true);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            _iDeliveryOrders.AddRange(orderResult.Result);
                            WriteGridiDelivery();
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

        private delegate void WritelstGridWriteGridiDeliveryDelegate();
        private void WriteGridiDelivery()
        {
            if (gridiDelivery.InvokeRequired)
            {
                var d = new WritelstGridWriteGridiDeliveryDelegate(WriteGridiDelivery);
                Invoke(d, new object[] { });
            }
            else
            {
                gridiDelivery.DataSource = _iDeliveryOrders.ToList();
                gridiDelivery.Refresh();
            }
        }

        void iDeliveryParar()
        {
            btnIDeliveryIniciar.Enabled = true;
            btnIDeliveryParar.Enabled = false;
        }

        private void gridiDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridiDelivery.Rows.Count)
            {
                _iDeliveryReferenceSelected = gridiDelivery.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        #endregion

        #region AtivMob

        private void btnAtivMobCriarPedido_Click(object sender, EventArgs e)
        {
            var order = new AtivMob.Domain.order();
            order.id = new Random().Next().ToString();
            order.sale = new AtivMob.Domain.sale();
            order.sale.place = new AtivMob.Domain.place();
            order.sale.place.description = AtivMob.Enum.sale_place.FISICO;

            var package = new AtivMob.Domain.packages();
            package.id = order.id;
            //package.origin = new AtivMob.Domain.origin();

            //package.origin.pickupPlace = new AtivMob.Domain.pickupPlace();
            //package.origin.pickupPlace.store = new AtivMob.Domain.store();
            //package.origin.pickupPlace.store.id = 485;

            //package.origin.phones.Add(new AtivMob.Domain.phones { number = 87704779, type = (string)AtivMob.Enum.phone_type.CELLPHONE });
            //package.origin.address = new AtivMob.Domain.address();
            //package.origin.address.city = "Fortaleza";
            //package.origin.address.complement = "4º Etapa";
            //package.origin.address.country = "Brasil";
            //package.origin.address.district = "Conjunto Ceará";
            //package.origin.address.ibgeCode = 10545;
            //package.origin.address.number = "47";
            //package.origin.address.state = "CE";
            //package.origin.address.street = "Rua 1014";
            //package.origin.address.zipcode = "60545578";

            package.deadline = new AtivMob.Domain.deadline();
            package.deadline.date = DateTime.Now.AddHours(2).ToString("yyyy-MM-dd HH:mm");

            package.destination = new AtivMob.Domain.destination();
            package.destination.phones.Add(new AtivMob.Domain.phones { number = 87704779, type = (string)AtivMob.Enum.phone_type.CELLPHONE });
            package.destination.address = new AtivMob.Domain.address();
            package.destination.address.city = "Fortaleza";
            package.destination.address.complement = "";
            package.destination.address.country = "Brasil";
            package.destination.address.district = "Genibaú";
            package.destination.address.ibgeCode = 10545;
            package.destination.address.number = "58";
            package.destination.address.state = "CE";
            package.destination.address.street = "Rua Dom Lustosa";
            package.destination.address.zipcode = "";

            package.destination.deliveryPlace = new AtivMob.Domain.deliveryPlace();
            package.destination.deliveryPlace.customer = new AtivMob.Domain.customer();
            package.destination.deliveryPlace.customer.name = "Henrique";
            package.destination.deliveryPlace.customer.cpf = "7458787888";

            package.invoice = new AtivMob.Domain.invoice();
            package.invoice.number = 123;
            package.invoice.issueDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            package.deadline = new AtivMob.Domain.deadline();
            package.deadline.date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm");

            package.shipping = new AtivMob.Domain.shipping();
            package.shipping.cost = 10;

            var volume1 = new AtivMob.Domain.volumes();
            volume1.products.Add(new AtivMob.Domain.products { description = "Coca-Cola", price = 5 });
            volume1.products.Add(new AtivMob.Domain.products { description = "Coxinha", price = 10 });

            package.volumes.Add(volume1);

            order.packages.Add(package);

            var service = new AtivMob.Service.AtivMobService(txtAtivMobURL.Text, txtAtivMobMerchantId.Text, txtAtivMobToken.Text);
            var result = service.Order(order);
            if (result.Success)
            {
                MessageBox.Show("Criado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAtivMobStatus_Click(object sender, EventArgs e)
        {
            var service = new AtivMob.Service.AtivMobService(txtAtivMobURL.Text, txtAtivMobMerchantId.Text, txtAtivMobToken.Text);
            var result = service.ConsultarEventos();
            if (result.Success)
            {
                var lista = new List<string>();
                foreach (var item in result.Result.events)
                {
                    lista.Add(item.event_id);
                }

                if (lista.Any())
                {
                    var resultProcessarEventos = service.ProcessarEventos(lista);
                    if (resultProcessarEventos.Success)
                    {
                        MessageBox.Show("Status processados ok");
                    }
                }
                else
                {
                    MessageBox.Show("Status ok");
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Goomer
        private void btnGoomerIniciar_Click(object sender, EventArgs e)
        {
            goomerIniciar();
        }

        private void btnGoomerParar_Click(object sender, EventArgs e)
        {
            goomerParar();
        }

        private void btnGoomerLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGoomerURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtGoomerStore.Text))
            {
                MessageBox.Show("Campo Store Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtGoomerToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtGoomerCLIENT_ID.Text))
            {
                MessageBox.Show("Campo Client_ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtGoomerCLIENT_SECRET.Text))
            {
                MessageBox.Show("Campo Client_SECRET Obrigatório");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.OathToken(txtGoomerToken.Text, txtGoomerStore.Text, txtGoomerCLIENT_SECRET.Text, txtGoomerCLIENT_ID.Text);
            if (result.Success)
            {
                txtGoomerAuthToken.Text = result.Result.authToken;
                txtGoomerRefreshToken.Text = result.Result.refreshToken;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void btnGoomerRefreshToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGoomerRefreshToken.Text))
            {
                MessageBox.Show("Campo Refresh Token Obrigatório");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.RefreshToken(txtGoomerRefreshToken.Text);
            if (result.Success)
            {
                txtGoomerAuthToken.Text = result.Result.authToken;
                txtGoomerRefreshToken.Text = result.Result.refreshToken;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void btnGoomerVerPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Order(txtGoomerAuthToken.Text, _goomerSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerAceitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Accept(txtGoomerAuthToken.Text, _goomerSelected);
            if (result.Success)
            {
                MessageBox.Show("Aceito");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerRejeitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Deny(txtGoomerAuthToken.Text, _goomerSelected);
            if (result.Success)
            {
                MessageBox.Show("Rejeitado");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Cancel(txtGoomerAuthToken.Text, _goomerSelected);
            if (result.Success)
            {
                MessageBox.Show("Cancelado");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerEmPreparo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Update(txtGoomerAuthToken.Text, _goomerSelected, Goomer.Enum.ORDER_STATUS.PREPARING);
            if (result.Success)
            {
                MessageBox.Show("Em preparo");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Update(txtGoomerAuthToken.Text, _goomerSelected, Goomer.Enum.ORDER_STATUS.FINISHED);
            if (result.Success)
            {
                MessageBox.Show("Retirada");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnGoomerSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_goomerSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.Update(txtGoomerAuthToken.Text, _goomerSelected, Goomer.Enum.ORDER_STATUS.DELIVERYNG);
            if (result.Success)
            {
                MessageBox.Show("Saiu para entrega");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridGoomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridGoomer.Rows.Count)
            {
                _goomerSelected = gridGoomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        void goomerParar()
        {
            btnGoomerIniciar.Enabled = true;
            btnGoomerParar.Enabled = false;
        }

        private delegate void WritelstGridWriteGridGoomerDelegate();
        private void WriteGridGoomer()
        {
            if (gridGoomer.InvokeRequired)
            {
                var d = new WritelstGridWriteGridGoomerDelegate(WriteGridGoomer);
                Invoke(d, new object[] { });
            }
            else
            {
                gridGoomer.DataSource = _goomerOrders.ToList();
                gridGoomer.Refresh();
            }
        }

        public async void goomerIniciar()
        {
            if (string.IsNullOrEmpty(txtGoomerAuthToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            btnGoomerIniciar.Enabled = false;
            btnGoomerParar.Enabled = true;

            await Task.Run(() => goomer());
        }

        private void goomer()
        {
            var service = new GoomerService(txtGoomerURL.Text);

            try
            {
                while (btnGoomerParar.Enabled)
                {
                    var orderResult = service.Orders(txtGoomerAuthToken.Text);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            foreach (var item in orderResult.Result.orders)
                                _goomerOrders.Add(new Goomer.Domain.order { id = item });
                            WriteGridGoomer();
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

        #endregion

        #region Accon
        private void btnAcconIniciar_Click(object sender, EventArgs e)
        {
            acconIniciar();
        }

        private void btnAcconParar_Click(object sender, EventArgs e)
        {
            acconParar();
        }

        private void btnAcconIntegrado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_acconSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new AcconService();
            var result = service.OrdersStatus(txtAcoonToken.Text, txtAcconRede.Text, _acconSelected);
            if (result.Success)
            {
                MessageBox.Show("Aceito");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridAccon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridAccon.Rows.Count)
            {
                _acconSelected = gridAccon.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnAcconLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAcconUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtAcconSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtAcconRede.Text))
            {
                MessageBox.Show("Campo Rede Obrigatório");
                return;
            }

            var service = new AcconService();
            var result = service.OathToken(txtAcconUsuario.Text, txtAcconSenha.Text, txtAcconRede.Text);
            if (result.Success)
            {
                txtAcoonToken.Text = result.Result.token;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        void acconParar()
        {
            btnAcconIniciar.Enabled = true;
            btnAcconParar.Enabled = false;
        }

        private delegate void WritelstGridWriteGridAcconDelegate();
        private void WriteGridAccon()
        {
            if (gridAccon.InvokeRequired)
            {
                var d = new WritelstGridWriteGridAcconDelegate(WriteGridAccon);
                Invoke(d, new object[] { });
            }
            else
            {
                gridAccon.DataSource = _acconOrders.ToList();
                gridAccon.Refresh();
            }
        }

        public async void acconIniciar()
        {
            if (string.IsNullOrEmpty(txtAcoonToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            btnAcconIniciar.Enabled = false;
            btnAcconParar.Enabled = true;

            await Task.Run(() => accon());
        }

        private void accon()
        {
            var service = new AcconService();

            try
            {
                while (btnAcconParar.Enabled)
                {
                    var orderResult = service.Orders(txtAcoonToken.Text, txtAcconRede.Text);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            _acconOrders.AddRange(orderResult.Result);
                            WriteGridAccon();
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


        #endregion

        #region Uber Eats
        private void btnUberEatsIniciar_Click(object sender, EventArgs e)
        {
            uberIniciar();
        }

        private void btnUberEatsParar_Click(object sender, EventArgs e)
        {
            uberParar();
        }

        private void btnUberEatsLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUberEatsCLIENT_ID.Text))
            {
                MessageBox.Show("Campo CLIENT_ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtUberEatsCLIENT_SECRET.Text))
            {
                MessageBox.Show("Campo CLIENT_SECRET Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtUberEatsMerchantId.Text))
            {
                MessageBox.Show("Campo MerchantId Obrigatório");
                return;
            }

            var service = new UberEatsService();
            var result = service.OathToken(txtUberEatsCLIENT_ID.Text, txtUberEatsCLIENT_SECRET.Text);
            if (result.Success)
            {
                txtUberEatsTOken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void btnUberEatsBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uberEaTSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new UberEatsService();
            var result = service.Order(txtUberEatsTOken.Text, _uberEaTSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnUberEatsAprovar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uberEaTSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new UberEatsService();
            var result = service.Accept(txtUberEatsTOken.Text, _uberEaTSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnUberEatsRejeitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uberEaTSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new UberEatsService();
            var result = service.Deny(txtUberEatsTOken.Text, _uberEaTSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnUberEatsCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uberEaTSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new UberEatsService();
            var result = service.Cancel(txtUberEatsTOken.Text, _uberEaTSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridUberEats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridUberEats.Rows.Count)
            {
                _uberEaTSSelected = gridUberEats.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        void uberParar()
        {
            btnUberEatsIniciar.Enabled = true;
            btnUberEatsParar.Enabled = false;
        }

        private delegate void WritelstGridWriteGridUberDelegate();
        private void WriteGridUber()
        {
            if (gridUberEats.InvokeRequired)
            {
                var d = new WritelstGridWriteGridUberDelegate(WriteGridUber);
                Invoke(d, new object[] { });
            }
            else
            {
                gridUberEats.DataSource = _uberOrders.ToList();
                gridUberEats.Refresh();
            }
        }

        public async void uberIniciar()
        {
            if (string.IsNullOrEmpty(txtUberEatsTOken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            btnUberEatsIniciar.Enabled = false;
            btnUberEatsParar.Enabled = true;

            await Task.Run(() => uber());
        }

        private void uber()
        {
            var service = new UberEatsService();

            try
            {
                while (btnUberEatsParar.Enabled)
                {
                    var orderResult = service.Orders(txtUberEatsTOken.Text, txtUberEatsMerchantId.Text);
                    if (orderResult.Success)
                    {
                        _uberOrders.AddRange(orderResult.Result.orders.ToList());
                        WriteGridUber();
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

        #endregion

        #region Aiqfome

        private const string USER_AGENT = "izzyway (henrique@izzyway.com.br)";

        private void btnAiqfomeLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAiqfomeUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtAiqfomeSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtAiqfomeAgente.Text))
            {
                MessageBox.Show("Campo MerchantId Obrigatório");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.Token(txtAiqfomeUsuario.Text, txtAiqfomeSenha.Text);
            if (result.Success)
            {
                txtAiqfomeToken.Text = result.Result.data.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void btnAiqfomeIniciar_Click(object sender, EventArgs e)
        {
            aiqfomeIniciar();
        }

        private void btnAiqfomeParar_Click(object sender, EventArgs e)
        {
            aiqfomeParar();
        }

        void aiqfomeParar()
        {
            btnAiqfomeIniciar.Enabled = true;
            btnAiqfomeParar.Enabled = false;
        }

        private delegate void WritelstGridWriteGridAiqfomeDelegate();
        private void WriteGridAiqfome()
        {
            if (gridAiqfome.InvokeRequired)
            {
                var d = new WritelstGridWriteGridAiqfomeDelegate(WriteGridAiqfome);
                Invoke(d, new object[] { });
            }
            else
            {
                gridAiqfome.DataSource = _aiqfomeOrders.ToList();
                gridAiqfome.Refresh();
            }
        }

        public async void aiqfomeIniciar()
        {
            if (string.IsNullOrEmpty(txtAiqfomeToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            btnAiqfomeIniciar.Enabled = false;
            btnAiqfomeParar.Enabled = true;

            await Task.Run(() => aiqfome());
        }

        private void aiqfome()
        {
            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);

            try
            {
                while (btnAiqfomeParar.Enabled)
                {
                    var orderResult = service.Orders(txtAiqfomeToken.Text);
                    if (orderResult.Success)
                    {
                        _aiqfomeOrders.AddRange(orderResult.Result.data.ToList());
                        WriteGridAiqfome();
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

        private void btnAiqfomeAbrir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAiqfomeToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.Open(txtAiqfomeToken.Text);
            if (result.Success && result.Result.data.status == Aiqfome.Enum.StoreStatus.OPEN)
            {
                MessageBox.Show("Aberto");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAiqfomeFechar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAiqfomeToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.Close(txtAiqfomeToken.Text);
            if (result.Success && result.Result.data.status == Aiqfome.Enum.StoreStatus.CLOSED)
            {
                MessageBox.Show("Fechado");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridAiqfome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridAiqfome.Rows.Count)
            {
                _aiqfomeSSelected = gridAiqfome.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnAiqfomeBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_aiqfomeSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.Order(txtAiqfomeToken.Text, _aiqfomeSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAiqfomeIntegrado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_aiqfomeSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.MarkAsRead(txtAiqfomeToken.Text, _aiqfomeSSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAiqfomePedidoPronto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_aiqfomeSSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new AiqfomeService(txtAiqfomeURL.Text, txtAiqfomeAgente.Text, txtAiqfomeAuthorization.Text, USER_AGENT);
            var result = service.MarkAsReady(txtAiqfomeToken.Text, _aiqfomeSSelected);
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

        #region Epadoca

        private void btnEpadocaLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEpadocaUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtEpadocaSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.Token(txtEpadocaUsuario.Text, txtEpadocaSenha.Text);
            if (result.Success)
            {
                txtEpadocaToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void btnEpadocaIniciar_Click(object sender, EventArgs e)
        {
            epadocaIniciar();
        }

        private void btnEpadocaParar_Click(object sender, EventArgs e)
        {
            epadocaParar();
        }

        private void gridEpadoca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridEpadoca.Rows.Count)
            {
                _epadocaSelected = gridEpadoca.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        void epadocaParar()
        {
            btnEpadocaIniciar.Enabled = true;
            btnEpadocaParar.Enabled = false;
        }

        private delegate void WritelstGridWriteGridEpadocaDelegate();
        private void WriteGridEpadoca()
        {
            if (gridEpadoca.InvokeRequired)
            {
                var d = new WritelstGridWriteGridEpadocaDelegate(WriteGridEpadoca);
                Invoke(d, new object[] { });
            }
            else
            {
                gridEpadoca.DataSource = _epadocaOrders.ToList();
                gridEpadoca.Refresh();
            }
        }

        public async void epadocaIniciar()
        {
            if (string.IsNullOrEmpty(txtEpadocaToken.Text))
            {
                MessageBox.Show("Faça o login");
                return;
            }

            if (string.IsNullOrEmpty(txtEpadocaMerchantId.Text))
            {
                MessageBox.Show("Digite o merchantId");
                return;
            }

            btnEpadocaIniciar.Enabled = false;
            btnEpadocaParar.Enabled = true;

            await Task.Run(() => epadoca());
        }

        private void epadoca()
        {
            _epadocaOrders = new List<Epadoca.Domain.order>();
            WriteGridEpadoca();

            var service = new EpadocaService(txtEpadocaUrl.Text);

            try
            {
                while (btnEpadocaParar.Enabled)
                {
                    var orderResult = service.Orders(txtEpadocaToken.Text, txtEpadocaMerchantId.Text);
                    if (orderResult.Success)
                    {
                        if (orderResult.Result != null)
                        {
                            _epadocaOrders.AddRange(orderResult.Result);
                            WriteGridEpadoca();
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

        private void btnEpadocaPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_epadocaSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.Order(txtEpadocaToken.Text, _epadocaSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaAceitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_epadocaSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.Aceitar(txtEpadocaToken.Text, _epadocaSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaSaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_epadocaSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.SaiuParaEntrega(txtEpadocaToken.Text, _epadocaSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_epadocaSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.Entregue(txtEpadocaToken.Text, _epadocaSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaDisponivelParaRetirada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_epadocaSelected))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.DisponivelParaRetirada(txtEpadocaToken.Text, _epadocaSelected);
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

        
    }
}
