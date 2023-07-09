using PixCommerce.Domain;
using PixCommerce.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PixCommerce.Service
{
    public class PixCommerceService
    {    
        private string _token {  get; set; }
        public PixCommerceService(string token)
        {
            _token = token;
        }

        public GenericResult<List<orders>> Orders()
        {
            var result = new GenericResult<List<orders>>();

            var url = string.Format("{0}{1}", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDERS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("TokenAPI", _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<orders>>(response.Content);
                if(result.Result == null)
                    result.Result = new List<orders>();
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }


        public GenericResult<order> Order(string orderid)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER, orderid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("TokenAPI", _token);
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

        public GenericSimpleResult Confirm(string orderid) 
        {
            var result = new GenericSimpleResult();
            try
            {               
                var url = string.Format("{0}{1}{2}", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER_CONFIRM, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("TokenAPI", _token);
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

        public GenericSimpleResult Production(string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}{2}/production", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER_CHANGE, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("TokenAPI", _token);
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

        public GenericSimpleResult InRoute(string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}{2}/inroute", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER_CHANGE, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("TokenAPI", _token);
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

        public GenericSimpleResult Final(string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}{2}/final", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER_CHANGE, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("TokenAPI", _token);
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

        public GenericSimpleResult Cancel(string orderid, string motivo = "Cancelado pelo o sistema")
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    reason = motivo
                };                

                var url = string.Format("{0}{1}{2}", Constants.URL_BASE_PRODUCAO, Constants.URL_ORDER_CANCEL, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("TokenAPI", _token);
                request.AddHeader("Content-Type", "application/json");
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
    }
}
