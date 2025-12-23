using DegustaAi.Domain;
using DegustaAi.Enum;
using DegustaAi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace DegustaAi.Service
{
    public class DegustaAiService
    {
        private string _urlHost;
        private string _tokenSW;

        public DegustaAiService(string host)
        {
            _urlHost = host;
        }

        public DegustaAiService(string host, string tokenSW)
        {
            _urlHost = host;
            _tokenSW = tokenSW;
        }

        public GenericResult<response> Orders(string token, string parametros, DateTime dataAtualizacao)
        {
            var result = new GenericResult<response>();

            var parametrosDataAtualizacao = "";
            if(dataAtualizacao != DateTime.MinValue)
            {
                parametrosDataAtualizacao = $"data_atualizacao={dataAtualizacao.ToString("yyyy-MM-dd")}";
            }

            var url = $"https://api.{_urlHost}{Constants.URL_GET_ORDERS}?{parametrosDataAtualizacao}{parametros}";
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            if(!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }

            result.Url = url;

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> ChangeStatus(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_CHANGE_STATUS}?pedido_ref={pedido_ref}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> Cancel(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();
            try
            {
                var url = $"https://api.{_urlHost}{Constants.URL_CANCELA_PEDIDO}?pedido_ref={pedido_ref}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Bearer", token);
                request.AddHeader("Content-Type", "application/json");
                if (!string.IsNullOrEmpty(_tokenSW))
                {
                    request.AddHeader("integrador-token", _tokenSW);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                    result.Success = true;

                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        #region Fidelidade
        public GenericResult<responseToken> LoginFidelidade(string email, string password)
        {
            var result = new GenericResult<responseToken>();
            try
            {
                var data = new
                {
                    email,
                    password,
                    remember_me = true
                };

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var url = $"https://api.{_urlHost}{Constants.URL_AUTH_LOGIN}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseToken>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<responseRegistraPontuacao> RegistraPontos(string token, registraPontuacaoViewModel data)
        {
            var result = new GenericResult<responseRegistraPontuacao>();
            try
            {
                var url = $"https://api.{_urlHost}{Constants.URL_REGISTRA_PONTOS}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseRegistraPontuacao>(response.Content);
                    if (result.Result.status == FidelidadeStatus.SUCCESS)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<responseResgataPremio> ResgataPremio(string token, regastaPremioViewModel data)
        {
            var result = new GenericResult<responseResgataPremio>();
            try
            {
                var url = $"https://api.{_urlHost}{Constants.URL_RESGASTA_PREMIO}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (response.Content.Contains("error"))
                    {
                        var responseErro = JsonConvert.DeserializeObject<responseErro>(response.Content);
                        result.Message = responseErro.message;
                    }
                    else
                    {
                        result.Result = JsonConvert.DeserializeObject<responseResgataPremio>(response.Content);
                        if (result.Result.status == FidelidadeStatus.SUCCESS)
                        {
                            result.Success = true;
                        }
                        else
                        {
                            result.Message = result.Result.message;
                        }
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }


        public GenericResult<responseConsultaPremios> ConsultaPremios(string token)
        {
            var result = new GenericResult<responseConsultaPremios>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var url = $"https://api.{_urlHost}{Constants.URL_CONSULTA_PREMIOS}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseConsultaPremios>(response.Content);
                    if (result.Result.status == FidelidadeStatus.SUCCESS)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<responseRegistraPontuacao> ResumoUsuario(string token, string telefone)
        {
            var result = new GenericResult<responseRegistraPontuacao>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var url = $"https://api.{_urlHost}{Constants.URL_RESUMO_USUARIO}?telefone={telefone}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseRegistraPontuacao>(response.Content);
                    if (result.Result.status == FidelidadeStatus.SUCCESS)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<responseErro> CriaCadastro(string token, usuario data)
        {
            var result = new GenericResult<responseErro>();
            try
            {
                var url = $"https://api.{_urlHost}{Constants.URL_CRIA_CADASTRO}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Requested-With", "XMLHttpRequest");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseErro>(response.Content);
                    if (result.Result.status == FidelidadeStatus.SUCCESS)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        #endregion

        #region Mesa

        public GenericResult<response> OrdersMesa(string token, string parametros)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_GET_ORDERS_MESA}?{parametros}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> ChangeStatusMesa(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_CHANGE_STATUS_MESA}?pedido_ref={pedido_ref}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response_base> FecharMesa(string token, string codigoMesa, string formaPagamento)
        {
            var result = new GenericResult<response_base>();

            var url = $"https://api.{_urlHost}{Constants.URL_FECHAR_MESA}?codPdv={codigoMesa}&forma={formaPagamento}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response_base>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<notificationResult> NotificationsMesa(string token)
        {
            var result = new GenericResult<notificationResult>();

            var url = $"https://api.{_urlHost}{Constants.URL_GET_NOTIFICATIONS_MESA}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<notificationResult>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> NotificationsMesaDismiss(string token, string codigo)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_DISMISS_NOTIFICATION_MESA}?cod_notification={codigo}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_tokenSW))
            {
                request.AddHeader("integrador-token", _tokenSW);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        #endregion
    }
}
