using MarketPlace;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PrefiroDelivery.Domain;
using PrefiroDelivery.Enum;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrefiroDelivery.Service
{
    public class PrefiroDeliveryService
    {
        private const string _urlBase = "https://api.prefirodelivery.com/";
        private string _token = "";
        private string _hash = "";

        public PrefiroDeliveryService(string hash, string token)
        {
            _hash = hash;
            _token = token;
            //var input = string.Format("{0}|{1}", hash, chave);            
            //using (var md5 = MD5.Create())
            //{
            //    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            //    byte[] md5Bytes = md5.ComputeHash(inputBytes);

            //    _token = Convert.ToBase64String(md5Bytes);
            //}
        }

        public GenericResult<List<pedidosId>> Pedidos(byte status = (byte)PedidoStatus.Solicitado)
        {
            var result = new GenericResult<List<pedidosId>>();
            try
            {
                var url = string.Format($"{_urlBase}{_hash}/v2/pedidos/ids?status={status}");
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", $"Basic {_token}");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<pedidosId>>(response.Content);
                    result.Success = true;                    
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result<List<pedido>>> Pedido(int id)
        {
            var result = new GenericResult<result<List<pedido>>>();
            try
            {
                var url = string.Format($"{_urlBase}{_hash}/v2/pedido/{id}");
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", $"Basic {_token}");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<List<pedido>>>(response.Content);
                    if (result.Result.codigo == "200")
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.mensagem;
                    }                        
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericSimpleResult Status(int id, byte status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format($"{_urlBase}{_hash}/v2/pedido/{id}/status/{status}");
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);                
                request.AddHeader("Authorization", $"Basic {_token}");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var retorno = JsonConvert.DeserializeObject<result<object>>(response.Content);
                    if (retorno.codigo == "200")
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = retorno.mensagem;
                    }
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
