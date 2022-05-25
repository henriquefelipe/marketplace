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

        public ServitService()
        {
        }

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

        public GenericResult<retornoGeneric<order_result>> Orders(string token, string merchantid)
        {
            var result = new GenericResult<retornoGeneric<order_result>>();
            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDERS, merchantid);            
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));            
            var response = client.Execute<RestObject>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<retornoGeneric<order_result>>(response.Content);
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
            return result;
        }

        //public GenericSimpleResult Acknowledgment(string token, List<eventAcknowledgment> events)
        //{
        //    var result = new GenericSimpleResult();

        //    var url = string.Format("{0}order/{1}/{2}", _urlBase, Constants.VERSION_1, Constants.URL_EVENT_ACNOWLEDGMENT);
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        //    request.AddHeader("Content-Type", "application/json");
        //    request.RequestFormat = DataFormat.Json;
        //    request.AddBody(events);
        //    //request.AddParameter("data", events, ParameterType.RequestBody);            
        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
        //    {
        //        result.Success = true;
        //    }
        //    else
        //    {
        //        result.Message = response.Content;
        //    }

        //    return result;
        //}

    }
}
