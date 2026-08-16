using ADAC.Domain;
using MarketPlace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADAC.Service
{
    public class ADACService
    {
        private string _urlBase = "";
        private string _token = "";
        private string _loja = "";

        public ADACService(string url, string token, string loja)
        {
            _urlBase = url;
            _token = token;
            _loja = loja;
        }

        public GenericResult<order_retorno> Pedidos(bool pedidosPendentes = true)
        {
            var result = new GenericResult<order_retorno>();
            try
            {
                var urlPendente = pedidosPendentes ? "/pending" : "";

                var url = string.Format($"{_urlBase}/api/orders{urlPendente}?storeId={_loja}");
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-api-key", _token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_retorno>(response.Content);
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

        public GenericSimpleResult Consume(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format($"{_urlBase}/api/orders/{id}/consume");
                var client = new RestClient(url);
                var request = new RestRequest(Method.PATCH);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-api-key", _token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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

        public GenericSimpleResult Status(string id, string status, string customerName = "", string customerPhone = "")
        {
            var result = new GenericSimpleResult();
            try
            {
                var body = new
                {
                    order_id = id,
                    status,
                    customer = new
                    {
                        name = customerName,
                        phone = customerPhone
                    } 
                };

                var url = string.Format($"{_urlBase}/api/webhook/order-status");
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer okRV3CgfBWs+4zA8BPkqptEWbH05MvgfA+V+WA2tsqY=");
                request.AddHeader("x-api-key", _token);
                request.AddJsonBody(body);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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
