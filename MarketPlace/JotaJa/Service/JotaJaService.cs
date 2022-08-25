using JotaJa.Domain;
using JotaJa.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace JotaJa.Service
{
    public class JotaJaService
    {
        private string _urlBase;
        public JotaJaService(bool desenvolvedor = false)
        {
            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<token> OathToken(string key, string client_secret)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    apiKey = key,
                    clientSecret = client_secret
                };

                var url = _urlBase + Constants.URL_LOGIN;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);
                if (responseToken.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                    result.Success = true;
                }
                else
                {                    
                    result.Message = responseToken.StatusDescription + $" {responseToken.Content}";
                }

                result.StatusCode = responseToken.StatusCode;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<token> Refresh(string token)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    token = token
                };

                var url = _urlBase + Constants.URL_REFRESH;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);
                if (responseToken.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = responseToken.StatusDescription + $" {responseToken.Content}";
                }

                result.StatusCode = responseToken.StatusCode;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<orders> Orders(string token)
        {
            var result = new GenericResult<orders>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDERS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<orders>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<stores> Store(string token)
        {
            var result = new GenericResult<stores>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_STORE);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<stores>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        //public GenericResult<pedido> Order(string storeId, string id, string token)
        //{
        //    var result = new GenericResult<pedido>();

        //    var url = string.Format("{0}{1}{2}/{3}{4}", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        //    request.AddHeader("Content-Type", "application/json");
        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        result.Result = JsonConvert.DeserializeObject<pedido>(response.Content);
        //        result.Success = true;
        //    }
        //    else
        //    {
        //        result.Message = response.Content;
        //    }

        //    result.Json = response.Content;

        //    return result;
        //}

        //public GenericResult<retorno_status> Approve(string storeId, string id, string token, int time)
        //{
        //    var result = new GenericResult<retorno_status>();

        //    var data = new
        //    {
        //        time = time
        //    };


        //    var url = string.Format("{0}{1}{2}/{3}{4}/approve", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        result.Result = JsonConvert.DeserializeObject<retorno_status>(response.Content);
        //        if (result.Result.order != null && result.Result.order.status == "A")
        //        {
        //            result.Success = true;
        //        }
        //        else
        //        {
        //            result.Message = result.Result.message;
        //        }
        //    }
        //    else
        //    {
        //        result.Message = response.Content;
        //    }

        //    result.Json = response.Content;

        //    return result;
        //}

        //public GenericResult<retorno_status> Ready(string storeId, string id, string token)
        //{
        //    var result = new GenericResult<retorno_status>();
        //    var data = new
        //    {
        //        vehicle_type_for_delivery = "NORMAL"
        //    };

        //    var url = string.Format("{0}{1}{2}/{3}{4}/ready", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        result.Result = JsonConvert.DeserializeObject<retorno_status>(response.Content);
        //        if (result.Result.message == "Ok")
        //        {
        //            result.Success = true;
        //        }
        //        else
        //        {
        //            result.Message = result.Result.message;
        //        }
        //    }
        //    else
        //    {
        //        result.Message = response.Content;
        //    }

        //    result.Json = response.Content;

        //    return result;
        //}

        //public GenericResult<retorno_status> Cancel(string storeId, string id, string token, string mensagem)
        //{
        //    var result = new GenericResult<retorno_status>();
        //    var data = new
        //    {
        //        reason_id = "1",
        //        canceled_by = "LOJISTA",
        //        reason_description = mensagem
        //    };

        //    var url = string.Format("{0}{1}{2}/{3}{4}/cancel", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Authorization", string.Format("Bearer {0}", token));
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        result.Result = JsonConvert.DeserializeObject<retorno_status>(response.Content);
        //        if (result.Result.message == "Ok")
        //        {
        //            result.Success = true;
        //        }
        //        else
        //        {
        //            result.Message = result.Result.message;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var resultado = JsonConvert.DeserializeObject<retorno_status>(response.Content);
        //            result.Message = resultado.message;
        //        }
        //        catch
        //        {
        //            result.Message = response.Content;
        //        }
        //    }

        //    result.Json = response.Content;

        //    return result;
        //}
    }
}
