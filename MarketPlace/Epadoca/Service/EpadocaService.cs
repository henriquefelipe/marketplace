using Epadoca.Domain;
using Epadoca.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Epadoca.Service
{
    public class EpadocaService
    {
        private string _urlBase;


        public EpadocaService(string urlBase)
        {
            _urlBase = urlBase;
        }
       
        public GenericResult<token> Token(string username, string password)
        {
            var result = new GenericResult<token>();

            var client = new RestClient(_urlBase + Constants.URL_TOKEN);
            var request = new RestRequest(Method.POST);            
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);           
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

        public GenericResult<List<order>> Orders(string token)
        {
            var result = new GenericResult<List<order>>();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_MANAGER_PADARIA_GET);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<order>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericResult<order> Order(string token, string guid)
        {
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_MANAGER_PEDIDO_DETALHE, guid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                var resultItens = Itens(token, guid);
                if (resultItens.Success)
                {
                    result.Result.itens = resultItens.Result;
                    result.Success = true;
                    result.Json = response.Content;
                }
                else
                {
                    result.Message = resultItens.Message;
                }
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }

        public GenericResult<List<item>> Itens(string token, string guid)
        {
            var result = new GenericResult<List<item>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_MANAGER_PEDIDO_PRODUTOS, guid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<item>>(response.Content);
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
