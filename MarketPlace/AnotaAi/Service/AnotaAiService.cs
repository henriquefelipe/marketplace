using AnotaAi.Domain;
using AnotaAi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnotaAi.Service
{
    public class AnotaAiService
    {
        private string _urlBase = Constants.URL_BASE;
        public AnotaAiService() { }


        public GenericResult<result_orders> Orders(string token)
        {
            var result = new GenericResult<result_orders>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var url = string.Format("{0}{1}", _urlBase, Constants.ORDER_LIST);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result_orders>(response.Content);
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

        public GenericResult<order> Order(string token, string id)
        {
            var result = new GenericResult<order>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_GET, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result_order = JsonConvert.DeserializeObject<result_order>(response.Content);
                    if (result_order.success)
                    {
                        result.Result = result_order.info;
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = result_order.message;
                    }
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

        public GenericResult<result> Accept(string token, string id)
        {
            var result = new GenericResult<result>();
            try
            {
                var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_ACCEPT, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _result = JsonConvert.DeserializeObject<result>(response.Content);
                    if (_result.success)
                    {
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = _result.message;
                    }
                }
                else
                {
                    if (response.StatusDescription.Equals("Not Found"))
                    {                        
                        result.Message = "Não encontrado!";                        
                    }
                    else
                    {
                        result.Message = response.Content + " - " + response.StatusDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result> Ready(string token, string id)
        {
            var result = new GenericResult<result>();
            try
            {
                var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_READY, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _result = JsonConvert.DeserializeObject<result>(response.Content);
                    if (_result.success)
                    {
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = _result.message;
                    }
                }
                else
                {
                    if (response.StatusDescription.Equals("Not Found"))
                    {
                        result.Message = "Não encontrado!";
                    }
                    else
                    {
                        result.Message = response.Content + " - " + response.StatusDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result> Finalize(string token, string id)
        {
            var result = new GenericResult<result>();
            try
            {
                var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_FINALIZE, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _result = JsonConvert.DeserializeObject<result>(response.Content);
                    if (_result.success)
                    {
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = _result.message;
                    }
                }
                else
                {
                    if (response.StatusDescription.Equals("Not Found"))
                    {
                        result.Message = "Não encontrado!";
                    }
                    else
                    {
                        result.Message = response.Content + " - " + response.StatusDescription;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result> Cancel(string token, string id, string justificativa)
        {
            var result = new GenericResult<result>();
            try
            {
                var data = new
                {
                    justification = justificativa
                };

                var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_CANCEL, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var _result = JsonConvert.DeserializeObject<result>(response.Content);
                    if (_result.success)
                    {                        
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = _result.message;
                    }
                }
                else
                {
                    if (response.StatusDescription.Equals("Not Found"))
                    {
                        result.Message = "Não encontrado!";
                    }
                    else
                    {
                        result.Message = response.Content + " - " + response.StatusDescription;
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
