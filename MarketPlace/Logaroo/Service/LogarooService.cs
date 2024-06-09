using Logaroo.Domain;
using Logaroo.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Logaroo.Service
{
    public class LogarooService
    {
        private string _urlBase = Constants.URL_BASE;
        public LogarooService() { }

        public LogarooService(string urlBase)
        {
            _urlBase = urlBase;
        }

        /// <summary>
        /// Retorna o token/dados do Logaroo
        /// </summary>      
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public GenericResult<login> Login(string email, string password)
        {
            var result = new GenericResult<login>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_LOGIN);
            var request = new RestRequest(Method.POST);
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<login>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + response.Content;
            }

            return result;
        }

        /// <summary>
        /// Sair da api
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericSimpleResult Logout(string token)
        {
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_LOGOUT);
            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result.Success = true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

        /// <summary>
        /// Obtém todas as formas de pagamento.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericResult<payments> Payments(string token)
        {
            var result = new GenericResult<payments>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_PAYMENTS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<payments>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new payments();
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        /// <summary>
        /// Obtém todos os pedidos
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericResult<orders> Orders(string token, orderfilter filter)
        {
            var result = new GenericResult<orders>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDERS);
            if (!string.IsNullOrEmpty(filter.reference_id))
            {
                url += "/" + filter.reference_id;
            }

            //if (!string.IsNullOrEmpty(filter.merchant_id))
            //{
            //    url += "&merchant_id=" + filter.merchant_id;
            //}

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<orders>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new orders();
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " " + response.Content;
            }

            return result;
        }

        /// <summary>
        /// Cria o pedido
        /// </summary>
        /// <param name="token"></param>        
        /// <param name="order"></param>  
        /// <returns></returns>
        public GenericResult<ordercreateresult> Order(string token, order order)
        {

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var result = new GenericResult<ordercreateresult>();

            var data = JsonConvert.SerializeObject(order);
            var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDER_IMPORT);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<ordercreateresult>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

        /// <summary>
        /// Alterando o status o pedido
        /// </summary>
        /// <param name="token"></param>        
        /// <returns></returns>
        public GenericSimpleResult OrderStatus(string token, string id, string status)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                status
            };

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDER_STATUS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " - " + response.Content;
            }

            return result;
        }

        /// <summary>
        /// Obtém todos os pedidos
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericResult<orderresult> GetOrder(string token, string reference_id)
        {
            var result = new GenericResult<orderresult>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDER, reference_id);

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<orderresult>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new orderresult();
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription + " " + response.Content;
            }

            return result;
        }

        #region Mercadoo

        public GenericResult<order_mercadoo> MercadooOrdersPendentes(string token, string store)
        {
            var result = new GenericResult<order_mercadoo>();
            try
            {
                var url = string.Format("{0}{1}?pending=1&store_id={2}", _urlBase, Constants.URL_MERCADOO_ORDERS, store);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", token));
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_mercadoo>(response.Content);
                    result.Success = true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    result.Result = new order_mercadoo();
                    result.Success = true;
                }
                else
                {
                    result.Message = response.StatusDescription + " " + response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<order_orders_mercadoo> MercadooOrder(string token, string id)
        {
            var result = new GenericResult<order_orders_mercadoo>();
            try
            {
                var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_MERCADOO_ORDERS, id);

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", token));
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_orders_mercadoo>(response.Content);
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    result.Message = response.StatusDescription + " " + response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericSimpleResult MercadooOrderModerar(string token, string id, bool status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}/{2}/moderate", _urlBase, Constants.URL_MERCADOO_ORDERS, id);

                var data = new
                {
                    status
                };

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Authorization", string.Format("bearer {0}", token));
                request.AddHeader("Content-Type", "application/json");
                //request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    result.Message = response.StatusDescription + " " + response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<order_mercadoo_status> MercadooStatus(string token, string id)
        {
            var result = new GenericResult<order_mercadoo_status>();
            try
            {
                var url = string.Format("{0}{1}/{2}/status", _urlBase, Constants.URL_MERCADOO_STATUS, id);

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("bearer {0}", token));
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_mercadoo_status>(response.Content);
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    result.Message = response.StatusDescription + " " + response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        #endregion
    }
}

