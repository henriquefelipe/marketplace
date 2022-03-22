using Accon.Domain;
using Accon.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Accon.Service
{
    public class AcconService
    {       
        public AcconService() { }
               
        public GenericResult<tokenAuth> OathToken(string email, string password, string network)
        {
            var result = new GenericResult<tokenAuth>();

            var data = new
            {
                email,
                password,
                network
            };

            var json = JsonConvert.SerializeObject(data);
            var client = new RestClient(Constants.URL_BASE + Constants.URL_TOKEN);            
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse responseToken = client.Execute(request);

            if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<tokenAuth>(responseToken.Content);
                result.Success = true;
            }
            else
            {
                result.Message = responseToken.Content;
            }

            return result;
        }

        public GenericResult<List<order>> Orders(string token, string network)
        {
            var result = new GenericResult<List<order>>();
            
            var client = new RestClient(Constants.URL_BASE + Constants.URL_ORDERS);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("X-NETWORK-ID", network);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Json = response.Content;
                result.Result = JsonConvert.DeserializeObject<List<order>>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            return result;
        }

        public GenericSimpleResult OrdersStatus(string token, string network, string reference)
        {
            var data = new { };

            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}{2}/next", Constants.URL_BASE, Constants.URL_ORDER, reference);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("X-NETWORK-ID", network);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NoContent)
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
