using Woocommerce.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Woocommerce.Service
{
    public class WoocommerceService
    {      
        private string _url { get; set; }
        private string _key { get; set; }
        private string _secret { get; set; }

        public WoocommerceService() { }

        public WoocommerceService(string url, string key, string secret) 
        {
            _url = url;
            _key = key;
            _secret = secret;
        }

        public GenericResult<List<order>> Orders(string parametros = "")
        {
            var result = new GenericResult<List<order>>();

            var url = string.Format("{0}/wp-json/wc/v3/orders?consumer_key={1}&consumer_secret={2}&{3}", _url, _key, _secret, parametros);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);            
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<order>>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericSimpleResult Update(int id, string status)
        {
            var dados = new
            {
                status = status
            };

            var data = JsonConvert.SerializeObject(dados);

            var result = new GenericSimpleResult();
            var url = string.Format("{0}/wp-json/wc/v3/orders/{1}?consumer_key={2}&consumer_secret={3}", _url, id, _key, _secret);
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
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
