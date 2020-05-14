using SuperMenu.Domain;
using SuperMenu.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace SuperMenu.Service
{
    public class SuperMenuService
    {
        private string _urlBase = Constants.URL_BASE;
        public SuperMenuService() { }

        public SuperMenuService(string urlBase)
        {
            _urlBase = urlBase;
        }

        /// <summary>
        /// Serve para buscar os dados de um pedido individualmente.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenericResult<order> Order(string token, string id)
        {
            var result = new GenericResult<order>();
            result.Result = new order();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {               
                result.Message = "Pedido não encontrado";
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        /// <summary>
        /// Busca por todos os pedidos de um estabelecimento que ainda não tenham sido integrados com o PDV
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericResult<List<poolingEvent>> EventPolling(string token)
        {
            var result = new GenericResult<List<poolingEvent>>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_EVENTS_POLLING);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<poolingEvent>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new List<poolingEvent>();
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        /// <summary>
        /// Após buscar os pedidos, esse endpoint informa pro supermenu quais os pedidos que foram integrados.
        /// Os dados devem ser enviados em forma de array, diretamente no body (onde o type é JSON).
        /// </summary>
        /// <param name="token"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public GenericSimpleResult EventAcknowledgment(string token, List<eventAcknowledgment> events)
        {
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_EVENTS_ACKNOWLEDGMENT);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", token);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(events);                      
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }


        /// <summary>
        /// Para mudar o status de um pedido manualmente pelo seu PDV
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <param name="codeStatus"></param>
        /// <returns></returns>
        public GenericResult<order> StatusEdit(string token, string id, string codeStatus)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}/{3}/{4}", _urlBase, Constants.URL_ORDERS, id, Constants.URL_ORDERS_STATUSES, codeStatus);
            var client = new RestClient(url);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }
    }   
}

