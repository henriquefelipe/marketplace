using DeliveryDireto.Domain;
using DeliveryDireto.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;

namespace DeliveryDireto.Service
{
    public class DeliveryDiretoService
    {
        private string _urlBase;
        public DeliveryDiretoService(bool desenvolvedor = false)
        {
            _urlBase = desenvolvedor ? Constants.URL_BASE : Constants.URL_BASE;
        }

        public GenericResult<token> OAuthToken(string X_DeliveryDireto_ID, string client_id, string client_secret, string username, string password)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    grant_type = Enum.GrantTypes.PASSWORD,
                    client_id,
                    client_secret,
                    username,
                    password
                };

                var url = string.Format("{0}{1}/{2}", _urlBase, Constants.ADMIN_API, Constants.TOKEN);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
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

        public GenericResult<token> RefreshToken(string X_DeliveryDireto_ID, string client_id, string client_secret, string refresh_token)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    grant_type = Enum.GrantTypes.REFRESH_TOKEN,
                    client_id,
                    client_secret,
                    refresh_token
                };

                var url = string.Format("{0}{1}/{2}", _urlBase, Constants.ADMIN_API, Constants.TOKEN);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
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

        public GenericResult<result_orders> Orders(string X_DeliveryDireto_ID, string client_id, string token)
        {
            var result = new GenericResult<result_orders>();

            var url = string.Format("{0}{1}/{2}/{3}?showItems=true&showExtras=true", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
            request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result_orders>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<result_orders> Order(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericResult<result_orders>();

            var url = string.Format("{0}{1}/{2}/{3}?ordersId={4}&showItems=true&showExtras=true", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
            request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result_orders>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public string OrderJSON(string json, decimal? order_id)
        {
            var pedido = JsonConvert.DeserializeObject<result_orders>(json);
            if(pedido != null)
            {
                return JsonConvert.SerializeObject(pedido.data.orders.Where(x => x.id == order_id).FirstOrDefault());
            }
            else
            {
                return "";
            }
        }

        public GenericSimpleResult Accept(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.APPROVED,
                    statusReason = (string)null
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Cancel(string X_DeliveryDireto_ID, string client_id, string token, string order_id, string motivo)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.HIDDEN,
                    statusReason = motivo
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Pending(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.WAITING,
                    statusReason = (string)null
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Dispatch(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.IN_TRANSIT,
                    statusReason = (string)null
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Finalize(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.DONE,
                    statusReason = (string)null
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult Reject(string X_DeliveryDireto_ID, string client_id, string token, string order_id, string motivo)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.REJECTED,
                    statusReason = motivo
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public GenericSimpleResult PaymentPending(string X_DeliveryDireto_ID, string client_id, string token, string order_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    status = Enum.OrderStatus.WARNING,
                    statusReason = (string)null
                };
                var url = string.Format("{0}{1}/{2}/{3}/{4}/status", _urlBase, Constants.ADMIN_API, Constants.VERSAO_API, Constants.ORDERS, order_id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("X-DeliveryDireto-ID", X_DeliveryDireto_ID);
                request.AddHeader("X-DeliveryDireto-Client-Id", client_id);
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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
