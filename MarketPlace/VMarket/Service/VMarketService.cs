using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using VMarket.Domain;
using VMarket.Util;

namespace VMarket.Service
{
    public class VMarketService
    {        

        public GenericResult<autenticar> Autenticar(string email, string password)
        {
            var result = new GenericResult<autenticar>();

            var dados = new
            {
                email,
                password
            };

            var data = JsonConvert.SerializeObject(dados);

            var url = string.Format("{0}{1}", Constants.URL, Constants.URL_AUTENTICAR);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<autenticar>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<result<List<pedido_listar>>> PedidoListar(string token, int paginacao = 100)
        {
            var result = new GenericResult<result<List<pedido_listar>>>();

            var url = string.Format("{0}{1}?paginate={2}", Constants.URL, Constants.URL_PEDIDO_LISTAR, paginacao);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<result<List<pedido_listar>>>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        public GenericResult<pedido_item_retorno_main> PedidoDetalhe(string token, int id, int paginacao = 1)
        {
            var result = new GenericResult<pedido_item_retorno_main>();

            var url = string.Format("{0}{1}?page={2}&id_pedido={3}", Constants.URL, Constants.URL_PEDIDO_DETALHE, paginacao, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<pedido_item_retorno_main>(response.Content);
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
