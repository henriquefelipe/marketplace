using MultiPedido.Domain;
using MultiPedido.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace MultiPedido.Service
{
    public class MultiPedidoService
    {    
        private string _token {  get; set; }
        public MultiPedidoService(string token)
        {
            _token = token;
        }


        public GenericResult<login> Login()
        {
            var result = new GenericResult<login>();

            var url = string.Format("{0}{1}", Constants.URL_BASE_PRODUCAO_PADRAO, Constants.URL_LOGIN);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-integration-token", _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<login>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericSimpleResult Status(string jwttoken, string codigoEstabelecimento, string codigoPedido, string status)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                status = status
            };

            var url = string.Format("{0}restaurant/{1}/order/{2}/status", Constants.URL_BASE_PRODUCAO_PADRAO, codigoEstabelecimento, codigoPedido);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + jwttoken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {                
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<List<order>> Orders()
        {
            var result = new GenericResult<List<order>>();

            var url = string.Format("{0}{1}", Constants.URL_BASE_PRODUCAO, Constants.URL_POLL);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);
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


        public GenericSimpleResult Acknowledge(string orderid) 
        {
            var result = new GenericSimpleResult();
            try
            {               
                var url = string.Format("{0}{1}{2}", Constants.URL_BASE_PRODUCAO, Constants.URL_ACKNOWLEDGE, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", _token);
                request.AddHeader("Content-Type", "application/json");                
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
