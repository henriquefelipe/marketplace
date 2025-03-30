using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using Tray.Domain;
using Tray.Utils;
using System;
using System.Collections.Generic;
using System.Net;

namespace Tray.Service
{
    public class TrayService
    {        
        private string _urlBase;

        public TrayService() { }

        public TrayService(string urlBase)
        {
            _urlBase = urlBase;
        }
        
        public GenericResult<authResult> Auth(string consumer_key, string consumer_secret, string code)
        {
            var result = new GenericResult<authResult>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_AUTH);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("consumer_key", consumer_key);
            request.AddParameter("consumer_secret", consumer_secret);
            request.AddParameter("code", code);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<authResult>(response.Content);
                result.Success = true;
            }
            else
            {                
                result.Message = response.StatusDescription + response.Content;             
            }

            return result;
        }

        public GenericResult<ordersResult> Orders(string access_token, orderFilters filtros)
        {
            var result = new GenericResult<ordersResult>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var parametros = $"&date={filtros.inicio.ToString("yyyy-MM-dd")},{filtros.fim.ToString("yyyy-MM-dd")}&limit={filtros.limit}";
            if(string.IsNullOrEmpty(filtros.sort))
            {
                parametros += $"&sort={filtros.sort}";
            }

            var client = new RestClient(_urlBase + Constants.URL_ORDERS + $"?access_token={access_token}{parametros}");
            var request = new RestRequest(Method.GET);            
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<ordersResult>(response.Content);                
                result.Success = true;                
            }
            else
            {
                result.Message = response.StatusDescription + response.Content;
            }

            return result;
        }

        public GenericResult<orderResult> Order(string access_token, string id)
        {
            var result = new GenericResult<orderResult>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;            
            var client = new RestClient(_urlBase + Constants.URL_ORDERS + $"{id}{Constants.URL_ORDER_COMPLETE}?access_token={access_token}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<orderResult>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + response.Content;
            }

            return result;
        }
    }
}

