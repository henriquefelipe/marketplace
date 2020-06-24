using Logaroo.Domain;
using Logaroo.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

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

            var client = new RestClient(_urlBase + Constants.URL_LOGIN);
            var request = new RestRequest(Method.POST);           
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            IRestResponse responseToken = client.Execute(request);

            if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<login>(responseToken.Content);
                result.Success = true;
            }
            else
            {
                result.Message = responseToken.StatusDescription;
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
            if(!string.IsNullOrEmpty(filter.reference_id))
            {
                url += "?reference_id=" + filter.reference_id;
            }

            if (!string.IsNullOrEmpty(filter.merchant_id))
            {
                url += "&merchant_id=" + filter.merchant_id;
            }

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
                result.Message = response.StatusDescription;
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
            var result = new GenericResult<ordercreateresult>();

            var data = JsonConvert.SerializeObject(order);
            var url = string.Format("{0}{1}", _urlBase, Constants.URL_ORDER);
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
    }   
}

