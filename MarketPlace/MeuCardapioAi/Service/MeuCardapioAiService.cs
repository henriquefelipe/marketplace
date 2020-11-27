using MeuCardapioAi.Domain;
using MeuCardapioAi.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCardapioAi.Service
{
    public class MeuCardapioAiService
    {
        private string _urlBase = "";
        public MeuCardapioAiService(string url)
        {
            _urlBase = url;
        }

        public GenericResult<token> Token(string client_id, string client_secret)
        {
            var result = new GenericResult<token>();

            var client = new RestClient(_urlBase + Constants.URL_TOKEN);
            var request = new RestRequest(Method.POST);
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "client_credentials");
            IRestResponse responseToken = client.Execute(request);

            if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                result.Success = true;
            }
            else
            {
                result.Message = responseToken.StatusDescription;
            }

            return result;
        }

        public GenericResult<orders_result> Orders(string token, string ultimoPedido, int quantidade = 10)
        {
            var result = new GenericResult<orders_result>();
            try
            {
                var url = string.Format("{0}{1}{2}?t={3}", _urlBase, Constants.URL_PEDIDO_ULTIMO, ultimoPedido, quantidade);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<orders_result>(response.Content);
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

        public GenericResult<order_result> Order(string token, string pedido)
        {
            var result = new GenericResult<order_result>();
            try
            {
                var url = string.Format("{0}{1}{2}", _urlBase, Constants.URL_PEDIDO, pedido);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order_result>(response.Content);
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
