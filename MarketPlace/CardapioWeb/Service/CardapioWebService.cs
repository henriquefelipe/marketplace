using MarketPlace;
using Newtonsoft.Json;
using CardapioWeb.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioWeb.Service
{
    public class CardapioWebService
    {
        private string _url = "https://integracao.cardapioweb.com/";
        private string _token = "";
        
        public CardapioWebService(string token) 
        {
            _token = token;
        }

        public CardapioWebService(string token, string url) 
        {
            _token = token;
            _url = url;
        }

        public GenericResult<List<responseOrders>> Orders()
        {
            var result = new GenericResult<List<responseOrders>>();
            try
            {                
                var client = new RestClient(_url + "api/partner/v1/orders");
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-API-KEY", _token);                

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<responseOrders>>(response.Content);
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

        public GenericResult<order> Order(string id)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericSimpleResult Confirm(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}/confirm");
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Ready(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}/ready");
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Delivered(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}/delivered");
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Finalize(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}/finalize");
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Cancel(string id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + $"api/partner/v1/orders/{id}/cancel");
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-API-KEY", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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
