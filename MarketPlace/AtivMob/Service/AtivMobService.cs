using AtivMob.Domain;
using AtivMob.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

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

        public GenericSimpleResult Order(order order)
        {
            var result = new GenericSimpleResult();

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
                var retorno = JsonConvert.DeserializeObject<result>(response.Content);
                if (retorno.resultCode == 0)
                    result.Success = true;
                else
                    result.Message = retorno.resultMsg;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }


    }
}

