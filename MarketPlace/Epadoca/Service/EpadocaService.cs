using Epadoca.Domain;
using Epadoca.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Epadoca.Service
{
    public class EpadocaService
    {
        private string _urlBase = Constants.URL_BASE;

        public EpadocaService() { }

        public EpadocaService(string urlBase)
        {
            _urlBase = urlBase;
        }

        public GenericResult<token> Token(string username, string password)
        {
            var result = new GenericResult<token>();

            var client = new RestClient(_urlBase + Constants.URL_TOKEN);
            var request = new RestRequest(Method.POST);            
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);           
            IRestResponse responseToken = client.Execute(request);

            if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                result.Success = true;
            }
            else
            {
                result.Message = responseToken.StatusDescription;
            }

            return result;
        }

        public GenericResult<List<order>> Orders(string token, string store)
        {
            var result = new GenericResult<List<order>>();

            var url = string.Format("{0}{1}/{2}?tipo=Ecommerce,EcommerceAgendado,Encomenda,CardapioLoja", _urlBase, Constants.URL_MANAGER_PEDIDO_ABERTO, store);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<order>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericResult<order> Order(string token, string guid)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_MANAGER_PEDIDO_DETALHE, guid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                var resultItens = Itens(token, guid);
                if (resultItens.Success)
                {
                    result.Result.itens = resultItens.Result;
                    result.Success = true;
                    result.Json = response.Content + resultItens.Json;
                }
                else
                {
                    result.Message = resultItens.Message;
                }
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericResult<List<item>> Itens(string token, string guid)
        {
            var result = new GenericResult<List<item>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_MANAGER_PEDIDO_PRODUTOS, guid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<item>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult Aceitar(string token, string guid)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                guid = guid
            };

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_MANAGER_PEDIDO_PREPARAR_PEDIDO);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {                
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult SaiuParaEntrega(string token, string guid)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                guid = guid
            };

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_MANAGER_PEDIDO_ENTREGARPEDIDO);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult Entregue(string token, string guid)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                guid = guid
            };

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_MANAGER_PEDIDO_FINALIZAR_PEDIDO);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult DisponivelParaRetirada(string token, string guid)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                guid = guid
            };

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_MANAGER_PEDIDO_PRONTO);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }


        #region Fidelidade

        public GenericResult<List<fidelidade_status_retorno>> FidelidadeStatus(string token, string codigo, string nome, string email, string celular, string documento)
        {
            var result = new GenericResult<List<fidelidade_status_retorno>>();

            var data = new
            {
                codigo,
                nome,
                email,
                celular,
                documento
            };

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_FIDELIDADE_INTEGRACAO_STATUS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<fidelidade_status_retorno>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericResult<fidelidade_consultar_cupom> FidelidadeConsultarCupom(string token, string cupom)
        {
            var result = new GenericResult<fidelidade_consultar_cupom>();

            var url = string.Format("{0}{1}{2}", _urlBase, Constants.URL_FIDELIDADE_INTEGRACAO_CONSULTAR_CUPOM, cupom);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));            
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<fidelidade_consultar_cupom>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult FidelidadeUtilizarCupom(string token, string codigoExterno, string nome, string email, string celular, string documento, string cupom)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                codigoExterno,
                nome,
                email,
                celular,
                documento
            };

            var url = string.Format("{0}{1}{2}", _urlBase, Constants.URL_FIDELIDADE_INTEGRACAO_UTILIZAR_CUPOM, cupom);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if(response.Content == "Cupom Utilizado")
                    result.Success = true;
                else
                    result.Message = response.Content;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult FidelidadeUtilizarCupomManual(string token, string codigoExterno, string nome, string email, string celular, string documento, string cupom)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                codigoExterno,
                nome,
                email,
                celular,
                documento
            };

            var url = string.Format("{0}{1}{2}", _urlBase, Constants.URL_FIDELIDADE_INTEGRACAO_UTILIZAR_CUPOM_MANUAL, cupom);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Content == "Cupom Utilizado")
                    result.Success = true;
                else
                    result.Message = response.Content;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericSimpleResult FidelidadeAdicionarPedido(string token, fidelidade_adicionar_pedido model)
        {
            var result = new GenericSimpleResult();            

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_FIDELIDADE_INTEGRACAO_PEDIDO);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Content == "Cupom Utilizado")
                    result.Success = true;
                else
                    result.Message = response.Content;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        #endregion
    }

}
