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

        public GenericResult<order> Order(string token, string orderid)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDERS, orderid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        public GenericSimpleResult Accept(string token, string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    orderId = orderid,
                    status = Enum.OrderStatus.CONFIRMED
                };
                var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDERS, "statusUpdate");
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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
    }
}
