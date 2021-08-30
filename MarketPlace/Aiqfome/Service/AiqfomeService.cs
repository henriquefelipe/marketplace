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
        private string _authorization;
        private string _merchantId;
        private string _userAgent;
        

        public AiqfomeService(string url, string merchantId, string authorization, string userAgent)
        {
            _url = url;
            _merchantId = merchantId;
            _authorization = authorization;
            _userAgent = userAgent;
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
                request.AddHeader("Aiq-User-Agent", _userAgent);
                request.AddHeader("Authorization", "Basic " + _authorization);
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
                request.AddHeader("Aiq-User-Agent", _userAgent);
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

        public GenericResult<orders_result> Order(string token, string id)
        {
            var result = new GenericResult<orders_result>();
            try
            {
                var client = new RestClient(string.Format("{0}{1}/{2}", _url, Constants.URL_ORDERS, id ));
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _userAgent);
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

        public GenericResult<orders_result> MarkAsRead(string token, string id)
        {
            var result = new GenericResult<orders_result>();
            try
            {
                var dados = new
                {
                    order_id = id
                };

                var json = JsonConvert.SerializeObject(dados);

                var client = new RestClient(string.Format("{0}{1}", _url, Constants.URL_ORDERS_MARK_AS_READ));
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _userAgent);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
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

        public GenericResult<orders_result> MarkAsReady(string token, string id)
        {
            var result = new GenericResult<orders_result>();
            try
            {
                var dados = new
                {
                    order_id = id
                };

                var json = JsonConvert.SerializeObject(dados);

                var client = new RestClient(string.Format("{0}{1}", _url, Constants.URL_ORDERS_MARK_AS_READY));
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _userAgent);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
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

        public GenericResult<open_close_result> Open(string token)
        {
            var result = new GenericResult<open_close_result>();
            try
            {
                var dados = new
                {
                    store_id = _merchantId
                };

                var json = JsonConvert.SerializeObject(dados);

                var client = new RestClient(string.Format("{0}{1}", _url, Constants.URL_STORE_OPEN));
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _userAgent);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<open_close_result>(response.Content);
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

        public GenericResult<open_close_result> Close(string token)
        {
            var result = new GenericResult<open_close_result>();
            try
            {
                var dados = new
                {
                    store_id = _merchantId
                };

                var json = JsonConvert.SerializeObject(dados);

                var client = new RestClient(string.Format("{0}{1}", _url, Constants.URL_STORE_CLOSE));
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Aiq-User-Agent", _userAgent);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<open_close_result>(response.Content);
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
