using Aiqfome.Domain;
using Aiqfome.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiqfome.Service
{
    public class AiqfomeService
    {
        private string _url;
        private string _token;
        private string _merchantId;

        public AiqfomeService(string url, string merchantId, string token)
        {
            _url = url;
            _merchantId = merchantId;
            _token = token;
        }

        public GenericResult<token_result> Token(string usuario, string senha)
        {
            var result = new GenericResult<token_result>();
            try
            {
                var dados = new
                {
                    username = usuario,
                    password = senha
                };

                var json = JsonConvert.SerializeObject(dados);

                var client = new RestClient(_url + Constants.URL_TOKEN);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Aiq-User-Agent", _merchantId);
                request.AddHeader("Authorization", "Basic " + _token);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseResult = JsonConvert.DeserializeObject<token_result>(response.Content);
                    if (responseResult != null)
                    {
                        result.Result = responseResult;
                        result.Success = true;
                    }
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

        public GenericResult<orders_result> Orders(string token)
        {
            var result = new GenericResult<orders_result>();
            try
            {
                var client = new RestClient(_url + Constants.URL_ORDERS);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _merchantId);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("text/plain", "", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<orders_result>(response.Content);
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    var resultError = JsonConvert.DeserializeObject<error_result>(response.Content);
                    if (resultError.data != null)
                        result.Message = resultError.data.message;
                    else
                        result.Message = response.Content;
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
