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
using Deeliv.Enum;
using Deeliv.Service;
using Rappi.Service;
using QueroDelivery.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Woocommerce.Service;
using UberEats.Service;
using PixCommerce.Service;
using System.Runtime.CompilerServices;
using MultiPedido.Service;
using Epadoca.Domain;
using Simbora.Service;
using Simbora.Enum;
using Simbora.Domain;
using EuFalo.Service;
using EuFalo.Domain;
using DegustaAi.Service;
using Agilizone.Service;
using FixeCRM.Domain;
using SelfBuyMe.Service;
using Fidelizi.Service;
using Repediu.Service;
using CardapioWeb.Service;
using FixeCRM.Service;
using Repediu.Domain;
using DeliveryVip.Service;
using DegustaAi.Domain;
using Wedo.Service;
using BigFish.Service;
using VMarket.Service;
using VMarket.Domain;
using Tray.Service;

namespace Example
{
    public partial class Form1 : Form
    {
        #region Variaveis

        private const string TELEFONE = "85987704779";
        private const string CPF = "86162484041";

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
        private List<Deeliv.Domain.pedido> _pedzapPedidos { get; set; }
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

        private string _b2foodSelected { get; set; }
        private string _b2FoodToken { get; set; }
        private List<B2Food.Domain.pedido> _b2foodOrders { get; set; }

        private string _bigdimSelected { get; set; }
        private string _bigdimToken { get; set; }
        private List<Bigdim.Domain.pedido> _bigdimOrders { get; set; }

        private string _americanasSelected { get; set; }
        private List<Americanas.Domain.orders> _americanasOrders { get; set; }

        private string _servitSelected { get; set; }
        private List<Servit.Domain.evento> _servitEvents { get; set; }

        private string _jotajaSelected { get; set; }
        private List<JotaJa.Domain.order> _jotajaOrders { get; set; }

        private string _queroDeliveryToken { get; set; }
        private string _queroDeliveryPlaceId { get; set; }
        private string _queroDeliverySelected { get; set; }
        private List<QueroDelivery.Domain.orders> _queroDeliveryOrders { get; set; }

        private List<Woocommerce.Domain.order> _woocommerceOrders { get; set; }
        private int _woocommerceId { get; set; }

        private List<PixCommerce.Domain.orders> _pixCommerceOrders { get; set; }
        private string _pixCommerceId { get; set; }

        private List<MultiPedido.Domain.order> _multiPedidoOrders { get; set; }
        private string _multiPedidoId { get; set; }

        private List<DegustaAi.Domain.pedido> _iorion9Orders { get; set; }
        private string _iorion19Id { get; set; }

        private List<CardapioWeb.Domain.responseOrders> _cardapioWebOrders { get; set; }
        private string _cardapioWebId { get; set; }

        private List<DeliveryVip.Domain.eventPooling> _deliveryVipOrders { get; set; }
        private string _deliveryVipId { get; set; }

        private List<Wedo.Domain.responsePoolingData> _WedoOrders { get; set; }
        private string _wedoId { get; set; }

        private List<BigFish.Domain.Order> _bigFishOrders { get; set; }
        private string _bigFishId { get; set; }
        private string _bigFishClientDocument { get; set; }


        private List<Tray.Domain.order> _trayOrders { get; set; }
        private string _trayId { get; set; }
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

                            if (marketPlace.Agilizone != null)
                            {
                                txtAgilizoneClientID.Text = marketPlace.Agilizone.Usuario;
                                txtAgilizoneClientSecret.Text = marketPlace.Agilizone.Senha;
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

                            if (marketPlace.DeliveryVip != null)
                            {
                                txtDeliveryVipMerchant.Text = marketPlace.DeliveryVip.MerchantId;
                                txtDeliveryVipClientId.Text = marketPlace.DeliveryVip.Usuario;
                                txtDeliveryVipSecret.Text = marketPlace.DeliveryVip.Senha;
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

                            if (marketPlace.QueroDelivery != null)
                            {
                                txtQuerodeliveryToken.Text = marketPlace.QueroDelivery.Token;
                                txtQuerodeliveryPlaceID.Text = marketPlace.QueroDelivery.PlaceId;
                            }

                            if (marketPlace.Iorion9 != null)
                            {
                                txtIorionToken.Text = marketPlace.Iorion9.Token;
                                txtIorionURL.Text = marketPlace.Iorion9.Url;
                                txtDegustaAiEmail.Text = marketPlace.Iorion9.Usuario;
                                txtDegustaAiSenha.Text = marketPlace.Iorion9.Senha;
                            }

                            if (marketPlace.Wedo != null)
                            {
                                txtWedoToken.Text = marketPlace.Wedo.Token;
                            }

                            if (marketPlace.Tray != null)
                            {
                                txtTrayKey.Text = marketPlace.Tray.Client_ID;
                                txtTraySecret.Text = marketPlace.Tray.Client_SECRET;
                                txtTrayCode.Text = marketPlace.Tray.MerchantId;
                                txtTrayURL.Text = marketPlace.Tray.Url;
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

            _pedzapPedidos = new List<Deeliv.Domain.pedido>();

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

            _bigdimOrders = new List<Bigdim.Domain.pedido>();
            gridBigdim.DataSource = _bigdimOrders.ToList();
            gridBigdim.Refresh();

            _b2foodOrders = new List<B2Food.Domain.pedido>();
            gridB2Food.DataSource = _b2foodOrders.ToList();
            gridB2Food.Refresh();

            _americanasOrders = new List<Americanas.Domain.orders>();
            gridAmericanas.DataSource = _americanasOrders.ToList();
            gridAmericanas.Refresh();

            _servitEvents = new List<Servit.Domain.evento>();
            gridServit.DataSource = _servitEvents.ToList();
            gridServit.Refresh();

            _jotajaOrders = new List<JotaJa.Domain.order>();
            gridJotaJa.DataSource = _jotajaOrders.ToList();
            gridJotaJa.Refresh();

            _queroDeliveryOrders = new List<QueroDelivery.Domain.orders>();
            gridQuerodelivery.DataSource = _queroDeliveryOrders.ToList();
            gridQuerodelivery.Refresh();

            _woocommerceOrders = new List<Woocommerce.Domain.order>();
            gridWoocommerce.DataSource = _woocommerceOrders.ToList();
            gridWoocommerce.Refresh();

            _pixCommerceOrders = new List<PixCommerce.Domain.orders>();
            gridPixCommerce.DataSource = _pixCommerceOrders.ToList();
            gridPixCommerce.Refresh();

            _pixCommerceId = "648e2ce2089c5def4b258cc2";

            _multiPedidoOrders = new List<MultiPedido.Domain.order>();
            gridMultiPedido.DataSource = _multiPedidoOrders.ToList();
            gridMultiPedido.Refresh();

            _iorion9Orders = new List<DegustaAi.Domain.pedido>();
            gridIorion.DataSource = _iorion9Orders.ToList();
            gridIorion.Refresh();

            _deliveryVipOrders = new List<DeliveryVip.Domain.eventPooling>();
            gridDeliveryVip.DataSource = _deliveryVipOrders.ToList();
            gridDeliveryVip.Refresh();

            _bigFishOrders = new List<BigFish.Domain.Order>();
            gridBigFish.DataSource = _bigFishOrders.ToList();
            gridBigFish.Refresh();
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
                        if (!centralizado)
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

            if (!rbtIfoodTipoDistribuido.Checked)
            {
                MessageBox.Show("Selecione o tipo distribuido");
                return;
            }

            var ifoodService = new Ifood.Service.IfoodService();
            var result = ifoodService.UserCode(txtIfoodClient_ID.Text);
            if (result.Success)
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
            //var result = ifoodService.Sales(_ifoodToken, txtIfoodMerchantId.Text);
            //if (result.Success)
            //{
            //    MessageBox.Show("Pedido rejeitado com sucesso");
            //}
            //else
            //{
            //    MessageBox.Show(result.Message);
            //}
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

        //private string _urlLogarooDesenvolvimento = "https://api.dev.logaroo.com.br/v1/";
        private string _urlLogarooDesenvolvimento = "https://api.alpha.logaroo.com.br/v1/";
        private void btnLogarooLogin_Click(object sender, EventArgs e)
        {
            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            //var logarooService = new Logaroo.Service.LogarooService();
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
            item1.obs = "com gelo";
            pedido.items.Add(item1);

            var item2 = new Logaroo.Domain.orderitem();
            item2.name = "teste2";
            item2.quantity = 2;
            item2.cod = "2";
            item2.seq = 2;
            item2.obs = "";
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
            var pedZapService = new DeelivService();

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

            var pedzapService = new Deeliv.Service.DeelivService();
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

            var pedzapService = new Deeliv.Service.DeelivService();
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

            var pedzapService = new Deeliv.Service.DeelivService();
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

            var pedzapService = new Deeliv.Service.DeelivService();
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

            var pedzapService = new Deeliv.Service.DeelivService();
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

            var pedzapService = new Deeliv.Service.DeelivService();
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

        private void btnMeuCardapioAiTestarJSON_Click(object sender, EventArgs e)
        {
            var json = "{'sucesso':true,'data':{'cliente':{'id':1165643,'nome':'Cristiele Soares','cpf':null,'telefone':'88988464962'},'operador':{'papeis':[],'operador':false,'ativo':false,'id':1457,'email':'alberione_gomes@hotmail.com','nome':'Alberas'},'itens':[{'id':4323684,'nome':'ARROZ COM STROGONOFF DE FRANGO','qtde':2,'valor':12,'total':24,'codigoPDV':'205','produto':{'id':28072,'nome':'ARROZ COM STROGONOFF DE FRANGO','preco':12,'descricao':'SERVE ATE 1 PESSOA ( NÃO FAZEMOS ALTERAÇÕES) ','mensagemPedido':null,'imagens':null,'catalogo':{'nome':null,'categorias':[{'id':2800,'nome':'GUARNIÇÕES','impressoras':[],'codigoPdv':null,'nivel':1,'posicao':2,'disponivel':true}],'ativo':true,'precoPorEmpresa':false,'disponibilidadePorEmpresa':false,'criacao':'2022-12-22T20:30:36.454Z','atualizacao':'2022-12-22T20:30:36.454Z','id':425},'exibirNoSite':false,'disponibilidade':0,'exibirPrecoSite':false,'categoria':{'id':2800,'nome':'GUARNIÇÕES','impressoras':[],'codigoPdv':null,'nivel':1,'posicao':2,'disponivel':true},'tipoDeVenda':'Unidade','unidadeMedida':null,'valorInicial':null,'incremento':1,'disponivelParaDelivery':true,'disponivelNaMesa':false,'exibirPrecoNoCardapio':true,'sku':null,'qtdeMinima':1,'camposAdicionais':[{'nome':'EMBALAGEM','obrigatorio':true,'tipo':'escolha-simples','opcoesDisponiveis':[],'entidade':'produto','compartilhado':false,'classe':'escolha-simples-produto','id':180204,'produtos':[{'id':28072,'nome':null,'preco':null,'descricao':'','mensagemPedido':null,'imagens':null,'catalogo':null,'exibirNoSite':false,'disponibilidade':null,'exibirPrecoSite':false,'categoria':null,'tipoDeVenda':null,'unidadeMedida':null,'valorInicial':null,'incremento':1,'disponivelParaDelivery':true,'disponivelNaMesa':true,'exibirPrecoNoCardapio':true,'sku':null,'qtdeMinima':1,'camposAdicionais':[],'horarios':[],'turnos':[],'tipo':'normal','naoAceitaCupom':false,'naoSincronizar':false,'ehBrinde':false,'categoriasAcima':[],'temEstoque':true}],'tipoDeCobranca':'SOMA','ordem':0}],'horarios':[],'turnos':[],'tipo':'normal','naoAceitaCupom':false,'naoSincronizar':false,'ehBrinde':false,'categoriasAcima':[],'temEstoque':true,'empresa':{'horariosFuncionamento':[],'pausasProgramadas':[],'camposExtras':[],'formasDeEntrega':[],'modulos':[],'categorias':[],'formasDePagamento':[],'identificadorMesa':'Mesa','rede':'','valorTaxaServico':10,'fusoHorario':-3,'dark':false,'darkPrincipal':false,'agruparAdicionais':false,'bloqueada':false,'meioDeEnvio':'Mock','aceitarPedidoAutomatico':true,'id':425,'catalogo':{'nome':null,'categorias':[{'id':2800,'nome':'GUARNIÇÕES','impressoras':[],'codigoPdv':null,'nivel':1,'posicao':2,'disponivel':true}],'ativo':true,'precoPorEmpresa':false,'disponibilidadePorEmpresa':false,'criacao':'2022-12-22T20:30:36.454Z','atualizacao':'2022-12-22T20:30:36.454Z','id':425}},'ordem':23,'codigoPdv':'205','produtoNaEmpresa':{'empresa':{'horariosFuncionamento':[],'pausasProgramadas':[],'camposExtras':[],'formasDeEntrega':[],'modulos':[],'categorias':[{'id':2800,'nome':'GUARNIÇÕES','impressoras':[],'codigoPdv':null,'nivel':1,'posicao':2,'disponivel':true}],'formasDePagamento':[],'identificadorMesa':'Mesa','rede':'','valorTaxaServico':10,'fusoHorario':-3,'dark':false,'darkPrincipal':false,'agruparAdicionais':false,'bloqueada':false,'meioDeEnvio':'Mock','aceitarPedidoAutomatico':true,'catalogo':{'nome':null,'categorias':[{'id':2800,'nome':'GUARNIÇÕES','impressoras':[],'codigoPdv':null,'nivel':1,'posicao':2,'disponivel':true}],'ativo':true,'precoPorEmpresa':false,'disponibilidadePorEmpresa':false,'criacao':'2022-12-22T20:30:36.455Z','atualizacao':'2022-12-22T20:30:36.455Z'}},'preco':null,'disponibilidade':null,'temEstoque':true,'exibirPrecoSite':true,'exibirPrecoNoCardapio':true,'disponivelNaMesa':true,'disponivelParaDelivery':true,'novoPreco':null,'destaque':null,'mensagemPedido':null}},'observacao':'','unidade':'','sabores':[],'adicionais':{}}],'pagamentos':[{'id':1908514,'formaDePagamento':'dinheiro','online':false,'trocoPara':0,'levarTroco':false,'valor':24}],'codigo':'27090','horario':'2022-12-22T20:29:47.000Z','statusOrdem':0,'subvalor':24,'desconto':0,'taxaEntrega':0,'total':24,'pago':false,'cancelado':false,'podeEditar':true,'finalizado':false,'formaDeEntrega':'Retirar','retirar':true,'aguardandoPagamentoOnline':false,'foiPagoOnline':false,'status':'Novo'}}";
            var dados = JsonConvert.DeserializeObject<MeuCardapioAi.Domain.order_result>(json);
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
                    var storeId = txtRappiStoreId.Text;

                    var orderResult = rappiService.Orders(_rappiToken, storeId);
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

        private void btnDeliveryDiretoLogin_Click(object sender, EventArgs e)
        {
            var service = new DeliveryDiretoService();
            var result = service.OAuthToken(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoClientSecret.Text, txtDeliveryDiretoUsuario.Text, txtDeliveryDiretoSenha.Text);
            if (result.Success)
            {
                txtDeliveryDiretoToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoIniciar_Click(object sender, EventArgs e)
        {
            onDeliveryDiretoIniciar();
        }

        public async void onDeliveryDiretoIniciar()
        {

            if (string.IsNullOrEmpty(txtDeliveryDiretoClientSecret.Text))
            {
                MessageBox.Show("Campo Client Secret Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoClientId.Text))
            {
                MessageBox.Show("Campo Client ID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryDiretoMerchandId.Text))
            {
                MessageBox.Show("Campo MerchandId Obrigatório");
                return;
            }

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

            btnDeliveryDiretoIniciar.Enabled = false;
            btnDeliveryDiretoParar.Enabled = true;

            await Task.Run(() => deliveryDireto());
        }

        private void deliveryDireto()
        {
            var service = new DeliveryDiretoService();

            try
            {
                while (btnDeliveryDiretoParar.Enabled)
                {
                    var orderResult = service.Orders(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text);
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result.data.orders)
                        {
                            if (!_deliveryDiretoOrders.Any(a => a.id == item.id))
                                _deliveryDiretoOrders.Add(item);
                        }

                        WriteGridDeliveryDireto();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Message);
                        return;
                    }

                    Thread.Sleep(15000);
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
                _deliveryDiretoReferenceSelected = gridDeliveryDireto.Rows[e.RowIndex].Cells[2].Value.ToString();
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

            var service = new DeliveryDiretoService(true);
            var result = service.Order(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text, _deliveryDiretoReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoAceitar_Click(object sender, EventArgs e)
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

            var service = new DeliveryDiretoService();
            var result = service.Accept(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text, _deliveryDiretoReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoCancelar_Click(object sender, EventArgs e)
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

            var service = new DeliveryDiretoService();
            var result = service.Cancel(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text, _deliveryDiretoReferenceSelected, "Cancelado pelo sistema de integração - IzzyWay");
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoEntregaRetirada_Click(object sender, EventArgs e)
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

            var service = new DeliveryDiretoService();
            var result = service.Dispatch(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text, _deliveryDiretoReferenceSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDeliveryDiretoFinalizar_Click(object sender, EventArgs e)
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

            var service = new DeliveryDiretoService();
            var result = service.Finalize(txtDeliveryDiretoMerchandId.Text, txtDeliveryDiretoClientId.Text, txtDeliveryDiretoToken.Text, _deliveryDiretoReferenceSelected);
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
            var result = service.Deny(txtGoomerAuthToken.Text, _goomerSelected, "Cancelado");
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

        private void btnGoomeAtualizarConta_Click(object sender, EventArgs e)
        {
            var conta = new Goomer.Domain.conta();
            conta.status = Goomer.Enum.MESA_STATUS.CONSUMING;
            conta.subtotal = Convert.ToDecimal("30,00");
            conta.discount = Convert.ToDecimal("5,00");
            conta.service = Convert.ToDecimal("5,00");
            conta.total = Convert.ToDecimal("30,00");
            conta.table = "1";
            conta.tab = "";
            conta.externalId = "1";

            var produto1 = new Goomer.Domain.conta_produto();
            produto1.code = "1";
            produto1.name = "Coca-Cola";
            produto1.price = Convert.ToDecimal("5,00");
            produto1.quantity = Convert.ToDecimal("6,00");
            produto1.type = "default";
            produto1.date = "";
            conta.products.Add(produto1);

            var service = new GoomerService(txtGoomerURL.Text);
            var result = service.UpdateConta(txtGoomerAuthToken.Text, conta);
            if (result.Success)
            {
                MessageBox.Show("Conta atualizado");
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

        public const string DOCUMENTO = "24664528043";

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

        private void btnEpadocaFazerPedido_Click(object sender, EventArgs e)
        {
            var pedido = new fidelidade_adicionar_pedido();
            pedido.cliente = new fidelidade_adicionar_pedido_Cliente();
            pedido.cliente.celular = "";
            pedido.cliente.codigoExterno = "";
            pedido.cliente.documento = DOCUMENTO;
            pedido.cliente.nome = "";
            pedido.valorDesconto = 0;
            pedido.valorTotal = 2500;
            pedido.codigo = DateTime.Now.ToString("HHmmss");
            pedido.data = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            var produto1 = new fidelidade_adicionar_pedido_produto();
            produto1.sku = "1";
            produto1.nome = "Coca-cola";
            produto1.quantidade = 1;
            produto1.valorUnitario = 2500;
            produto1.valorTotal = 2500;
            produto1.categoria = "GERAL";

            pedido.produtoL.Add(produto1);

            var pedidos = new List<fidelidade_adicionar_pedido>();
            pedidos.Add(pedido);

            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.FidelidadeAdicionarPedido(txtEpadocaToken.Text, txtEpadocaMerchantId.Text, pedidos);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaStatusCupom_Click(object sender, EventArgs e)
        {
            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.FidelidadeStatus(txtEpadocaToken.Text, txtEpadocaMerchantId.Text, "", "", "", "", DOCUMENTO);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaUtilizarCupom_Click(object sender, EventArgs e)
        {
            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.FidelidadeUtilizarCupom(txtEpadocaToken.Text, txtEpadocaMerchantId.Text, "123456", "Henrique", "henrique@izzyway.com.br", "87458788", DOCUMENTO, "99786709-dbf7-4d49-b3fe-6033c71a208f");
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEpadocaConsultarCupom_Click(object sender, EventArgs e)
        {
            var service = new EpadocaService(txtEpadocaUrl.Text);
            var result = service.FidelidadeConsultarCupom(txtEpadocaToken.Text, txtEpadocaMerchantId.Text, "99786709-dbf7-4d49-b3fe-6033c71a208f");
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

        #region B2Food

        private void btnB2FoodIniciar_Click(object sender, EventArgs e)
        {
            b2foodIniciar();
        }

        private void btnB2FoodParar_Click(object sender, EventArgs e)
        {
            b2foodParar();
        }

        private void btnB2FoodAceito_Click(object sender, EventArgs e)
        {
            if (btnB2FoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_b2foodSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new B2Food.Service.B2FoodService(_b2FoodToken, true);
            var id = Convert.ToInt32(_b2foodSelected);
            var result = service.AlterarStatus(id, B2Food.Enum.order_status.ACEITO, 30, "Henrique", "8598774587");
            if (result.Success)
            {
                MessageBox.Show("Pedido confirmado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnB2FoodCancelado_Click(object sender, EventArgs e)
        {

        }

        private void gridB2Food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridB2Food.Rows.Count)
            {
                _b2foodSelected = gridB2Food.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        public async void b2foodIniciar()
        {
            if (string.IsNullOrEmpty(txtSuperMenuToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtB2FoodToken.Enabled = false;

            btnB2FoodIniciar.Enabled = false;
            btnB2FoodParar.Enabled = true;
            _b2FoodToken = txtB2FoodToken.Text;
            await Task.Run(() => b2food());
        }


        void b2foodParar()
        {
            txtB2FoodToken.Enabled = true;

            btnB2FoodIniciar.Enabled = true;
            btnB2FoodParar.Enabled = false;
        }

        private void b2food()
        {
            var service = new B2Food.Service.B2FoodService(_b2FoodToken, true);

            try
            {
                while (btnB2FoodParar.Enabled)
                {
                    var pedidosResult = service.PedidosPendentes();

                    if (pedidosResult.Success)
                    {
                        foreach (var numero in pedidosResult.Result)
                        {
                            var pedidoResult = service.Order(numero.ToString());
                            if (pedidoResult.Success)
                            {
                                _b2foodOrders.Add(pedidoResult.Result);
                            }
                        }

                        WriteGridB2Food();
                    }
                    else
                    {
                        MessageBox.Show(pedidosResult.Message);
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

        private delegate void WritelstGridB2FoodDelegate();
        private void WriteGridB2Food()
        {
            if (gridB2Food.InvokeRequired)
            {
                var d = new WritelstGridB2FoodDelegate(WriteGridB2Food);
                Invoke(d, new object[] { });
            }
            else
            {
                gridB2Food.DataSource = _b2foodOrders.ToList();
                gridB2Food.Refresh();
            }
        }

        #endregion

        #region Bigdim

        private void btnBigdimIniciar_Click(object sender, EventArgs e)
        {
            bigdimIniciar();
        }

        private void btnBigdimParar_Click(object sender, EventArgs e)
        {
            bigdimParar();
        }

        public async void bigdimIniciar()
        {
            if (string.IsNullOrEmpty(txtBigdimToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtBigdimToken.Enabled = false;

            btnBigdimIniciar.Enabled = false;
            btnBigdimParar.Enabled = true;
            _bigdimToken = txtBigdimToken.Text;
            await Task.Run(() => bigdim());
        }


        void bigdimParar()
        {
            txtBigdimToken.Enabled = true;

            btnBigdimIniciar.Enabled = true;
            btnBigdimParar.Enabled = false;
        }

        private void bigdim()
        {
            var service = new Bigdim.Service.BigdimService(_bigdimToken);

            try
            {
                while (btnBigdimParar.Enabled)
                {
                    var pedidosResult = service.PedidosPendentes();

                    if (pedidosResult.Success)
                    {
                        foreach (var item in pedidosResult.Result.resposta)
                        {
                            if (item.pedido.status == Bigdim.Enum.order_state.AGUARDANDO_ACEITE)
                            {
                                _bigdimOrders.Add(item.pedido);
                            }
                        }

                        WriteGridBigdim();
                    }
                    else
                    {
                        MessageBox.Show(pedidosResult.Message);
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

        private delegate void WritelstGridBigdimDelegate();
        private void WriteGridBigdim()
        {
            if (gridBigdim.InvokeRequired)
            {
                var d = new WritelstGridBigdimDelegate(WriteGridBigdim);
                Invoke(d, new object[] { });
            }
            else
            {
                gridBigdim.DataSource = _bigdimOrders.ToList();
                gridBigdim.Refresh();
            }
        }

        private void gridBigdim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridBigdim.Rows.Count)
            {
                _bigdimSelected = gridBigdim.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnBigdimAceito_Click(object sender, EventArgs e)
        {
            if (btnBigdimIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_bigdimSelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new Bigdim.Service.BigdimService(_bigdimToken);
            var result = service.AlterarStatus(_bigdimSelected, Bigdim.Enum.order_state.EM_PREPARO);
            if (result.Success)
            {
                MessageBox.Show("Pedido confirmado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Americanas

        private void btnAmericanasLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmericanasClientID.Text))
            {
                MessageBox.Show("ClientID Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtAmericanasClientSecret.Text))
            {
                MessageBox.Show("Client Secret Obrigatório");
                return;
            }

            var service = new Americanas.Service.AmericanasService();
            var result = service.OathToken(txtAmericanasClientID.Text, txtAmericanasClientSecret.Text);
            if (result.Success)
            {
                txtAmericanasToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAmericanasIniciar_Click(object sender, EventArgs e)
        {
            americanasIniciar();
        }

        private void btnAmericanasParar_Click(object sender, EventArgs e)
        {
            americanasParar();
        }

        private void btnAmericanasBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmericanasToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_americanasSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new Americanas.Service.AmericanasService();
            var pedidoResult = service.Order(txtAmericanasStore.Text, _americanasSelected, txtAmericanasToken.Text);
        }

        private void btnAmericanasAceito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmericanasToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_americanasSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new Americanas.Service.AmericanasService();
            var pedidoResult = service.Approve(txtAmericanasStore.Text, _americanasSelected, txtAmericanasToken.Text, 30);
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        private void btnAmericanasCancelado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmericanasToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_americanasSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new Americanas.Service.AmericanasService();
            var pedidoResult = service.Cancel(txtAmericanasStore.Text, _americanasSelected, txtAmericanasToken.Text, "Teste");
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        private void btnAmericanasPedidoPronto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmericanasToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_americanasSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var service = new Americanas.Service.AmericanasService();
            var pedidoResult = service.Ready(txtAmericanasStore.Text, _americanasSelected, txtAmericanasToken.Text);
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        public async void americanasIniciar()
        {
            if (string.IsNullOrEmpty(txtAmericanasToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }


            btnAmericanasIniciar.Enabled = false;
            btnAmericanasParar.Enabled = true;
            await Task.Run(() => americanas());
        }


        void americanasParar()
        {
            btnAmericanasIniciar.Enabled = true;
            btnAmericanasParar.Enabled = false;
        }

        private void americanas()
        {
            var service = new Americanas.Service.AmericanasService();

            try
            {
                while (btnAmericanasParar.Enabled)
                {
                    var pedidosResult = service.Orders(txtAmericanasStore.Text, txtAmericanasToken.Text);

                    if (pedidosResult.Success)
                    {
                        foreach (var item in pedidosResult.Result)
                        {
                            if (!_americanasOrders.Any(a => a.id == item.id))
                                _americanasOrders.Add(item);
                        }

                        WriteGridAmericanas();
                    }
                    else
                    {
                        MessageBox.Show(pedidosResult.Message);
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

        private delegate void WritelstGridAmericanasDelegate();
        private void WriteGridAmericanas()
        {
            if (gridAmericanas.InvokeRequired)
            {
                var d = new WritelstGridAmericanasDelegate(WriteGridAmericanas);
                Invoke(d, new object[] { });
            }
            else
            {
                gridAmericanas.DataSource = _americanasOrders.ToList();
                gridAmericanas.Refresh();
            }
        }

        private void gridAmericanas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridAmericanas.Rows.Count)
            {
                _americanasSelected = gridAmericanas.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnAmericanasBuscarProduto_Click(object sender, EventArgs e)
        {
            var service = new Americanas.Service.AmericanasService(true);

            try
            {
                var pedidosResult = service.GetProducts(txtAmericanasStore.Text, txtAmericanasToken.Text);

                if (pedidosResult.Success)
                {

                }
                else
                {
                    MessageBox.Show(pedidosResult.Message);
                    return;
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

        private void btnAmericanasCriarPedido_Click(object sender, EventArgs e)
        {
            var service = new Americanas.Service.AmericanasService(true);

            try
            {
                var pedidosResult = service.CreateOrder(txtAmericanasClientID.Text, txtAmericanasStore.Text, 247004, 3);

                if (pedidosResult.Success)
                {
                    MessageBox.Show("Pedido criado..");
                }
                else
                {
                    MessageBox.Show(pedidosResult.Message);
                    return;
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

        #region Servit

        private void btnServitLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitUsuario.Text))
            {
                MessageBox.Show("Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtServitSenha.Text))
            {
                MessageBox.Show("Senha Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var result = service.OathToken(txtServitUsuario.Text, txtServitSenha.Text);
            if (result.Success)
            {
                txtServitToken.Text = result.Result.data.token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnServitMerchand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var result = service.Merchants(txtServitToken.Text);
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnServitIniciar_Click(object sender, EventArgs e)
        {
            servitIniciar();
        }

        private void btnServitParar_Click(object sender, EventArgs e)
        {
            servitParar();
        }

        private void btnServitConfirmarEvento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_servitSelected))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }

            var ids = new List<int>();
            ids.Add(Convert.ToInt32(_servitSelected));

            var service = new Servit.Service.ServitService();
            var pedidoResult = service.EventsAcknowledgment(txtServitToken.Text, ids);
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }

        }

        private void btnServitBloqueioMesa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var pedidoResult = service.TableBlock(txtServitToken.Text, txtServitStore.Text, "7");
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        private void btnServitDesbloqueioMesa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var pedidoResult = service.TableUnlock(txtServitToken.Text, txtServitStore.Text, "7");
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        private void btnServitFinalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var pedidoResult = service.Status(txtServitToken.Text, txtServitStore.Text, txtServitMesa.Text, Servit.Enum.OrderStatus.CLOSED);
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }


        private void gridServit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridServit.Rows.Count)
            {
                _servitSelected = gridServit.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        public async void servitIniciar()
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }


            btnServitIniciar.Enabled = false;
            btnServitParar.Enabled = true;
            await Task.Run(() => servit());
        }

        void servitParar()
        {
            btnServitIniciar.Enabled = true;
            btnServitParar.Enabled = false;
        }

        private void servit()
        {
            var service = new Servit.Service.ServitService();

            try
            {
                while (btnServitParar.Enabled)
                {
                    var pedidosResult = service.Events(txtServitToken.Text, txtServitStore.Text);

                    if (pedidosResult.Success)
                    {
                        foreach (var item in pedidosResult.Result.data.events)
                        {
                            if (!_servitEvents.Any(a => a.id == item.id))
                                _servitEvents.Add(item);

                        }

                        WriteGridServit();
                    }
                    else
                    {
                        MessageBox.Show(pedidosResult.Message);
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

        private delegate void WritelstGridServitDelegate();
        private void WriteGridServit()
        {
            if (gridServit.InvokeRequired)
            {
                var d = new WritelstGridServitDelegate(WriteGridServit);
                Invoke(d, new object[] { });
            }
            else
            {
                gridServit.DataSource = _servitEvents.ToList();
                gridServit.Refresh();
            }
        }

        private void btnServitTransferencia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServitToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            var service = new Servit.Service.ServitService();
            var pedidoResult = service.TransferenciaCompleta(txtServitToken.Text, txtServitStore.Text, txtServitMesa.Text, txtServitMesaDestino.Text);
            if (pedidoResult.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(pedidoResult.Message);
            }
        }

        #endregion

        #region Jotaja

        private void btnJotajaToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaKey.Text))
            {
                MessageBox.Show("Key Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtJotajaSecret.Text))
            {
                MessageBox.Show("Client Secret Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.OathToken(txtJotajaKey.Text, txtJotajaSecret.Text);
            if (result.Success)
            {
                txtJotajaToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaIniciar_Click(object sender, EventArgs e)
        {
            jotjaIniciar();
        }

        private void btnJotajaParar_Click(object sender, EventArgs e)
        {
            jotajaParar();
        }

        private void btnJotajaBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Order(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaStore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Store(txtJotajaToken.Text);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridJotaJa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridJotaJa.Rows.Count)
            {
                _jotajaSelected = gridJotaJa.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        public async void jotjaIniciar()
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }


            btnJotajaIniciar.Enabled = false;
            btnJotajaParar.Enabled = true;
            await Task.Run(() => jotaja());
        }


        void jotajaParar()
        {
            btnJotajaIniciar.Enabled = true;
            btnJotajaParar.Enabled = false;
        }

        private void jotaja()
        {
            var service = new JotaJa.Service.JotaJaService(true);

            try
            {
                while (btnJotajaParar.Enabled)
                {
                    var pedidosResult = service.Orders(txtJotajaToken.Text);

                    if (pedidosResult.Success)
                    {
                        foreach (var item in pedidosResult.Result.items)
                        {
                            if (!_jotajaOrders.Any(a => a.id == item.id))
                                _jotajaOrders.Add(item);
                        }

                        WriteGridJotaJa();
                    }
                    else
                    {
                        MessageBox.Show(pedidosResult.Message);
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

        private delegate void WritelstGridJotaJaDelegate();
        private void WriteGridJotaJa()
        {
            if (gridJotaJa.InvokeRequired)
            {
                var d = new WritelstGridJotaJaDelegate(WriteGridJotaJa);
                Invoke(d, new object[] { });
            }
            else
            {
                gridJotaJa.DataSource = _jotajaOrders.ToList();
                gridJotaJa.Refresh();
            }
        }

        private void btnJotajaAceitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Accept(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido aceito");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Cancel(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido cancelado");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaSaiuEntrega_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Dispatch(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido saiu para a entrega");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaProntoRetirada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.ReadyPickup(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido pronto para retirada");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaPagamentoPendente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Pending(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido pagamento pendente");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnJotajaFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJotajaToken.Text))
            {
                MessageBox.Show("Token Obrigatório");
                return;
            }

            var service = new JotaJa.Service.JotaJaService(true);
            var result = service.Finalize(txtJotajaToken.Text, _jotajaSelected);
            if (result.Success)
            {
                MessageBox.Show("Pedido finalizado");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region CRM Bonus

        private void btnCRMBonusInicio_Click(object sender, EventArgs e)
        {
            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.Inicio(txtCRMBonusClienteNome.Text, txtCRMBonusClienteEmail.Text, txtCRMBonusClienteAniversario.Text, txtCRMBonusClienteCPF.Text);
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                txtCRMBonusCustomerId.Text = result.Result.data.customer_id.ToString();
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusValidarPIN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCRMBonusPIN.Text))
            {
                MessageBox.Show("PIN Obrigatório");
                txtCRMBonusPIN.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCRMBonusCustomerId.Text))
            {
                MessageBox.Show("CustomerId Obrigatório");
                txtCRMBonusCustomerId.Focus();
                return;
            }

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.ValidarPin(txtCRMBonusPIN.Text, Convert.ToInt32(txtCRMBonusCustomerId.Text));
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusReenviarPIN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCRMBonusCustomerId.Text))
            {
                MessageBox.Show("CustomerId Obrigatório");
                txtCRMBonusCustomerId.Focus();
                return;
            }

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.ReenviarPin(Convert.ToInt32(txtCRMBonusCustomerId.Text));
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusBonusDisponivel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCRMBonusCustomerId.Text))
            {
                MessageBox.Show("CustomerId Obrigatório");
                txtCRMBonusCustomerId.Focus();
                return;
            }

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.BonusDisponivel(Convert.ToInt32(txtCRMBonusCustomerId.Text), 100);
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                txtCRMBonusBonusID.Text = result.Result.data.ids_bonus;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusCampanhaDisponivel_Click(object sender, EventArgs e)
        {
            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.CampanhaDisponivel(100);
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCRMBonusCustomerId.Text))
            {
                MessageBox.Show("CustomerId Obrigatório");
                txtCRMBonusCustomerId.Focus();
                return;
            }

            var utilizarBonus = true;
            if (utilizarBonus)
            {
                if (string.IsNullOrEmpty(txtCRMBonusBonusID.Text))
                {
                    MessageBox.Show("Bonus Ids Obrigatório");
                    txtCRMBonusBonusID.Focus();
                    return;
                }
            }

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.FinalizarCompra(false, utilizarBonus, txtCRMBonusBonusID.Text, Convert.ToInt32(txtCRMBonusCustomerId.Text), 2, 5255, "", false, "", "Henrique", 100, "1", "");
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusCancelarBonus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCRMBonusCustomerId.Text))
            {
                MessageBox.Show("CustomerId Obrigatório");
                txtCRMBonusCustomerId.Focus();
                return;
            }

            var utilizarBonus = true;
            if (utilizarBonus)
            {
                if (string.IsNullOrEmpty(txtCRMBonusBonusID.Text))
                {
                    MessageBox.Show("Bonus Ids Obrigatório");
                    txtCRMBonusBonusID.Focus();
                    return;
                }
            }

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), txtCRMBonusClienteCelular.Text, true);
            var result = service.CancelarBonus(txtCRMBonusBonusID.Text, Convert.ToInt32(txtCRMBonusCustomerId.Text));
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnCRMBonusVendasTotais_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            var valor = new decimal(rand.NextDouble());

            var service = new CRMBonus.Service.CRMBonusService(txtCRMBonusAuthorization.Text, txtCRMBonusCodigoEmpresa.Text,
                    Convert.ToInt32(txtCRMBonusCodigoLoja.Text), "", true);
            var result = service.VendaTotais(valor, 4, "Henrique", "Pedro", "", 0, 0, rand.Next().ToString());
            if (result.Success)
            {
                txtCRMBonusJSON.Text = result.Json;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        #endregion

        #region Cresce Vendas
        private void btnCresceVendasCompra_Click(object sender, EventArgs e)
        {
            var compra = new CresceVendas.Domain.compra();
            compra.registration = "05903219004";

            Random rand = new Random();

            //compra.payment = new CresceVendas.Domain.payment();
            //compra.payment.coupon = rand.Next().ToString();
            //compra.payment.total = 40;
            //compra.payment.method = CresceVendas.Enum.PaymentMethod.DINHEIRO;
            //compra.payment.installments = 1;
            //compra.payment.splits = CresceVendas.Enum.PaymentSplits.A_VISTA;
            //compra.payment.date = "2019-08-01T12:00:00";

            var item1 = new CresceVendas.Domain.item();
            item1.category = "Alimentos";
            item1.subcategory = "Carnes";
            item1.product_name = "COXAO MOLE";
            item1.code = "1";
            item1.unit_type = CresceVendas.Enum.UnitType.UM;
            item1.unit_value = 60;
            item1.quantity = 1;
            //item1.total_value = 60;
            compra.items.Add(item1);

            var item2 = new CresceVendas.Domain.item();
            item2.category = "Alimentos";
            item2.subcategory = "Laticínios";
            item2.product_name = "Leite integral";
            item2.code = "23456";
            item2.unit_type = CresceVendas.Enum.UnitType.UM;
            item2.unit_value = 20;
            item2.quantity = 1;
            //item2.total_value = 20;
            compra.items.Add(item2);

            var service = new CresceVendas.Service.CresceVendasService(txtCresceVendasEmail.Text, txtCresceVendasToken.Text, true);
            var retorno = service.Compra(compra);
            if (retorno.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(retorno.Message);
            }
        }

        private void btnCresceVendasSaldo_Click(object sender, EventArgs e)
        {
            var registration = "05903219004";

            var service = new CresceVendas.Service.CresceVendasService(txtCresceVendasEmail.Text, txtCresceVendasToken.Text, true);
            var retorno = service.ConsultarSaldo(registration, 15);
            if (retorno.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(retorno.Message);
            }
        }

        private void btnCresceVendasCancelamento_Click(object sender, EventArgs e)
        {
            var coupon = "1362436046";

            var service = new CresceVendas.Service.CresceVendasService(txtCresceVendasEmail.Text, txtCresceVendasToken.Text, true);
            var retorno = service.Cancelar(coupon);
            if (retorno.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(retorno.Message);
            }
        }

        private void btnCresceVendasTotalCompras_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            var total = Decimal.Round(new decimal(rand.NextDouble()), 2);

            var service = new CresceVendas.Service.CresceVendasService(txtCresceVendasEmail.Text, txtCresceVendasToken.Text, true);
            var retorno = service.DiarioTotalCompras(12345, total, "2019-08-01");
            if (retorno.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(retorno.Message);
            }
        }

        private void btnCresceVendasPreCadastro_Click(object sender, EventArgs e)
        {
            var registration = "05903219004";
            var phone = "11987654321";

            var service = new CresceVendas.Service.CresceVendasService(txtCresceVendasEmail.Text, txtCresceVendasToken.Text, true);
            var retorno = service.PreCadastro(registration, phone);
            if (retorno.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(retorno.Message);
            }
        }

        #endregion

        #region Quero Delivery
        private void btnQuerodeliveryIniciar_Click(object sender, EventArgs e)
        {
            queroDeliveryIniciar();
        }

        public async void queroDeliveryIniciar()
        {
            if (string.IsNullOrEmpty(txtQuerodeliveryToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtQuerodeliveryPlaceID.Text))
            {
                MessageBox.Show("Campo Place ID Obrigatório");
                return;
            }

            txtQuerodeliveryToken.Enabled = false;
            txtQuerodeliveryPlaceID.Enabled = false;

            btnQuerodeliveryIniciar.Enabled = false;
            btnQuerodeliveryParar.Enabled = true;
            _queroDeliveryToken = txtQuerodeliveryToken.Text;
            _queroDeliveryPlaceId = txtQuerodeliveryPlaceID.Text;
            await Task.Run(() => queroDelivery());
        }

        private void queroDelivery()
        {
            var queroDeliveryService = new QueroDeliveryService();

            try
            {
                while (btnQuerodeliveryParar.Enabled)
                {
                    var orderResult = queroDeliveryService.Orders(_queroDeliveryToken, _queroDeliveryPlaceId);
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result)
                        {
                            _queroDeliveryOrders.Add(new QueroDelivery.Domain.orders
                            {
                                orderId = item.orderId,
                                orderCode = item.orderCode,
                                typeOfPayment = item.typeOfPayment,
                                totalPrice = item.totalPrice,
                                status = item.status,
                                createdAt = item.createdAt
                            });
                        };

                        WriteGridQueroDelivery();
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

        private delegate void WritelstGridqueroDeliveryDelegate();
        private void WriteGridQueroDelivery()
        {
            if (gridQuerodelivery.InvokeRequired)
            {
                var d = new WritelstGridqueroDeliveryDelegate(WriteGridQueroDelivery);
                Invoke(d, new object[] { });
            }
            else
            {
                gridQuerodelivery.DataSource = _queroDeliveryOrders.ToList();
                gridQuerodelivery.Refresh();
            }
        }

        private void btnQuerodeliveryParar_Click(object sender, EventArgs e)
        {
            queroDeliveryParar();
        }

        void queroDeliveryParar()
        {
            txtQuerodeliveryToken.Enabled = true;
            txtQuerodeliveryPlaceID.Enabled = true;

            btnQuerodeliveryIniciar.Enabled = true;
            btnQuerodeliveryParar.Enabled = false;
        }

        private void gridQuerodelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridQuerodelivery.Rows.Count)
            {
                _queroDeliverySelected = gridQuerodelivery.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnQuerodeliveryBuscarPedido_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.Order(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected);
            if (result.Success)
            {
                MessageBox.Show("Buscando pedido com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnQuerodeliveryAceitar_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.Accept(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected);
            if (result.Success)
            {
                MessageBox.Show("Aceito com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        private void btnQuerodeliveryCancelar_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.Cancel(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected, "Teste de Api");
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnQuerodeliverySaiuParaEntrega_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.Dispatch(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected);
            if (result.Success)
            {
                MessageBox.Show("Saiu para entrega");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnQuerodeliveryProntoRetirada_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.ReadyToPickup(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected);
            if (result.Success)
            {
                MessageBox.Show("Pronto para retirada");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnQuerodeliveryConcluído_Click(object sender, EventArgs e)
        {
            if (btnQuerodeliveryIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (string.IsNullOrEmpty(_queroDeliverySelected))
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var queroDeliveryService = new QueroDeliveryService();
            var result = queroDeliveryService.Finalize(_queroDeliveryToken, _queroDeliveryPlaceId, _queroDeliverySelected);
            if (result.Success)
            {
                MessageBox.Show("Finalizado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion        

        #region Woocommerce

        public async void woocommerceIniciar()
        {
            if (string.IsNullOrEmpty(txtWoocommerceURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtWoocommerceKey.Text))
            {
                MessageBox.Show("Campo KEY Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtWoocommerceSecret.Text))
            {
                MessageBox.Show("Campo SECRET Obrigatório");
                return;
            }

            txtWoocommerceURL.Enabled = false;
            txtWoocommerceKey.Enabled = false;
            txtWoocommerceSecret.Enabled = false;

            btnWoocommerceIniciar.Enabled = false;
            btnWoocommerceParar.Enabled = true;
            await Task.Run(() => woocommerce());
        }

        private void woocommerce()
        {
            var service = new WoocommerceService(txtWoocommerceURL.Text, txtWoocommerceKey.Text, txtWoocommerceSecret.Text);

            try
            {
                while (btnWoocommerceParar.Enabled)
                {
                    var orderResult = service.Orders();
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result)
                        {
                            _woocommerceOrders.Add(item);
                        };

                        WriteGridWoocommerce();
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

        private delegate void WritelstGridWoocommerceDelegate();
        private void WriteGridWoocommerce()
        {
            if (gridWoocommerce.InvokeRequired)
            {
                var d = new WritelstGridWoocommerceDelegate(WriteGridWoocommerce);
                Invoke(d, new object[] { });
            }
            else
            {
                gridWoocommerce.DataSource = _woocommerceOrders.ToList();
                gridWoocommerce.Refresh();
            }
        }

        private void btnWoocommerceIniciar_Click(object sender, EventArgs e)
        {
            woocommerceIniciar();
        }

        private void btnWoocommerceParar_Click(object sender, EventArgs e)
        {
            txtWoocommerceURL.Enabled = true;
            txtWoocommerceKey.Enabled = true;
            txtWoocommerceSecret.Enabled = true;

            btnWoocommerceIniciar.Enabled = true;
            btnWoocommerceParar.Enabled = false;
        }

        private void gridWoocommerce_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridWoocommerce.Rows.Count)
            {
                _woocommerceId = Convert.ToInt32(gridWoocommerce.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void btnWoocommerceCompleted_Click(object sender, EventArgs e)
        {
            if (btnWoocommerceIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            if (_woocommerceId == 0)
            {
                MessageBox.Show("Selecione um registro");
                return;
            }

            var service = new WoocommerceService(txtWoocommerceURL.Text, txtWoocommerceKey.Text, txtWoocommerceSecret.Text);
            var result = service.Update(_woocommerceId, Woocommerce.Enum.order_status.COMPLETED);
            if (result.Success)
            {
                MessageBox.Show("Atualizado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Mercadoo

        private void btnMercadooPedidos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogarooToken.Text))
            {
                MessageBox.Show("Faça o login primeiro");
                return;
            }

            var logarooService = new Logaroo.Service.LogarooService(_urlLogarooDesenvolvimento);
            //var logarooService = new Logaroo.Service.LogarooService();
            var result = logarooService.MercadooOrdersPendentes(txtLogarooToken.Text, txtLogarooMerchantId.Text);
            if (result.Success)
            {
                foreach (var pedido in result.Result.data.items)
                {
                    var resultPedidoDetalhe = logarooService.MercadooOrder(txtLogarooToken.Text, pedido.id.ToString());
                    //var resultPedidoModerar = logarooService.MercadooOrderModerar(txtLogarooToken.Text, pedido.id.ToString(), true);
                }

                gridLogaroo.DataSource = result.Result.data.items;
                gridLogaroo.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region PixCommerce


        public async void pixCommerceIniciar()
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtPixCommerceToken.Enabled = false;

            btnPixCommerceIniciar.Enabled = false;
            btnPixCommerceParar.Enabled = true;
            await Task.Run(() => pixCommerce());
        }

        private void pixCommerce()
        {
            var service = new PixCommerceService(txtPixCommerceToken.Text);

            try
            {
                while (btnPixCommerceParar.Enabled)
                {
                    var orderResult = service.Orders();
                    if (orderResult.Success)
                    {
                        foreach (var item in orderResult.Result)
                        {
                            _pixCommerceOrders.Add(new PixCommerce.Domain.orders
                            {
                                codigo = item.codigo,
                                data_venda = item.data_venda,
                                venda_id = item.venda_id
                            });
                        };

                        WriteGridPixCommerce();
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

        private delegate void WritelstGridpixCommerceDelegate();
        private void WriteGridPixCommerce()
        {
            if (gridPixCommerce.InvokeRequired)
            {
                var d = new WritelstGridpixCommerceDelegate(WriteGridPixCommerce);
                Invoke(d, new object[] { });
            }
            else
            {
                gridPixCommerce.DataSource = _pixCommerceOrders.ToList();
                gridPixCommerce.Refresh();
            }
        }

        private void btnPixCommerceBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.Order(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnPixCommerceIniciar_Click(object sender, EventArgs e)
        {
            pixCommerceIniciar();
        }

        private void btnPixCommerceParar_Click(object sender, EventArgs e)
        {
            pixCommerceParar();
        }

        void pixCommerceParar()
        {
            txtPixCommerceToken.Enabled = true;

            btnPixCommerceIniciar.Enabled = true;
            btnPixCommerceParar.Enabled = false;
        }

        private void gridPixCommerce_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridPixCommerce.Rows.Count)
            {
                _pixCommerceId = gridPixCommerce.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnPixCommerceCOnfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.Confirm(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnPixCommerceEmProducao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.Production(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnPixCommerceEmRota_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.InRoute(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnPixCommerceFinalizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.Final(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnPixCommerceCancelado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPixCommerceToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_pixCommerceId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new PixCommerceService(txtPixCommerceToken.Text);
            var orderResult = service.Cancel(_pixCommerceId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        #endregion

        #region Multi Pedido


        private void btnMultiPedidoIniciar_Click(object sender, EventArgs e)
        {
            multiPedidoIniciar();
        }

        private void btnMultiPedidoParar_Click(object sender, EventArgs e)
        {
            txtMultiPedidoToken.Enabled = true;

            btnMultiPedidoIniciar.Enabled = true;
            btnMultiPedidoParar.Enabled = false;
        }


        private void gridMultiPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridMultiPedido.Rows.Count)
            {
                _multiPedidoId = gridMultiPedido.Rows[e.RowIndex].Cells[19].Value.ToString();
            }
        }

        public async void multiPedidoIniciar()
        {
            if (string.IsNullOrEmpty(txtMultiPedidoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtMultiPedidoToken.Enabled = false;

            btnMultiPedidoIniciar.Enabled = false;
            btnMultiPedidoParar.Enabled = true;
            await Task.Run(() => multiPedido());
        }

        private void multiPedido()
        {
            var service = new MultiPedidoService(txtMultiPedidoToken.Text);

            try
            {
                //while (btnMultiPedidoParar.Enabled)
                //{
                var orderResult = service.Orders();
                if (orderResult.Success)
                {
                    _multiPedidoOrders = orderResult.Result;

                    WriteGridMultiPedido();
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
                }

                //Thread.Sleep(30000);
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridMultiPedidoDelegate();
        private void WriteGridMultiPedido()
        {
            if (gridMultiPedido.InvokeRequired)
            {
                var d = new WritelstGridMultiPedidoDelegate(WriteGridMultiPedido);
                Invoke(d, new object[] { });
            }
            else
            {
                gridMultiPedido.DataSource = _multiPedidoOrders.ToList();
                gridMultiPedido.Refresh();
            }
        }

        private void btnMultiPedidoCOnfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMultiPedidoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_multiPedidoId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new MultiPedidoService(txtMultiPedidoToken.Text);
            var orderResult = service.Acknowledge(_multiPedidoId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnMultiPedidoSaiuParaEntrega_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiPedidoPontoParaRetirar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMultiPedidoTOkenGerado.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_multiPedidoId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new MultiPedidoService(txtMultiPedidoToken.Text);
            var result = service.Status(txtMultiPedidoTOkenGerado.Text, txtMultiPedidoEstabelecimento.Text, _multiPedidoId, MultiPedido.Enum.OrderStatus.DONE);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        private void btnMultiPedidoEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMultiPedidoTOkenGerado.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_multiPedidoId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new MultiPedidoService(txtMultiPedidoToken.Text);
            var result = service.Status(txtMultiPedidoTOkenGerado.Text, txtMultiPedidoEstabelecimento.Text, _multiPedidoId, MultiPedido.Enum.OrderStatus.DONE);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnMultiPedidoCancelado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMultiPedidoTOkenGerado.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_multiPedidoId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new MultiPedidoService(txtMultiPedidoToken.Text);
            var result = service.Status(txtMultiPedidoTOkenGerado.Text, txtMultiPedidoEstabelecimento.Text, _multiPedidoId, MultiPedido.Enum.OrderStatus.DONE);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnMultiPedidoGerarToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMultiPedidoToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            var service = new MultiPedidoService(txtMultiPedidoToken.Text);
            var result = service.Login();
            if (result.Success)
            {
                txtMultiPedidoTOkenGerado.Text = result.Result.token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        #endregion

        #region Simbora
        private void btnSimboraFazerPedido_Click(object sender, EventArgs e)
        {
            var orders = new orders_new();
            var order = new Simbora.Domain.order();
            order.external_id = DateTime.Now.ToString("HHmmss");
            order.origin = new Simbora.Domain.order_origin();
            order.origin.latitude = 0;
            order.origin.longitude = 0;
            order.total = 10;
            order.observation = "Favor entregar na porta";
            order.client_name = "Henrique";
            order.client_phone = "859878458788";
            order.iD_erp_cliente = DateTime.Now.ToString("HHmm");
            order.iD_integrador = DateTime.Now.ToString("mmss");

            order.destination = new Simbora.Domain.order_destination();
            order.destination.latitude = 0;
            order.destination.longitude = 0;
            order.destination.street = "R. Caetano Ximenes Aragão";
            order.destination.number = "665";
            order.destination.complement = "";
            order.destination.cep = "60813-620";
            order.destination.reference = "Sala 3";

            order.payFormat = new Simbora.Domain.order_payFormat();
            order.payFormat.method = PayFormatMethods.CARD;
            order.payFormat.change = 0;

            var item1 = new Simbora.Domain.item();
            item1.name = "Coca-cola";
            item1.id = "1";
            item1.uniqueId = "1";
            item1.index = 1;
            item1.unitPrice = 10;
            item1.quantity = 1;
            item1.price = 10;
            item1.totalPrice = 10;
            item1.externalCode = "1";

            order.items.Add(item1);

            orders.orders.Add(order);

            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.OrderNew(txtSimboraToken.Text, orders);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSimboraConsultarPedido_Click(object sender, EventArgs e)
        {
            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.Consultar(txtSimboraToken.Text, "1");
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSimboraCOnfirmarPedido_Click(object sender, EventArgs e)
        {
            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.Confirmar(txtSimboraToken.Text, "5");
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSimboraConsultarPedidoRoteirazados_Click(object sender, EventArgs e)
        {
            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.ConsultarPedidosRoteirizados(txtSimboraToken.Text);
        }

        private void btnSimboraConfirmarPedidoPronto_Click(object sender, EventArgs e)
        {
            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.ConfirmarPedidoPronto(txtSimboraToken.Text, "105627");
        }

        private void btnSimboraConsultarAtualizacoes_Click(object sender, EventArgs e)
        {
            var simboraServico = new SimboraService("https://teste.webapi.simbora.app/");
            var result = simboraServico.ConsultarAtualizacoesPedidos(txtSimboraToken.Text);
        }


        #endregion

        #region Eu Falo

        private void btnEuFaloLogin_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();
            var result = service.Login(txtEuFaloUsuario.Text, txtEuFaloToken.Text);
            if (result.Success)
            {
                txtEuFaloTokenGerado.Text = result.Result.accessToken;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEuFaloCriarPedido_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();

            var categorias = new List<EuFalo.Domain.categoria>();
            var categoria1 = new EuFalo.Domain.categoria();
            categoria1.produtoCategoriaCI = "1";
            categoria1.nomeProdutoCategoria = "GERAL";
            categorias.Add(categoria1);

            var serviceCategoria = service.CategoriaLista(txtEuFaloTokenGerado.Text, categorias);

            var produtos = new List<EuFalo.Domain.produto>();
            var produto1 = new EuFalo.Domain.produto();
            produto1.ativo = true;
            produto1.categoriaProdutoCI = "1";
            produto1.nomeProduto = "COCA-COLA";
            produto1.preco = 100;
            produtos.Add(produto1);

            var serviceProduto = service.ProdutoLista(txtEuFaloTokenGerado.Text, produtos);

            var formpagamento = new EuFalo.Domain.formpagamento();
            formpagamento.ativo = true;
            formpagamento.formaPagamentoCI = "1";
            formpagamento.nomeFormaPagamento = "DINHEIRO";
            var serviceFormaPagamento = service.FormaPagamento(txtEuFaloTokenGerado.Text, formpagamento);

            var vendedor = new EuFalo.Domain.vendedor();
            vendedor.ativo = 1;
            vendedor.vendedorCI = "1";
            vendedor.nomeVendedor = "PEDRO HENRIQUE";
            var serviceVendedor = service.Vendedor(txtEuFaloTokenGerado.Text, vendedor);

            var contato = new EuFalo.Domain.contato();
            contato.contatoCI = "1";
            contato.nome = "HENRIQUE";
            contato.cpf = DOCUMENTO;
            contato.sexo = "M";
            var serviceContato = service.Contato(txtEuFaloTokenGerado.Text, contato);

            var venda = new EuFalo.Domain.venda();
            venda.contatoCI = contato.contatoCI;
            venda.vendaContatoCI = DateTime.Now.ToString("HHmmss");
            venda.contatoCPF = DOCUMENTO;
            venda.contarPontos = true;
            venda.resgateAutomatico = true;
            venda.dataVenda = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            venda.numero = DateTime.Now.ToString("HHmmss");
            venda.valor = 50;
            venda.vendedorCI = vendedor.vendedorCI;
            venda.nomeVendedor = vendedor.nomeVendedor;
            venda.formaPagamentoCI = formpagamento.formaPagamentoCI;
            venda.nomeFormaPagamento = formpagamento.nomeFormaPagamento;
            venda.filialCI = "1";
            venda.filialNomeFantasia = "IzzyWay";

            var item1 = new venda_item();
            item1.vendaContatoItemCI = "1";
            item1.produtoCI = "1";
            item1.quantidade = 1;
            item1.valor = 50;
            venda.item.Add(item1);

            var result = service.Venda(txtEuFaloTokenGerado.Text, venda);
            if (result.Success && !result.Result.errors.Any())
            {
                MessageBox.Show("Criado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEuFaloSaldo_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();
            var result = service.ConsultarSaldoInstantaneo(txtEuFaloTokenGerado.Text, DOCUMENTO);
            if (result.Success && result.Result.success.Any())
            {
                var retorno = result.Result.success.FirstOrDefault();
                MessageBox.Show("Saldo: " + retorno.saldo.ToString("N"));
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEuFaloUtilizarrSaldo_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();
            var result = service.BaixarVoucherInstantaneo(txtEuFaloTokenGerado.Text, DOCUMENTO, DateTime.Now, 20);
            if (result.Success && result.Result.success.Any())
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEuFaloListarPorCPF_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();
            var result = service.ListarPorCPF(txtEuFaloTokenGerado.Text, DOCUMENTO);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnEuFaloUtilizarrSaldoMeta_Click(object sender, EventArgs e)
        {
            var service = new EuFaloService();
            var result = service.BaixarVoucherMeta(txtEuFaloTokenGerado.Text, DOCUMENTO, txtEuFaloVoucher.Text, DateTime.Now);
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

        #region Iorion 9

        private async void btnIorionIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtIorionToken.Enabled = false;
            txtIorionURL.Enabled = false;

            btnIorionIniciar.Enabled = false;
            btnIorion9Parar.Enabled = true;
            await Task.Run(() => iorion19());
        }

        private void iorion19()
        {
            var service = new DegustaAiService(txtIorionURL.Text);

            try
            {
                //while (btnIorion9Parar.Enabled)
                //{
                var orderResult = service.Orders(txtIorionToken.Text, "", DateTime.Now);
                if (orderResult.Success)
                {
                    if (orderResult.Result.code == "200")
                    {
                        _iorion9Orders = orderResult.Result.pedidos;

                        WriteGridIorion();
                    }
                    else
                    {
                        MessageBox.Show(orderResult.Result.message);
                    }
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
                }

                //Thread.Sleep(30000);
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridIorionDelegate();
        private void WriteGridIorion()
        {
            if (gridIorion.InvokeRequired)
            {
                var d = new WritelstGridIorionDelegate(WriteGridIorion);
                Invoke(d, new object[] { });
            }
            else
            {
                gridIorion.DataSource = _iorion9Orders.ToList();
                gridIorion.Refresh();
            }
        }

        private void btnIorion9Parar_Click(object sender, EventArgs e)
        {
            txtIorionToken.Enabled = true;

            btnIorionIniciar.Enabled = true;
            btnIorion9Parar.Enabled = false;
        }

        private void btnIorionStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_iorion19Id))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.ChangeStatus(txtIorionToken.Text, Convert.ToInt32(_iorion19Id));
            if (result.Success)
            {
                if (result.Result.code == "200")
                    MessageBox.Show("OK");
                else
                    MessageBox.Show(result.Result.message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnIorionCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_iorion19Id))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.Cancel(txtIorionToken.Text, Convert.ToInt32(_iorion19Id));
            if (result.Success)
            {
                if (result.Result.code == "200")
                    MessageBox.Show("OK");
                else
                    MessageBox.Show(result.Result.message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void gridIorion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridIorion.Rows.Count)
            {
                _iorion19Id = gridIorion.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnDegustaAiGerarToken_Click(object sender, EventArgs e)
        {
            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.LoginFidelidade(txtDegustaAiEmail.Text, txtDegustaAiSenha.Text);
            if (result.Success)
            {
                txtIorionToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        private void btnDegustaAiRegistraPonto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            var dados = new registraPontuacaoViewModel();
            dados.telefone = TELEFONE;
            dados.pdv = "";
            decimal total = 10;
            dados.pontos = Convert.ToInt32(total).ToString();
            dados.operador = "000";


            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.RegistraPontos(txtIorionToken.Text, dados);
            if (result.Success)
            {
                if (result.Result.code == "200")
                    MessageBox.Show("OK");
                else
                    MessageBox.Show(result.Result.message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDegustaAiConsultaPremio_Click(object sender, EventArgs e)
        {
            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.ConsultaPremios(txtIorionToken.Text);
        }

        private void btnDegustaAiRegastaPremio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            var dados = new regastaPremioViewModel();
            dados.telefone = TELEFONE;
            dados.pdv = "";
            dados.premio_id = 78912;
            dados.operador = "000";


            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.ResgataPremio(txtIorionToken.Text, dados);
            if (result.Success)
            {
                if (result.Result.code == "200")
                    MessageBox.Show("OK");
                else
                    MessageBox.Show(result.Result.message);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDegustaAiResumoUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.ResumoUsuario(txtIorionToken.Text, TELEFONE);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnDegustaAiFecharMesa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIorionToken.Text))
            {
                MessageBox.Show("Campo Token gerado Obrigatório");
                return;
            }

            var service = new DegustaAiService(txtIorionURL.Text);
            var result = service.FecharMesa(txtIorionToken.Text, "1", "Dinheiro");
        }


        #endregion

        #region Agilizone

        private void btnAgilizoneToken_Click(object sender, EventArgs e)
        {
            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Token(txtAgilizoneClientID.Text, txtAgilizoneClientSecret.Text);
            if (result.Success)
            {
                txtAgilizoneToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAgilizoneOrder_Click(object sender, EventArgs e)
        {
            var order = new Agilizone.Domain.order();
            order.address = new Agilizone.Domain.order_address
            {
                city = "Fortaleza",
                complement = "S/ Complemento",
                coordinates = new Agilizone.Domain.order_address_coordinates { latitude = 0, longitude = 0 },
                country = "Brasil",
                number = "665",
                state = "Ceara",
                street = "R. Caetano Ximenes Aragão",
                neighborhood = "Luciano Cavalcante"
            };
            order.client = new Agilizone.Domain.order_client
            {
                name = "Henrique",
                email = "henrique@izzyway.com.br",
                phone = "85987704779"
            };

            order.details = "Pizza Grande +borda gratis. (1)\n - 1/2 calabresa com bacon (1) \n - 1/2 mussarela e bacon (1)\n- Sem borda (1)";
            order.number = DateTime.Now.ToString("ddMMyyyyHHmmss");
            order.paymentType = "CREDIT";
            order.deliveryFee = 10;
            order.deliverymanFee = 4;
            order.amount = 30;
            order.isPrepaid = true;

            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Order(order, txtAgilizoneToken.Text);
            if (result.Success)
            {
                txtAgilizoneNumero.Text = result.Result.order.number;
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAgilizoneCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAgilizoneNumero.Text))
            {
                MessageBox.Show("Digite o numero do pedido");
                return;
            }

            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Status(txtAgilizoneNumero.Text, txtAgilizoneToken.Text, Agilizone.Enum.OrderStatus.CANCELED, "Cancelado pelo usuário");
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAgilizonePreparado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAgilizoneNumero.Text))
            {
                MessageBox.Show("Digite o numero do pedido");
                return;
            }

            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Status(txtAgilizoneNumero.Text, txtAgilizoneToken.Text, Agilizone.Enum.OrderStatus.PREPARED);
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAgilizoneFinalizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAgilizoneNumero.Text))
            {
                MessageBox.Show("Digite o numero do pedido");
                return;
            }

            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Status(txtAgilizoneNumero.Text, txtAgilizoneToken.Text, Agilizone.Enum.OrderStatus.COMPLETED);
            if (result.Success)
            {
                MessageBox.Show("Cancelado com sucesso");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnAgilizoneBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAgilizoneNumero.Text))
            {
                MessageBox.Show("Digite o numero do pedido");
                return;
            }

            //var service = new AgilizoneService("https://api.test.agilizup.com/agilizone/v1/");
            var service = new AgilizoneService();
            var result = service.Order(txtAgilizoneNumero.Text, txtAgilizoneToken.Text);
            if (result.Success)
            {
                MessageBox.Show(result.Result.order.status);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        #endregion

        #region FIxeCRM

        private void btnFixeCRMLogin_Click(object sender, EventArgs e)
        {
            var service = new FixeCRMService();
            var result = service.Login(txtFixeCRMUsuario.Text, txtFixeCRMSenha.Text);
            if (result.Success)
            {
                txtFixeCRMToken.Text = result.Result.token;
                txtFixeCRMIdPassbook.Text = result.Result.user.id_passbooks;
                txtFixeCRMIdUser.Text = result.Result.user._id;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFixeCRMConsultarSelo_Click(object sender, EventArgs e)
        {
            var service = new FixeCRMService();
            var result = service.Pointsv2(txtFixeCRMToken.Text, txtFixeCRMIdPassbook.Text, txtFixCRMCPF.Text);
            if (result.Success)
            {
                //txtFixeCRMToken.Text = result.Result.token;
                //txtFixeCRMIdPassbook.Text = result.Result.user.id_passbooks;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFixeCRMPontos_Click(object sender, EventArgs e)
        {
            var point = new point();
            point.id_user = txtFixeCRMIdUser.Text;
            point.id_passbook = txtFixeCRMIdPassbook.Text;
            point.uniqueId = "32979091880";
            point.value = 100;
            point.source = "Loja Teste";
            point.externalId = DateTime.Now.ToString("ddMMyyyyHHmmss");
            point.is_delivery = false;

            var produto1 = new point_details();
            produto1.sku = "1";
            produto1.name = "Coca-Cola";
            produto1.count = 50;
            point.details.Add(produto1);


            var service = new FixeCRMService();
            var result = service.AddPoints(txtFixeCRMToken.Text, point);
            if (result.Success)
            {
                if (result.Result.status == FixeCRM.Enum.Status.OK)
                {
                    MessageBox.Show("OK");
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFixeCRMResgatar_Click(object sender, EventArgs e)
        {
            var point = new point();
            point.id_user = txtFixeCRMIdUser.Text;
            point.id_passbook = txtFixeCRMIdPassbook.Text;
            point.uniqueId = "32979091880";
            point.value = 1;
            point.source = "Loja Teste";
            point.externalId = DateTime.Now.ToString("ddMMyyyyHHmmss");
            point.is_delivery = false;

            var produto1 = new point_details();
            produto1.sku = "1";
            produto1.name = "Coca-Cola";
            produto1.count = 50;
            point.details.Add(produto1);


            var service = new FixeCRMService();
            var result = service.RemovePoints(txtFixeCRMToken.Text, point);
            if (result.Success)
            {
                if (result.Result.status == FixeCRM.Enum.Status.OK)
                {
                    MessageBox.Show("OK");
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        #endregion

        #region SelfBuyMe

        private void btnSelfBuyMeOrders_Click(object sender, EventArgs e)
        {
            var service = new SelfBuyMeService();
            var result = service.Orders(txtSelfBuyMeToken.Text, "");
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSelfBuyMeOrder_Click(object sender, EventArgs e)
        {
            var service = new SelfBuyMeService();
            var result = service.Order(txtSelfBuyMeToken.Text, 132);
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSelfBuyMePointSales_Click(object sender, EventArgs e)
        {
            var service = new SelfBuyMeService();
            var result = service.PointSales(txtSelfBuyMeToken.Text);
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSelfBuyMePointSalesGroup_Click(object sender, EventArgs e)
        {
            var service = new SelfBuyMeService();
            var result = service.PointSalesGroup(txtSelfBuyMeToken.Text);
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnSelfBuyMeMarkRead_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            ids.Add(132);
            var service = new SelfBuyMeService();
            var result = service.MarkRead(txtSelfBuyMeToken.Text, ids);
            if (result.Success)
            {

            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Fidelizi

        private const string FideliziUrlTeste = "https://sandbox.fidelizii.com.br/";
        private const string FideliziCodigoAtendente = "115074";
        private const int FideliziIdCliente = 3616285;

        private void btnFideliziConfiguracoes_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            service.GetConfiguracoes();
        }

        private void btnFideliziPontuar_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            var result = service.Pontuar(1000, DOCUMENTO, FideliziCodigoAtendente);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFideliziResgatar_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            var result = service.ResgatarPremio(63942, FideliziIdCliente, FideliziCodigoAtendente);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFideliziEstornar_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            var result = service.EstornarPremio(6102529, "Estorno realizado para testes");
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFideliziClientes_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            service.GetClientes();
        }

        private void btnFideliziCliente_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            service.GetClienteId(FideliziIdCliente);
        }

        private void btnFideliziClientePorCPF_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            service.GetClientePorCPF(DOCUMENTO);
        }

        private void btnFideliziCadastrarCliente_Click(object sender, EventArgs e)
        {
            var cadastrarCliente = new Fidelizi.Domain.cliente_cadastro();
            cadastrarCliente.nome = "Henrique Felipe";
            cadastrarCliente.cpf = DOCUMENTO;
            cadastrarCliente.email = "henrique.felipe85@gmail.com";
            cadastrarCliente.data_nascimento = "1994-12-01";
            cadastrarCliente.celular = "(85) 98770-4779";
            cadastrarCliente.sexo = "M";
            cadastrarCliente.cep = "11111111";
            cadastrarCliente.endereco = "Rua 15";
            cadastrarCliente.bairro = "Conjunto Ceará";
            cadastrarCliente.cidade = "Fortaleza";
            cadastrarCliente.estado = "CE";

            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            var result = service.CadastrarCliente(cadastrarCliente);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnFideliziAtendentes_Click(object sender, EventArgs e)
        {
            var service = new FideliziService(txtFideliziAppTokenn.Text, txtFideliziAccessToken.Text, txtFideliziEstabelecimentoCodigo.Text, FideliziUrlTeste);
            service.GetAtendentes();
        }

        #endregion

        #region Repediu
        private void btnPlug4SalesToken_Click(object sender, EventArgs e)
        {
            var service = new RepediuService();
            var result = service.Token(txtPlug4SalesClientId.Text, txtPlug4SalesClientSecret.Text);
            if (result.Success)
            {
                if (result.Result.success)
                {
                    txtPlug4SalesTokenGerado.Text = result.Result.result.token;
                }
                else
                {
                    MessageBox.Show(result.Result.error);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void txtPlug4Sales_Click(object sender, EventArgs e)
        {
            var pedidos = new List<Repediu.Domain.order>();
            var pedido = new Repediu.Domain.order();
            pedido.id = Guid.NewGuid().ToString();
            pedido.displayId = DateTime.Now.ToString("yyyyMMddHHmmss");
            pedido.createdAt = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            pedido.preparationStartDateTime = DateTime.Now.AddMinutes(40).ToString("yyyy-MM-ddTHH:mm:ss");

            pedido.merchant = new Repediu.Domain.merchant();
            pedido.merchant.id = Guid.NewGuid().ToString();
            pedido.merchant.name = "IzzyWay";

            pedido.customer = new Repediu.Domain.customer();
            pedido.customer.id = Guid.NewGuid().ToString();
            pedido.customer.name = "Henrique";
            pedido.customer.phone = new Repediu.Domain.customer_phone();
            pedido.customer.phone.number = "987704779";
            pedido.customer.phone.extension = "85";
            pedido.customer.documentNumber = "00000000000";

            pedido.delivery = new Repediu.Domain.delivery();
            pedido.delivery.deliveredBy = "MERCHANT";
            pedido.delivery.deliveryAddress = new Repediu.Domain.deliveryAddress();
            pedido.delivery.deliveryAddress.state = "SP";
            pedido.delivery.deliveryAddress.city = "São Paulo";
            pedido.delivery.deliveryAddress.district = "Moema";
            pedido.delivery.deliveryAddress.street = "Plaza Avenue";
            pedido.delivery.deliveryAddress.number = "100";
            pedido.delivery.deliveryAddress.complement = "BL 02 AP 31";
            pedido.delivery.deliveryAddress.reference = "Yellow House";
            pedido.delivery.deliveryAddress.formattedAddress = "Plaza Avenue, 100, BL 02 AP 31, Moema - São Paulo, SP - Brazil";
            pedido.delivery.deliveryAddress.postalCode = "20111-000";

            var item = new Repediu.Domain.item();
            item.id = Guid.NewGuid().ToString();
            item.name = "Calabresa";
            item.category = "Pizza";
            item.externalCode = "1";
            item.unit = "UN";
            item.quantity = 1;
            item.unitPrice = new Repediu.Domain.values(30);
            item.totalPrice = new Repediu.Domain.values(30);

            var option = new Repediu.Domain.option();
            option.id = Guid.NewGuid().ToString();
            option.name = "Cebola";
            option.unit = "UN";
            option.quantity = 1;
            option.externalCode = "2";
            option.unitPrice = new Repediu.Domain.values(5);
            option.totalPrice = new Repediu.Domain.values(5);

            item.options.Add(option);

            pedido.total = new Repediu.Domain.total();
            pedido.total.itemsPrice = new Repediu.Domain.values(30);

            var frete = new otherFees_price();
            frete.value = 10;
            pedido.otherFees.Add(new Repediu.Domain.otherFees { price = frete });

            pedido.total.otherFees = new Repediu.Domain.values(0);
            pedido.total.discount = new Repediu.Domain.values(5);
            pedido.total.orderAmount = new Repediu.Domain.values(35);


            pedidos.Add(pedido);

            var service = new RepediuService();
            var result = service.Orders(txtPlug4SalesTokenGerado.Text, pedidos);
            if (result.Success)
            {
                if (result.Result.success)
                {
                    MessageBox.Show(result.Result.result);
                }
                else
                {
                    MessageBox.Show(result.Result.error);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        #region Cardápio Web

        private const string UrlCardapioWebSandBox = "https://integracao.sandbox.cardapioweb.com/";

        private async void btnCardapioWebIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardapioWebToken.Text))
            {
                MessageBox.Show("Campo Token Obrigatório");
                return;
            }

            txtCardapioWebToken.Enabled = false;

            btnCardapioWebIniciar.Enabled = false;
            btnCardapioWebParar.Enabled = true;
            await Task.Run(() => cardapioWeb());
        }

        private void cardapioWeb()
        {
            var service = new CardapioWebService(txtCardapioWebToken.Text, UrlCardapioWebSandBox);

            try
            {
                //while (btnIorion9Parar.Enabled)
                //{
                var orderResult = service.Orders("?status=waiting_confirmation");
                if (orderResult.Success)
                {
                    _cardapioWebOrders = orderResult.Result.Where(w => w.status == CardapioWeb.Enum.OrderStatus.WAITING_CONFIRMATION).ToList();

                    WriteGridCardapioWeb();
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
                }

                //Thread.Sleep(30000);
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridCardapioWebDelegate();
        private void WriteGridCardapioWeb()
        {
            if (gridCardapioWeb.InvokeRequired)
            {
                var d = new WritelstGridCardapioWebDelegate(WriteGridCardapioWeb);
                Invoke(d, new object[] { });
            }
            else
            {
                gridCardapioWeb.DataSource = _cardapioWebOrders.ToList();
                gridCardapioWeb.Refresh();
            }
        }

        private void btnCardapioWebParar_Click(object sender, EventArgs e)
        {
            txtCardapioWebToken.Enabled = true;

            btnCardapioWebIniciar.Enabled = true;
            btnCardapioWebParar.Enabled = false;
        }

        private void gridCardapioWeb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridCardapioWeb.Rows.Count)
            {
                _cardapioWebId = gridCardapioWeb.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnCardapioWebPedido_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_cardapioWebId))
            {
                var service = new CardapioWebService(txtCardapioWebToken.Text);
                var result = service.Order(_cardapioWebId);
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnCardapioDigitalAceito_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_cardapioWebId))
            {
                var service = new CardapioWebService(txtCardapioWebToken.Text);
                var result = service.Confirm(_cardapioWebId);
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }


        #endregion

        #region Delivery Vip

        private async void btnDeliveryVipIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeliveryVipClientId.Text))
            {
                MessageBox.Show("Campo ClientId Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryVipSecret.Text))
            {
                MessageBox.Show("Campo Secret Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryVipMerchant.Text))
            {
                MessageBox.Show("Campo Merchant Obrigatório");
                return;
            }

            txtDeliveryVipClientId.Enabled = false;
            txtDeliveryVipSecret.Enabled = false;
            txtDeliveryVipMerchant.Enabled = false;

            btnDeliveryVipIniciar.Enabled = false;
            btnDeliveryVipParar.Enabled = true;

            var service = new DeliveryVipService();
            var resultToken = service.AuthenticationToken(txtDeliveryVipClientId.Text, txtDeliveryVipSecret.Text);
            if (!resultToken.Success)
            {
                MessageBox.Show(resultToken.Message);
                return;
            }

            txtDeliveryVipToken.Text = resultToken.Result.access_token;

            await Task.Run(() => deliveryVip());
        }

        private void btnDeliveryVipParar_Click(object sender, EventArgs e)
        {
            txtDeliveryVipClientId.Enabled = true;
            txtDeliveryVipSecret.Enabled = true;
            txtDeliveryVipMerchant.Enabled = true;

            btnDeliveryVipIniciar.Enabled = true;
            btnDeliveryVipParar.Enabled = false;
        }

        private void btnDeliveryVipBuscarPedido_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_deliveryVipId))
            {
                var service = new DeliveryVipService();
                var result = service.Order(txtDeliveryVipToken.Text, _deliveryVipId);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnDeliveryVipAceitar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_deliveryVipId))
            {
                var service = new DeliveryVipService();
                var result = service.Confirm(txtDeliveryVipToken.Text, _deliveryVipId);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnDeliveryVipCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_deliveryVipId))
            {
                var service = new DeliveryVipService();
                var result = service.RequestCancellation(txtDeliveryVipToken.Text, _deliveryVipId);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }


        private void gridDeliveryVip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridDeliveryVip.Rows.Count)
            {
                _deliveryVipId = gridDeliveryVip.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void deliveryVip()
        {
            try
            {
                //while (btnIorion9Parar.Enabled)
                //{
                var service = new DeliveryVipService();
                var orderResult = service.EventPooling(txtDeliveryVipToken.Text, txtDeliveryVipMerchant.Text);
                if (orderResult.Success)
                {
                    _deliveryVipOrders = orderResult.Result.ToList();

                    WriteGridDeliveryVip();
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
                }

                //Thread.Sleep(30000);
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridDeliveryVipDelegate();
        private void WriteGridDeliveryVip()
        {
            if (gridDeliveryVip.InvokeRequired)
            {
                var d = new WritelstGridDeliveryVipDelegate(WriteGridDeliveryVip);
                Invoke(d, new object[] { });
            }
            else
            {
                gridDeliveryVip.DataSource = _deliveryVipOrders.ToList();
                gridDeliveryVip.Refresh();
            }
        }

        #endregion

        #region Wedo

        private async void btnWedoIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeliveryVipClientId.Text))
            {
                MessageBox.Show("Campo ClientId Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryVipSecret.Text))
            {
                MessageBox.Show("Campo Secret Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtDeliveryVipMerchant.Text))
            {
                MessageBox.Show("Campo Merchant Obrigatório");
                return;
            }

            txtWedoToken.Enabled = false;

            btnWedoIniciar.Enabled = false;
            btnWedoParar.Enabled = true;

            await Task.Run(() => wedo());
        }

        private void wedo()
        {
            try
            {
                var service = new WedoService(txtWedoToken.Text);
                var orderResult = service.Polling();
                if (orderResult.Success)
                {
                    _WedoOrders = orderResult.Result.data;

                    WriteGridWedo();
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
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

        private void btnWedoParar_Click(object sender, EventArgs e)
        {
            txtWedoToken.Enabled = true;

            btnWedoIniciar.Enabled = true;
            btnWedoParar.Enabled = false;
        }

        private void btnWedoPedido_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_wedoId))
            {
                var service = new WedoService(txtWedoToken.Text);
                var result = service.Order(_wedoId);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnWedoIntegrado_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_wedoId))
            {
                var service = new WedoService(txtWedoToken.Text);
                var dados = new List<Wedo.Domain.acknowledgmentOrder>();
                dados.Add(new Wedo.Domain.acknowledgmentOrder { correlationId = _wedoId, status = Wedo.Enum.OrderStatus.APPROVED });

                var result = service.Status(dados);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnWedoCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_wedoId))
            {
                var service = new WedoService(txtWedoToken.Text);
                var dados = new List<Wedo.Domain.acknowledgmentOrder>();
                dados.Add(new Wedo.Domain.acknowledgmentOrder { correlationId = _wedoId, status = Wedo.Enum.OrderStatus.CANCELLED });

                var result = service.Status(dados);
                if (result.Success)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione o pedido");
            }
        }

        private void btnWedoEvento_Click(object sender, EventArgs e)
        {
            var service = new WedoService(txtWedoToken.Text);
            var dados = new List<Wedo.Domain.acknowledgmentEvent>();
            dados.Add(new Wedo.Domain.acknowledgmentEvent { event_id = "66d9f88d9fa96f2f1d7107db", integrated = true });

            var result = service.Acknowledgment(dados);
            if (result.Success)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }


        private delegate void WritelstGridWedoDelegate();
        private void WriteGridWedo()
        {
            if (gridWedo.InvokeRequired)
            {
                var d = new WritelstGridWedoDelegate(WriteGridWedo);
                Invoke(d, new object[] { });
            }
            else
            {
                gridWedo.DataSource = _WedoOrders.ToList();
                gridWedo.Refresh();
            }
        }

        private void gridWedo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridWedo.Rows.Count)
            {
                _wedoId = gridWedo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }


        #endregion

        #region BigFish
        private void btnBigFishIniciar_Click(object sender, EventArgs e)
        {
            bigFishIniciar();
        }
        private void btnBigFishParar_Click(object sender, EventArgs e)
        {
            txtBigFishURL.Enabled = true;
            txtBigFishUsuario.Enabled = true;
            txtBigFishSenha.Enabled = true;
            btnBigFishIniciar.Enabled = true;
            btnBigFishParar.Enabled = false;
            btnBigFishBuscarPedido.Enabled = false;
            btnBigFishNovo.Enabled = false;
            btnBigFishPago.Enabled = false;
            btnBigFishEnviado.Enabled = false;
            btnBigFishEntregue.Enabled = false;
            btnBigFishCancelado.Enabled = false;
            btnBigFishImportado.Enabled = false;
            btnBigFishObterCliente.Enabled = false;
        }

        public async void bigFishIniciar()
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            txtBigFishURL.Enabled = false;
            txtBigFishUsuario.Enabled = false;
            txtBigFishSenha.Enabled = false;
            btnBigFishIniciar.Enabled = false;
            btnBigFishParar.Enabled = true;
            btnBigFishBuscarPedido.Enabled = true;
            btnBigFishNovo.Enabled = true;
            btnBigFishPago.Enabled = true;
            btnBigFishEnviado.Enabled = true;
            btnBigFishEntregue.Enabled = true;
            btnBigFishCancelado.Enabled = true;
            btnBigFishImportado.Enabled = true;
            btnBigFishObterCliente.Enabled = true;
            await Task.Run(() => bigFish());
        }

        private void bigFish()
        {
            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);

            try
            {
                //while (btnMultiPedidoParar.Enabled)
                //{
                var orderResult = service.Orders();
                if (orderResult.Success)
                {
                    _bigFishOrders = orderResult.Result.orders;

                    WriteGridBigFish();
                }
                else
                {
                    MessageBox.Show(orderResult.Message);
                    return;
                }

                //Thread.Sleep(30000);
                //}
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private delegate void WritelstGridBigFishDelegate();
        private void WriteGridBigFish()
        {
            if (gridBigFish.InvokeRequired)
            {
                var d = new WritelstGridBigFishDelegate(WriteGridBigFish);
                Invoke(d, new object[] { });
            }
            else
            {
                gridBigFish.DataSource = _bigFishOrders.ToList();
                gridBigFish.Refresh();
            }
        }

        private void gridBigFish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridBigFish.Rows.Count)
            {
                _bigFishId = gridBigFish.Rows[e.RowIndex].Cells[0].Value.ToString();
                _bigFishClientDocument = gridBigFish.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (string.IsNullOrEmpty(_bigFishClientDocument))
                    _bigFishClientDocument = gridBigFish.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnBigFishBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Order(_bigFishId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishNovo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Status(_bigFishId, BigFish.Enum.OrderStatus.Novo);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishPago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Status(_bigFishId, BigFish.Enum.OrderStatus.Pago);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishEnviado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Status(_bigFishId, BigFish.Enum.OrderStatus.Enviado);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishEntregue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Status(_bigFishId, BigFish.Enum.OrderStatus.Entregue);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishCancelado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Status(_bigFishId, BigFish.Enum.OrderStatus.Cancelado);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishImportado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.Acknowledge(_bigFishId);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }

        private void btnBigFishObterCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBigFishURL.Text))
            {
                MessageBox.Show("Campo URL Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishUsuario.Text))
            {
                MessageBox.Show("Campo Usuário Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(txtBigFishSenha.Text))
            {
                MessageBox.Show("Campo Senha Obrigatório");
                return;
            }

            if (string.IsNullOrEmpty(_bigFishId))
            {
                MessageBox.Show("Selecione o registro");
                return;
            }

            var service = new BigFishService(txtBigFishURL.Text, txtBigFishUsuario.Text, txtBigFishSenha.Text);
            var orderResult = service.GetCustomer(_bigFishClientDocument);
            if (orderResult.Success)
            {
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show(orderResult.Message);
            }
        }
        #endregion

        #region VMarket

        public List<pedido_listar> vMarketOrders { get; set; }

        private void btnVMarketGerarToken_Click(object sender, EventArgs e)
        {
            var service = new VMarketService();
            var result = service.Autenticar(txtVMarketEmail.Text, txtVMarketSenha.Text);
            if (result.Success)
            {
                txtVMarketToken.Text = result.Result.token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void btnVMarketBuscarPedidos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVMarketToken.Text))
            {
                MessageBox.Show("Gere o token");
            }
            else
            {
                vMarketOrders = new List<pedido_listar>();

                var inicio = DateTime.Now.AddMonths(-1);
                var fim = DateTime.Now;

                var service = new VMarketService();
                var result = service.PedidoListar(txtVMarketToken.Text, inicio, fim, 1000000);
                if (result.Success)
                {
                    vMarketOrders.AddRange(result.Result.data);
                    WriteGridVMarket();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void btnVMarketBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVMarketToken.Text))
            {
                MessageBox.Show("Gere o token");
            }
            else
            {
                var service = new VMarketService();
                var result = service.PedidoDetalhe(txtVMarketToken.Text, 1890692);
                if (result.Success)
                {
                    //txtVMarketToken.Text = result.Result.token;
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        private delegate void WritelstGridVMarketDelegate();
        private void WriteGridVMarket()
        {
            if (gridBigFish.InvokeRequired)
            {
                var d = new WritelstGridVMarketDelegate(WriteGridVMarket);
                Invoke(d, new object[] { });
            }
            else
            {
                gridVMarket.DataSource = vMarketOrders.ToList();
                gridVMarket.Refresh();
            }
        }

        #endregion

        #region Tray

        private void btnTrayGerarToken_Click(object sender, EventArgs e)
        {
            var service = new TrayService(txtTrayURL.Text);
            var result = service.Auth(txtTrayKey.Text, txtTraySecret.Text, txtTrayCode.Text);
            if (result.Success)
            {
                txtTrayToken.Text = result.Result.access_token;
            }
            else
            {
                MessageBox.Show(result.Message);
            }

        }

        private void btnTrayPedidos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrayToken.Text))
            {
                MessageBox.Show("Gere o token");
            }
            else
            {
                _trayOrders = new List<Tray.Domain.order>();

                var filtros = new Tray.Domain.orderFilters
                {
                    //inicio = DateTime.Now,
                    //fim = DateTime.Now
                    inicio = Convert.ToDateTime("25/03/2025"),
                    fim = Convert.ToDateTime("30/03/2025")
                };

                var service = new TrayService(txtTrayURL.Text);
                var result = service.Orders(txtTrayToken.Text, filtros);
                if (result.Success)
                {
                    foreach (var item in result.Result.Orders)
                        _trayOrders.Add(item.Order);
                    WriteGridTray();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void btnTrayPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrayToken.Text))
            {
                MessageBox.Show("Gere o token");
                return;
            }

            if (string.IsNullOrEmpty(_trayId))
            {
                MessageBox.Show("Selecione o pedido");
                return;
            }


            var service = new TrayService(txtTrayURL.Text);
            var result = service.Order(txtTrayToken.Text, _trayId);
            if (result.Success)
            {
            }
            else
            {
                MessageBox.Show(result.Message);
            }

        }

        private void gridTray_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gridTray.Rows.Count)
            {
                _trayId = gridTray.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private delegate void WritelstGridTraytDelegate();
        private void WriteGridTray()
        {
            if (gridTray.InvokeRequired)
            {
                var d = new WritelstGridTraytDelegate(WriteGridTray);
                Invoke(d, new object[] { });
            }
            else
            {
                gridTray.DataSource = _trayOrders.ToList();
                gridTray.Refresh();
            }
        }

        

        private void btnTrayFormaPagamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrayToken.Text))
            {
                MessageBox.Show("Gere o token");
                return;
            }
            

            var service = new TrayService(txtTrayURL.Text);
            var result = service.PaymentsMethods(txtTrayToken.Text);
            if (result.Success)
            {
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        #endregion

        
    }
}

