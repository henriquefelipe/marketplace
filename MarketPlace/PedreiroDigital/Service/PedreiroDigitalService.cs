using PedreiroDigital.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedreiroDigital.Service
{
    public class PedreiroDigitalService
    {
        private string _url;
        private string _token;
        private string _merchantId;

        public PedreiroDigitalService(string url, string merchantId, string token)
        {
            _url = url;
            _merchantId = merchantId;
            _token = token;
        }

        public GenericResult<result_order> Orders(int status)
        {
            var result = new GenericResult<result_order>();
            try
            {
                var client = new RestClient(_url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", _token);
                request.AddHeader("store", _merchantId);
                request.AddHeader("status", status.ToString());

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseResult = JsonConvert.DeserializeObject<result_order>(response.Content);
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

        public GenericSimpleResult Status(string id, int status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var body = "{" + string.Format("\r\n    \"id\": \"{0}\",\r\n    \"status\": {1}\r\n", id, status) + "}";

                var client = new RestClient(_url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", _token);                
                request.AddParameter("application/json", body, ParameterType.RequestBody);                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    try
                    {
                        var result_order = JsonConvert.DeserializeObject<result_status>(response.Content);
                        result.Message = result_order.message;
                    }
                    catch
                    {
                        result.Message = response.Content;
                    }
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
