using Wedo.Domain;
using Wedo.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Wedo.Service
{
    public class WedoService
    {
        private string _token = "";
        public WedoService(string token) 
        { 
            _token = token;
        }
               
        public GenericResult<responsePooling> Polling()
        {
            var result = new GenericResult<responsePooling>();

            var url = string.Format("{0}{1}", Constants.URL, Constants.URL_POOLING);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<responsePooling>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<order> Order(string id)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}", Constants.URL, Constants.URL_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
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

        public GenericSimpleResult Acknowledgment(List<acknowledgmentEvent> dados)
        {
            var data = JsonConvert.SerializeObject(dados);

            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}", Constants.URL, Constants.URL_ACKNOWLEDGMENT);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            return result;
        }

        public GenericSimpleResult Status(List<acknowledgmentOrder> dados)
        {
            var data = JsonConvert.SerializeObject(dados);

            var result = new GenericSimpleResult();
            var url = string.Format("{0}{1}", Constants.URL, Constants.URL_STATUSES);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
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
