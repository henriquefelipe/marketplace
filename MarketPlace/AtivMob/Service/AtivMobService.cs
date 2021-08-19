using AtivMob.Domain;
using AtivMob.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace AtivMob.Service
{
    public class AtivMobService
    {
        private string _url = "";
        private string _merchantId = "";
        private string _token = "";
        public AtivMobService(string url, string merchantId, string token)
        {
            this._url = url;
            this._merchantId = merchantId;
            this._token = token;
        }

        public GenericResult<result> Order(order order)
        {
            var result = new GenericResult<result>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var data = JsonConvert.SerializeObject(order);
            var url = string.Format("{0}{1}", _url, Constants.URL_SOLICITAR);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result>(response.Content);
                if (result.Result.resultCode == 0)
                    result.Success = true;
                else
                    result.Message = result.Result.resultMsg;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

        public GenericResult<result_event> ConsultarEventos()
        {
            var result = new GenericResult<result_event>();

            var url = string.Format("{0}{1}", _url, Constants.URL_CONSULTAR_EVENTOS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", _token);            

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result_event>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

        public GenericResult<result> ProcessarEventos(List<string> ids)
        {
            var result = new GenericResult<result>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var dados = new processar_evento
            {
                events_ids = ids
            };            

            var data = JsonConvert.SerializeObject(dados);
            var url = string.Format("{0}{1}", _url, Constants.URL_ACK_EVENTS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", _token);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result>(response.Content);
                if (result.Result.resultCode == 0)
                    result.Success = true;
                else
                    result.Message = result.Result.resultMsg;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

    }
}

