using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Text.RegularExpressions;
using BigFish.Domain;
using BigFish.Utils;
using MarketPlace;

namespace BigFish.Service
{
    public class BigFishService
    {
        private string _url_subdomain { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }
        public BigFishService(string url_subdomain, string username, string password)
        {
            _url_subdomain = url_subdomain;
            _username = username;
            _password = password;
        }

        public GenericResult<ResponseOrders> Orders()
        {
            var result = new GenericResult<ResponseOrders>();
            try
            {
                var url = string.Format("https://{0}.{1}", _url_subdomain, Constants.URL);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                var xmlData = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <request>
                                    <command>GET_ALL_ORDERS</command>
                                    <login>{_username}</login>
                                    <password>{_password}</password>
                                </request>";
                request.AddParameter("xml", xmlData, ParameterType.GetOrPost);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = response.Content.DeserializeXml<ResponseOrders>();
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

        public GenericResult<ResponseOrder> Order(string codigo_pedido)
        {
            var result = new GenericResult<ResponseOrder>();
            try
            {
                var url = string.Format("https://{0}.{1}", _url_subdomain, Constants.URL);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                var xmlData = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <request>
                                    <command>GET_ORDER</command>
                                    <login>{_username}</login>
                                    <password>{_password}</password>
                                    <cod_pedido>{codigo_pedido}</cod_pedido>
                                </request>";
                request.AddParameter("xml", xmlData, ParameterType.GetOrPost);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (response.Content == "<onpedido></onpedido>")
                    {
                        result.Message = response.Content;
                        return result;
                    }

                    result.Result = response.Content.DeserializeXml<ResponseOrder>();
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

        public GenericSimpleResult Acknowledge(string codigo_pedido)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("https://{0}.{1}", _url_subdomain, Constants.URL);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                var xmlData = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <request>
                                    <command>SET_ORDERS</command>
                                    <login>{_username}</login>
                                    <password>{_password}</password>
                                    <row>
                                     <rowpedidos>
                                     <cod_pedido>{codigo_pedido}</cod_pedido>
                                     <importado>1</importado>
                                     </rowpedidos>
                                    </row>
                                </request>";
                request.AddParameter("xml", xmlData, ParameterType.GetOrPost);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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

        public GenericSimpleResult Status(string codigo_pedido, string status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("https://{0}.{1}", _url_subdomain, Constants.URL);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                var xmlData = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <request>
                                    <command>SET_ORDER_STATUS</command>
                                    <login>{_username}</login>
                                    <password>{_password}</password>
                                    <cod_pedido>{codigo_pedido}</cod_pedido>
                                    <status>{status}</status>
                                </request>";
                request.AddParameter("xml", xmlData, ParameterType.GetOrPost);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
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
