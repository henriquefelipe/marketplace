using Cinddi.Utils;
using MarketPlace;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using Cinddi.Domain;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cinddi.Service
{
    public class CinddiService
    {       
        public CinddiService() { }        

        public GenericResult<List<ResponseOrders>> Orders(string token)
        {
            var result = new GenericResult<List<ResponseOrders>>();
            try
            {
                var url = string.Format("{0}{1}{2}", Constants.URL, Constants.URL_ORDERS, token);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {                                       
                    result.Result = JsonConvert.DeserializeObject<List<ResponseOrders>>(response.Content);
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

        public GenericResult<Pedido> Order(string token, string id)
        {
            var result = new GenericResult<Pedido>();
            try
            {
                var url = string.Format("{0}{1}{2}&numeropedido={3}", Constants.URL, token, Constants.URL_ORDER, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string cleanXml = Regex.Replace(response.Content, @"<[a-zA-Z\-]+><\/[a-zA-Z\-]+>", new MatchEvaluator((m) => ""));
                    result.Result = cleanXml.DeserializeXml<Pedido>();                    
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

        public GenericSimpleResult Status(string token, string id, string status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}status={2}&chave={3}&numeropedido={4}", Constants.URL, Constants.URL_ORDER_STATUS, status, token, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
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
