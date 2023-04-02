using UberEats.Domain;
using UberEats.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace UberEats.Service
{
    public class UberEatsService
    {       
        public UberEatsService() { }
               
        public GenericResult<token> OathToken(string client_id, string client_secret, string scope = "")
        {
            if(string.IsNullOrEmpty(scope))
            {
                scope = Constants.SCOPE_EATS_STORE_ORDERS_READ + " " + Constants.SCOPE_EATS_ORDER + " " + Constants.SCOPE_EATS_STORE_ORDERS_CANCEL;
            }

            var result = new GenericResult<token>();
            var client = new RestClient(Constants.URL_TOKEN);            
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", scope);
            IRestResponse responseToken = client.Execute(request);

            if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                result.Success = true;
            }
            else
            {
                result.Message = responseToken.Content;
            }

            return result;
        }

        public GenericResult<orders_result> Orders(string token, string merchantId)
        {
            var result = new GenericResult<orders_result>();

            var url = string.Format("{0}{1}/created-orders?limit=5", Constants.URL_CREATE_ORDERS_CREATED, merchantId);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<orders_result>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<order> Order(string token, string id)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}", Constants.URL_ORDER, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        public GenericSimpleResult Accept(string token, string id)
        {
            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}/accept_pos_order", Constants.URL_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));           
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

        public GenericSimpleResult Deny(string token, string id)
        {
            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}/deny_pos_order", Constants.URL_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
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

        public GenericSimpleResult Cancel(string token, string id)
        {
            var dados = new
            {
                reason = "RESTAURANT_TOO_BUSY"
            };

            var data = JsonConvert.SerializeObject(dados);

            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}/cancel", Constants.URL_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
