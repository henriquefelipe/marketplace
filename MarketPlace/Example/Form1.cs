using Ifood.Domain;
using Ifood.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        public string ifoodToken { get; set; }
        public List<order> ifoodOrders { get; set; }

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
                    var marketPlace = JsonConvert.DeserializeObject<MarketPlace>(fileJson);
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
                    }
                }
            }

            ifoodOrders = new List<order>();
            gridIfood.DataSource = ifoodOrders.ToList();
            gridIfood.Refresh();
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
            var ifoodService = new IfoodService();

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
                            ifoodToken = oathTokenResult.Result.access_token;
                        }
                        else
                        {
                            MessageBox.Show(oathTokenResult.Message);                            
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(ifoodToken))
                    {
                        var eventPollingResult = ifoodService.EventPolling(ifoodToken);

                        if (eventPollingResult.Success)
                        {
                            var eventsIds = new List<eventAcknowledgment>();

                            foreach (var poolingEvent in eventPollingResult.Result)
                            {
                                if (poolingEvent.code == PoolingEventStatusCode.PLACED)
                                {
                                    var orderResult = ifoodService.Orders(ifoodToken, poolingEvent.correlationId);
                                    if (orderResult.Success)
                                    {
                                        var order = ifoodOrders.FirstOrDefault(f => f.id == orderResult.Result.id);
                                        if (order == null)
                                        {
                                            ifoodOrders.Add(orderResult.Result);
                                        }

                                        WriteGridIfoodConsole();
                                    }
                                    else
                                    {
                                        MessageBox.Show(orderResult.Message);
                                        return;
                                    }
                                }

                                eventsIds.Add(new eventAcknowledgment { id = poolingEvent.id });
                            }

                            var eventAcknowledgmentResult = ifoodService.EventAcknowledgment(ifoodToken, eventsIds);
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
            if(btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }

            var ifoodService = new IfoodService();
        }

        private void btnIfoodConfirmado_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private void btnIfoodSaiuParaSerEntregue_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private void btnIfoodRejeitado_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private void btnIfoodCancelamento_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private void btnIfoodCancelamentoAceita_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private void btnIfoodCancelamentoRejeita_Click(object sender, EventArgs e)
        {
            if (btnIfoodIniciar.Enabled)
            {
                MessageBox.Show("Inicia o aplicativo");
                return;
            }
        }

        private delegate void WritelstGridIfoodDelegate();
        private void WriteGridIfoodConsole()
        {
            if (gridIfood.InvokeRequired)
            {
                var d = new WritelstGridIfoodDelegate(WriteGridIfoodConsole);
                Invoke(d, new object[] { });
            }
            else
            {
                gridIfood.DataSource = ifoodOrders.ToList();
                gridIfood.Refresh();
            }
        }

        #endregion

    }
}
