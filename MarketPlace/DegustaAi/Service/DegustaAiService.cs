using DegustaAi.Domain;
using DegustaAi.Enum;
using DegustaAi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace DegustaAi.Service
{
    public class DegustaAiService
    {
        private string _urlHost;
        public DegustaAiService(string host)
        {
            _urlHost = host;
        }
        public GenericResult<response> Orders(string token, string parametros, DateTime dataAtualizacao)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_GET_ORDERS}?data_atualizacao={dataAtualizacao.ToString("yyyy-MM-dd")}{parametros}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
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

        public GenericResult<response> ChangeStatus(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_CHANGE_STATUS}?pedido_ref={pedido_ref}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
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
    }
}
