using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidelizi.Service
{
    public class FideliziService
    {
        private string _url = "https://integracao.fidelizii.com.br/v3/";
        private string _appToken = "";
        private string _accessTokenn = "";

        public FideliziService(string appToken, string accessToken) 
        {
            _appToken = appToken;
            _accessTokenn = accessToken;
        }

        public FideliziService(string appToken, string accessToken, string url)
        {
            _appToken = appToken;
            _accessTokenn = accessToken;
            _url = url;
        }

        public GenericResult<string> GetConfiguracoes()
        {
            var result = new GenericResult<string>();
            try
            {                
                var client = new RestClient(_url + "estabelecimentos");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("App Token", _appToken);
                request.AddHeader("Access Token", _accessTokenn);                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<string>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        //public GenericResult<result_order> Order(order order, string token)
        //{
        //    var result = new GenericResult<result_order>();
        //    try
        //    {
        //        var data = new
        //        {
        //            order = order
        //        };

        //        var client = new RestClient(_url + "order");
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("Authorization", "Bearer " + token);
        //        request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

        //        IRestResponse response = client.Execute(request);
        //        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        //        {
        //            result.Result = JsonConvert.DeserializeObject<result_order>(response.Content);
        //            result.Success = true;
        //        }
        //        else
        //        {
        //            result.Message = response.Content + " - " + response.StatusDescription;
        //        }

        //        result.Json = response.Content;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //    }
        //    return result;
        //}
    }
}
