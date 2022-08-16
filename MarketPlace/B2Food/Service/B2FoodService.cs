using B2Food.Domain;
using B2Food.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace B2Food.Service
{
    public class B2FoodService
    {
        private string _token;
        private string _urlBase = Constants.URL_BASE;
        public B2FoodService(string token, bool teste = false)
        {
            _token = token;
            if (teste)
                _urlBase = Constants.URL_BASE_TESTE;
        }

        public GenericResult<List<long>> PedidosPendentes()
        {
            var genericResult = new GenericResult<List<long>>();

            try
            {
                var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDER_PENDENTES);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", _token));
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    genericResult.Result = JsonConvert.DeserializeObject<List<long>>(response.Content);
                    genericResult.Success = true;
                }
                else
                {
                    genericResult.Message = response.Content;
                }

                genericResult.Json = response.Content;
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }
            return genericResult;
        }

        public GenericResult<pedido> Order(string id)
        {
            var genericResult = new GenericResult<pedido>();

            try
            {
                var url = string.Format("{0}{1}", _urlBase, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", _token));
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    genericResult.Result = JsonConvert.DeserializeObject<pedido>(response.Content);
                    genericResult.Success = true;
                }
                else
                {
                    genericResult.Message = response.Content;
                }

                genericResult.Json = response.Content;
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }

            return genericResult;
        }

        public GenericSimpleResult Status(string id)
        {
            var genericResult = new GenericSimpleResult();

            try
            {
                var url = string.Format("{0}{1}/status", _urlBase, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", _token));
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    genericResult.Success = true;
                }
                else
                {
                    genericResult.Message = response.Content;
                }

                genericResult.Json = response.Content;
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }

            return genericResult;
        }

        public GenericSimpleResult AlterarStatus(int id, int status, int tempoParaEntrega = 0, string entregadorNome = "", string entregadorTelefone = "")
        {
            var data = new
            {
                id = id,
                Status = status,
                TempoParaEntrega = tempoParaEntrega,
                EntregadorNome = entregadorNome,
                EntregadorTelefone = entregadorTelefone,
            };

            var genericResult = new GenericSimpleResult();

            try
            {
                var url = string.Format("{0}status", _urlBase);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Authorization", string.Format("bearer {0}", _token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    genericResult.Success = true;
                }
                else
                {
                    genericResult.Message = response.Content;
                }

                genericResult.Json = response.Content;
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }

            return genericResult;
        }
    }
}
