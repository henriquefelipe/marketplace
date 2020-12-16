using OnPedido.Utils;
using MarketPlace;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using OnPedido.Domain;

namespace OnPedido.Service
{
    public class OnPedidoService
    {       
        public OnPedidoService() { }        

        public GenericResult<ResponseOrders> Orders(string token)
        {
            var result = new GenericResult<ResponseOrders>();
            try
            {
                var url = string.Format("{0}{1}{2}", Constants.URL, token, Constants.URL_ORDERS);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {                   
                    string cleanXml = Regex.Replace(response.Content, @"<[a-zA-Z\-]+><\/[a-zA-Z\-]+>", new MatchEvaluator((m) => ""));
                    result.Result = cleanXml.DeserializeXml<ResponseOrders>();
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

        public GenericResult<ResponseOrders> Order(string token, string id)
        {
            var result = new GenericResult<ResponseOrders>();
            try
            {
                var url = string.Format("{0}{1}{2}{3}", Constants.URL, token, Constants.URL_ORDER, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string cleanXml = Regex.Replace(response.Content, @"<[a-zA-Z\-]+><\/[a-zA-Z\-]+>", new MatchEvaluator((m) => ""));
                    result.Result = cleanXml.DeserializeXml<ResponseOrders>();                    
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

        public GenericResult<ResponseOrders> Status(string token, string id, string status)
        {
            var result = new GenericResult<ResponseOrders>();
            try
            {
                var url = string.Format("{0}{1}{2}{3}&idpedido={4}", Constants.URL, token, Constants.URL_STATUS, status, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string cleanXml = Regex.Replace(response.Content, @"<[a-zA-Z\-]+><\/[a-zA-Z\-]+>", new MatchEvaluator((m) => ""));                    
                    result.Result = cleanXml.DeserializeXml<ResponseOrders>();
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
