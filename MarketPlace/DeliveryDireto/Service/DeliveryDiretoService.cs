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
        private string _usuario = "";
        private string _senha = "";
        private string _merchantId = "";
        private string _token = "";

        public DeliveryDiretoService(string usuario, string senha, string merchantId, string token) 
        {
            _usuario = usuario;
            _senha = senha;
            _merchantId = merchantId;
            _token = token;
        }

        public GenericResult<wspdvresponse> Orders(DateTime data)
        {
            var result = new GenericResult<wspdvresponse>();
            try
            {
                var parametros = string.Format("login={0}&senha={1}&key={2}&idFrn={3}&status={4}&data={5}&contentType=json",
                        _usuario, _senha, _token, _merchantId, "00", data.ToString("yyyy-MM-dd HH:mm:ss"));

                var url = string.Format("{0}{1}?{2}", _urlBase, Constants.ORDER_SELECIONAR_PEDIDOS_ALTERADOS_A_PARTIR_DE, parametros);
                //var url = string.Format("{0}{1}", _urlBase, Constants.ORDER_SELECIONAR_PEDIDOS_ALTERADOS_A_PARTIR_DE);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                //request.AddParameter("login", _usuario);
                //request.AddParameter("senha", _senha);
                //request.AddParameter("key", _token);
                //request.AddParameter("idFrn", _merchantId);
                //request.AddParameter("contentType", "json");
                //request.AddParameter("status", "00");
                //request.AddParameter("data", data.ToString("aaaa-MM-dd HH:mm:ss"));

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //if (response.Content.Contains("wspdv-response"))
                    //{
                    //    result.Message = response.Content;
                    //}
                    //else
                    //{
                        result.Result = JsonConvert.DeserializeObject<wspdvresponse>(response.Content);
                        result.Success = true;                        
                    //}

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

        //public GenericResult<order> Order(string codPedido)
        //{
        //    var result = new GenericResult<order>();
        //    try
        //    {
        //        var url = string.Format("{0}{1}{2}", _urlBase, Constants.ORDER_GET, id);
        //        var client = new RestClient(url);
        //        var request = new RestRequest(Method.GET);
        //        request.AddHeader("Authorization", token);
        //        request.AddHeader("Accept", "application/json");
        //        IRestResponse response = client.Execute(request);
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var result_order = JsonConvert.DeserializeObject<result_order>(response.Content);
        //            if (result_order.success)
        //            {
        //                result.Result = result_order.info;
        //                result.Success = true;
        //                result.Json = response.Content;
        //            }
        //            else
        //            {
        //                result.Message = result_order.message;
        //            }
        //        }
        //        else
        //        {
        //            result.Message = response.Content + " - " + response.StatusDescription;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //    }
        //    return result;
        //}

    }
}
