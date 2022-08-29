using Servit.Domain;
using Servit.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Servit.Service
{
    public class ServitService
    {
        private string _urlBase = Constants.URL_BASE;

        public ServitService() { }

        public GenericResult<retornoGeneric<token_data>> OathToken(string username, string password)
        {
            var result = new GenericResult<retornoGeneric<token_data>>();
            try
            {
                var data = new
                {
                    username = username,
                    password = password
                };

                var url = _urlBase + Constants.URL_TOKEN;

                var client = new RestClientBase(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retornoGeneric<token_data>>(response.Content);
                    if (result.Result.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    result.Message = response.StatusDescription + $" => {response.Content}";
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<retornoGeneric<merchants_data>> Merchants(string token)
        {
            var result = new GenericResult<retornoGeneric<merchants_data>>();

            try
            {
                var url = string.Format("{0}{1}", _urlBase, Constants.URL_MERCHANTS);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                var response = client.Execute<RestObject>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retornoGeneric<merchants_data>>(response.Content);
                    if (result.Result.success)
                        result.Success = true;
                    else
                        result.Message = result.Result.message;                    
                } 
                else
                {
                    result.Message = response.StatusDescription + " -> " + response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<retornoGeneric<event_result>> Events(string token, string merchantid)
        {
            var result = new GenericResult<retornoGeneric<event_result>>();
            try
            {
                var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_EVENTS_MERCHANT, merchantid);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                var response = client.Execute<RestObject>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retornoGeneric<event_result>>(response.Content);
                    if (result.Result.success)
                        result.Success = true;
                    else
                        result.Message = result.Result.message;
                }
                else
                {
                    result.Message = response.StatusDescription + " -> " + response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericSimpleResult EventsAcknowledgment(string token, List<int> ids)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    ids = ids
                };

                var url = string.Format("{0}{1}", _urlBase, Constants.URL_EVENTS_ACKNOWLEDGMENT);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);                          
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var retorno = JsonConvert.DeserializeObject<retorno>(response.Content);
                    if (retorno.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = retorno.message;
                    }                   
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericSimpleResult TableBlock(string token, string merchantid, string numero)
        {
            var result = new GenericSimpleResult();
            try
            {               
                var url = string.Format("{0}{1}/{2}/table/{3}/block", _urlBase, Constants.URL_EVENT_MECHANT, merchantid, numero);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var retorno = JsonConvert.DeserializeObject<retorno>(response.Content);
                    if (retorno.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = retorno.message;
                    }
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericSimpleResult TableUnlock(string token, string merchantid, string numero)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}/{2}/table/{3}/unlock", _urlBase, Constants.URL_EVENT_MECHANT, merchantid, numero);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var retorno = JsonConvert.DeserializeObject<retorno>(response.Content);
                    if (retorno.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = retorno.message;
                    }
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericSimpleResult NewOrder(string token, string merchantid, newOrder newOrder)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}/{2}/newOrder", _urlBase, Constants.URL_ORDERS, merchantid);
                var client = new RestClientBase(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(newOrder), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var retorno = JsonConvert.DeserializeObject<retorno>(response.Content);
                    if (retorno.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = retorno.message;
                    }
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
