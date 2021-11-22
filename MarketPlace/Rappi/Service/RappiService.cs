using Rappi.Domain;
using Rappi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Service
{
    public class RappiService
    {
        private string _urlBase = "";
        public RappiService(string url)
        {
            _urlBase = url;
        }

        public GenericResult<token> Token(string client_id, string client_secret, bool desenvolvimento = false)
        {
            var result = new GenericResult<token>();

            var url = Constants.URL_TOKEN_PRO;
            if (desenvolvimento)
                url = Constants.URL_TOKEN_DEV;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            if (desenvolvimento)
                request.AddParameter("audience", "https://int-public-api-v2/api");
            else
                request.AddParameter("audience", "https://services.rappi.com.br/api/v2/restaurants-integrations-public-api");
            request.AddParameter("grant_type", "client_credentials");
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

        public GenericResult<List<order>> Orders(string token)
        {
            var result = new GenericResult<List<order>>();
            try
            {
                var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDERS);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (response.Content != "[]")
                    {
                        result.Result = JsonConvert.DeserializeObject<List<order>>(response.Content);
                    }
                    else
                    {
                        result.Result = new List<order>();
                    }

                    result.Success = true;
                    result.Json = response.Content;
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

        public GenericSimpleResult Take(string token, string order_id, int cookingTime = 0)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}{2}/take/{3}", _urlBase, Constants.URL_ORDER, order_id, cookingTime);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("x-authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {                    
                    result.Success = true;
                    result.Json = response.Content;
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

        public GenericSimpleResult Reject(string token, string order_id, string reason, string cancel_type)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    reason,
                    cancel_type
                };

                var url = string.Format("{0}{1}{2}/reject", _urlBase, Constants.URL_ORDER, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("x-authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                    result.Json = response.Content;
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

        public GenericSimpleResult ReadForPickup(string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}{2}/ready-for-pickup", _urlBase, Constants.URL_ORDER, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                    result.Json = response.Content;
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
    }
}
