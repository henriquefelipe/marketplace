using DegustaAi.Domain;
using DegustaAi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace DegustaAi.Service
{
    public class DegustaAiService
    {
        private string _urlHost;
        public DegustaAiService(string host)
        {
            _urlHost = host;
        }
        public GenericResult<response> Orders(string token, string parametros, DateTime dataAtualizacao)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_GET_ORDERS}?data_atualizacao={dataAtualizacao.ToString("yyyy-MM-dd")}{parametros}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> ChangeStatus(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();

            var url = $"https://api.{_urlHost}{Constants.URL_CHANGE_STATUS}?pedido_ref={pedido_ref}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Bearer", token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<response>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<response> Cancel(string token, int pedido_ref)
        {
            var result = new GenericResult<response>();
            try
            {
                var url = $"https://api.{_urlHost}{Constants.URL_CANCELA_PEDIDO}?pedido_ref={pedido_ref}";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Bearer", token);
                request.AddHeader("Content-Type", "application/json");                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<response>(response.Content);
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
