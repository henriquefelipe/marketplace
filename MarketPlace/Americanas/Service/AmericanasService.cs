using Americanas.Domain;
using Americanas.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Americanas.Service
{
    public class AmericanasService
    {
        private string _urlBase;
        public AmericanasService(string urlBase) 
        {
            _urlBase = urlBase;
        }

        public GenericResult<token> OathToken(string client_id, string client_secret)
        {
            var result = new GenericResult<token>();
            try
            {
                var url = _urlBase + Constants.URL_OAUTH;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("clientId", client_id);
                request.AddParameter("clientSecret", client_secret);                                

                IRestResponse responseToken = client.Execute(request);

                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                    result.Success = true;
                }
                else
                {
                    //var error = JsonConvert.DeserializeObject<error_return>(responseToken.Content);
                    //result.Message = responseToken.StatusDescription + $" => {error.error.message}";
                }

                result.StatusCode = responseToken.StatusCode;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }


        public GenericResult<List<orders>> Orders(string storeId, string token)
        {
            var result = new GenericResult<List<orders>>();

            var url = string.Format("{0}{1}{2}{3}", _urlBase,  Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<orders>>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<pedido> Order(string id)
        {
            var result = new GenericResult<pedido>();

            //var url = string.Format("{0}{1}", Constants.URL_ORDER, id);
            //var client = new RestClient(url);
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", string.Format("bearer {0}", _token));
            //request.AddHeader("Content-Type", "application/json"); 
            //IRestResponse response = client.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    result.Result = JsonConvert.DeserializeObject<pedido>(response.Content);
            //    result.Success = true;                
            //}
            //else
            //{
            //    result.Message = response.Content;
            //}

            //result.Json = response.Content;

            return result;
        }

        public GenericSimpleResult Status(string id)
        {
            var result = new GenericSimpleResult();
            //var url = string.Format("{0}{1}/status", Constants.URL_ORDER, id);
            //var client = new RestClient(url);
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", string.Format("bearer {0}", _token));           
            //IRestResponse response = client.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            //{
            //    result.Success = true;
            //}
            //else
            //{
            //    result.Message = response.Content;
            //}

            return result;
        }

        public GenericSimpleResult AlterarStatus(string id, int status, int tempoParaEntrega = 0, string entregadorNome = "", string entregadorTelefone = "")
        {
            var data = new
            {
                id = id,
	            Status = status,
	            TempoParaEntrega = tempoParaEntrega,
                EntregadorNome = entregadorNome,
                EntregadorTelefone = entregadorTelefone,
            };

            var result = new GenericSimpleResult();
            //var url = string.Format("{0}status", Constants.URL_ORDER);
            //var client = new RestClient(url);
            //var request = new RestRequest(Method.PUT);
            //request.AddHeader("Authorization", string.Format("bearer {0}", _token));
            //request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            //{
            //    result.Success = true;
            //}
            //else
            //{
            //    result.Message = response.Content;
            //}

            return result;
        }       
    }
}
