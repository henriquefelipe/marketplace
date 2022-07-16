using DeliveryDireto.Domain;
using DeliveryDireto.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Service
{
    public class DeliveryDiretoService
    {
        private string _urlBase = Constants.URL_BASE;
        private string _parametros = "";       

        public DeliveryDiretoService(string usuario, string senha, string merchantId, string token)
        {            
            _parametros = string.Format("login={0}&senha={1}&key={2}&idFrn={3}&contentType=json",
                        usuario, senha, token, merchantId);
        }

        public GenericResult<List<string>> Orders(DateTime data, string status = "00")
        {
            var result = new GenericResult<List<string>>();
            try
            {                
                var url = string.Format("{0}{1}?{2}&status={3}&data={4}", _urlBase, Constants.ORDER_SELECIONAR_PEDIDOS_ALTERADOS_A_PARTIR_DE, _parametros,
                            status, data.ToString("yyyy-MM-dd HH:mm:ss"));
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseResult = JsonConvert.DeserializeObject<wspdvresponse<response_body_orders>>(response.Content);
                    if (responseResult != null && responseResult.wspdvResponse != null && responseResult.wspdvResponse.responseBody != null)
                    {
                        result.Result = responseResult.wspdvResponse.responseBody.codPedido;
                        result.Success = true;                        
                    }
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

        public GenericResult<order> Order(string codPedido)
        {
            var result = new GenericResult<order>();
            try
            {
                var url = string.Format("{0}{1}?{2}&codPedido={3}", _urlBase, Constants.ORDER_SELECIONA_PEDIDOS, _parametros,
                            codPedido);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result_order = JsonConvert.DeserializeObject<wspdvresponse<order>>(response.Content);
                    if (result_order.wspdvResponse.responseBody != null)
                    {
                        var pedido = result_order.wspdvResponse.responseBody;

                        var resultItens = OrderItens(codPedido);
                        if(resultItens.Success)
                        {
                            pedido.itens.AddRange(resultItens.Result);
                            result.Result = pedido;
                            result.Success = true;
                            result.Json = response.Content + resultItens.Json;
                        }
                        else
                        {
                            result.Json = response.Content;
                        }                        
                    }
                    else
                    {
                        result.Json = response.Content;
                        result.Message = result_order.wspdvResponse.responseMessage;
                    }
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

        public GenericResult<List<item>> OrderItens(string codPedido)
        {
            var result = new GenericResult<List<item>>();
            try
            {
                var url = string.Format("{0}{1}?{2}&codPedido={3}", _urlBase, Constants.ORDER_SELECIONA_ITENS, _parametros,
                            codPedido);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result_order = JsonConvert.DeserializeObject<wspdvresponse<response_body_order_item>>(response.Content);
                    if (result_order.wspdvResponse.responseBody != null)
                    {
                        result.Result = result_order.wspdvResponse.responseBody.item;
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = result_order.wspdvResponse.responseMessage;
                    }
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

        public GenericSimpleResult Status(string codPedido, string status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}?{2}&codPedido={3}&statusProcessamento={4}", _urlBase, Constants.ORDER_CONFIRMAR, _parametros,
                            codPedido, status);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result_order = JsonConvert.DeserializeObject<wspdvresponse<bool>>(response.Content);
                    if (result_order != null && result_order.wspdvResponse != null && result_order.wspdvResponse.responseBody)
                    {                        
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = result_order.wspdvResponse.responseMessage;
                    }
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
