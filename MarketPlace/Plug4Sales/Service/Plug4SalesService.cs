using MarketPlace;
using Newtonsoft.Json;
using Plug4Sales.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plug4Sales.Service
{
    public class Plug4SalesService
    {
        private string _url = "http://api.plug4sales.io/";
        
        public Plug4SalesService() {}

        public GenericResult<result_token> Token(string ClientId, string ClientSecret)
        {
            var result = new GenericResult<result_token>();
            try
            {
                var data = new
                {
                    ClientId, ClientSecret
                };

                var client = new RestClient(_url + "authentication/users/accessToken");
                var request = new RestRequest(Method.POST);                
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result_token>(response.Content);
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

        public GenericResult<result_orders> Orders(string token, List<order> orders)
        {
            var result = new GenericResult<result_orders>();
            try
            {                
                var client = new RestClient(_url + "orders");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("application/json", JsonConvert.SerializeObject(orders), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result_orders>(response.Content);
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
    }
}
