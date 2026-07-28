using GoomerAbrahao.Domain;
using GoomerAbrahao.Enum;
using GoomerAbrahao.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace GoomerAbrahao.Service
{
    public class GoomerAbrahaoService
    {
        private readonly RestClient _client;
        public GoomerAbrahaoService(string token)
        {
            var options = new RestClientOptions(Constants.URL_BASE)
            {
                Authenticator = new JwtAuthenticator(token)
            };
            _client = new RestClient(options);
        }

        public GenericResult<ResponseOrders> Orders()
        {
            var result = new GenericResult<ResponseOrders>();
            var request = new RestRequest(Constants.URL_ORDERS, Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                result.Result = JsonConvert.DeserializeObject<ResponseOrders>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> OrderReceived(Guid orderId)
        {
            var result = new GenericResult<Response<object>>();
            
            var resource = $"{Constants.URL_ORDERS}/{orderId}/{Constants.URL_RECEIVED}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                // Tenta deserializar. (Veja a observação abaixo)
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> OrderError(Guid orderId, string errorMessage = null)
        {
            var result = new GenericResult<Response<object>>();

            var resource = $"{Constants.URL_ORDERS}/{orderId}/{Constants.URL_ERROR}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                var body = new { error = errorMessage };
                request.AddJsonBody(body);
            }

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> CloseOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = type == (byte)OrderType.Mesa ? "table" : "card";
            var resource = $"{orderType}/{tableCode}/{Constants.URL_CLOSE}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> TransferOrder(int tableCode, byte type, int newTableCode)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = type == (byte)OrderType.Mesa ? "table" : "card";
            var resource = $"{orderType}/{tableCode}/{Constants.URL_TRANSFER}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            object body = type == (byte)OrderType.Mesa
            ? (object)new { new_table = newTableCode }
            : (object)new { new_card = newTableCode };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> CancelOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = type == (byte)OrderType.Mesa ? "table" : "card";
            var resource = $"{orderType}/{tableCode}/{Constants.URL_CANCEL}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<Response<object>> ReopenOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = type == (byte)OrderType.Mesa ? "table" : "card";
            var resource = $"{orderType}/{tableCode}/{Constants.URL_REOPEN}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }
    }
}
