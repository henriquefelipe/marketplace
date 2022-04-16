using B2Food.Domain;
using B2Food.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace B2Food.Service
{
    public class B2FoodService
    {
        private string _token;
        public B2FoodService(string token) 
        {
            _token = token;
        }
               
        public GenericResult<List<long>> PedidosPendentes()
        {
            var result = new GenericResult<List<long>>();

            var url = string.Format("{0}{1}", Constants.URL_ORDER, Constants.URL_ORDER_PENDENTES);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", _token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<long>>(response.Content);
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

            var url = string.Format("{0}{1}", Constants.URL_ORDER, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", _token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<pedido>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        public GenericSimpleResult Status(string id)
        {
            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}/status", Constants.URL_ORDER, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", _token));           
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            return result;
        }

        public GenericSimpleResult AlterarStatus(string id)
        {
            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}/status", Constants.URL_ORDER, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", string.Format("bearer {0}", _token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            return result;
        }       
    }
}
