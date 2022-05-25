using Goomer.Domain;
using Goomer.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Service
{
    public class GoomerService
    {
        private string _url;

        public GoomerService(string url)
        {
            _url = url;
        }

        public GenericResult<token> OathToken(string integrationToken, string storeId, string clientSecret, string clientId)
        {
            var result = new GenericResult<token>();
            try
            {
                var dados = new
                {
                    integrationToken,
                    storeId,
                    clientSecret,
                    clientId
                };

                var data = JsonConvert.SerializeObject(dados);

                var client = new RestClient(_url + Constants.TOKEN);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", data, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<token> RefreshToken(string refreshToken)
        {
            var result = new GenericResult<token>();
            try
            {
                var dados = new
                {
                    refreshToken
                };

                var data = JsonConvert.SerializeObject(dados);

                var client = new RestClient(_url + Constants.TOKEN_REFRESH);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", data, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<order_list> Orders(string token, bool cancelados = false)
        {
            var result = new GenericResult<order_list>();
            try
            {
                var status = Constants.ORDER_NEW;
                if (cancelados)
                    status = Constants.ORDER_CANCELLED;

                var client = new RestClient(_url + status);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-api-key", token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_list>(response.Content);
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

        public GenericResult<order> Order(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + Constants.ORDER_DETAILS + orderId);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-api-key", token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericSimpleResult Accept(string token, string orderId)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + Constants.ORDER_ACCEPT + orderId);
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", token);

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

        public GenericSimpleResult Deny(string token, string orderId, string mensagem)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    message = mensagem
                };

                var client = new RestClient(_url + Constants.ORDER_DENY + orderId);
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", token);
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

        public GenericSimpleResult Update(string token, string orderId, string status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var dados = new
                {
                    status
                };

                var data = JsonConvert.SerializeObject(dados);

                var client = new RestClient(_url + Constants.ORDER_UPDATE + orderId);
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", token);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", data, ParameterType.RequestBody);

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

        public GenericSimpleResult Cancel(string token, string orderId)
        {
            var result = new GenericSimpleResult();
            try
            {
                var client = new RestClient(_url + Constants.ORDER_CANCEL + orderId);
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", token);

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


        public GenericSimpleResult UpdateConta(string token, conta conta)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = JsonConvert.SerializeObject(conta);

                var client = new RestClient(_url + Constants.ORDER_UPDATE_CONTA);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("x-api-key", token);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", data, ParameterType.RequestBody);

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
