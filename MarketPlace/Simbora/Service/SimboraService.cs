using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using Simbora.Domain;
using Simbora.Utils;
using System;
using System.Collections.Generic;
using System.Net;

namespace Simbora.Service
{
    public class SimboraService
    {
        private string _urlBase = Constants.URL_BASE;
        public SimboraService() { }

        public SimboraService(string urlBase)
        {
            _urlBase = urlBase;
        }
        
        public GenericResult<order_new_retorno> OrderNew(string token, orders_new orders)
        {
            var result = new GenericResult<order_new_retorno>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_NEW);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", token);
            request.AddParameter("application/json", JsonConvert.SerializeObject(orders), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order_new_retorno>(response.Content);
                if (result.Result.success)
                {
                    result.Success = true;
                }
                else
                {
                    result.Message = result.Result.message;
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<order_new_retorno>(response.Content);
                    var mensagem = retorno.message;
                    foreach (var item in retorno.orders)
                        mensagem += " - " + item.message;

                    result.Message = mensagem;
                }
                catch
                { 
                result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }

        public GenericResult<consultar_pedido_retorno> Consultar(string token, string externalId)
        {
            var result = new GenericResult<consultar_pedido_retorno>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_LIGEIRO + externalId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);            
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);
                if (result.Result.status == Simbora.Enum.Status.WAITING_ROUTE)
                {
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(result.Result.message))
                    {
                        result.Message = response.Content;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);                    
                    result.Message = retorno.message;
                }
                catch
                {
                    result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }

        public GenericResult<consultar_pedido_retorno> Confirmar(string token, string externalId)
        {
            var result = new GenericResult<consultar_pedido_retorno>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_CONFIRM_ORDER + externalId);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);
                if (result.Result.success)
                {
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(result.Result.message))
                    {
                        result.Message = response.Content;
                    }
                    else
                    {
                        result.Message = result.Result.message; 
                    }
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);
                    result.Message = retorno.message;
                }
                catch
                {
                    result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }

        public GenericResult<consultar_pedido_roteirizado> ConsultarPedidosRoteirizados(string token)
        {
            var result = new GenericResult<consultar_pedido_roteirizado>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_ROTEIRIZADO);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<consultar_pedido_roteirizado>(response.Content);
                if (result.Result.success)
                {
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(result.Result.message))
                    {
                        result.Message = response.Content;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<consultar_pedido_roteirizado>(response.Content);
                    result.Message = retorno.message;
                }
                catch
                {
                    result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }

        public GenericResult<consultar_pedido_retorno> ConfirmarPedidoPronto(string token, string externalId)
        {
            var result = new GenericResult<consultar_pedido_retorno>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_START_SEARCH + externalId);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);
                if (result.Result.success)
                {
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(result.Result.message))
                    {
                        result.Message = response.Content;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<consultar_pedido_retorno>(response.Content);
                    result.Message = retorno.message;
                }
                catch
                {
                    result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }

        public GenericResult<consultar_atualizacoes_pedido> ConsultarAtualizacoesPedidos(string token)
        {
            var result = new GenericResult<consultar_atualizacoes_pedido>();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(_urlBase + Constants.URL_ORDER_UPDATEDORDERS);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<consultar_atualizacoes_pedido>(response.Content);
                if (result.Result.success)
                {
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(result.Result.message))
                    {
                        result.Message = response.Content;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
            }
            else
            {
                try
                {
                    var retorno = JsonConvert.DeserializeObject<consultar_atualizacoes_pedido>(response.Content);
                    result.Message = retorno.message;
                }
                catch
                {
                    result.Message = response.StatusDescription + response.Content;
                }
            }

            return result;
        }
    }
}

