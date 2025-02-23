using System;
using System.Collections.Generic;
using RestSharp;
using BigFish.Domain;
using MarketPlace;

namespace BigFish.Service
{
    public class BigFishService
    {
        private readonly string _url;
        private readonly string _username;
        private readonly string _password;

        public BigFishService(string url, string username, string password)
        {
            _url = url;
            _username = username;
            _password = password;
        }

        // Método auxiliar para criar um RestRequest configurado
        private RestRequest CreateRequest(string xmlData)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("xml", xmlData, ParameterType.GetOrPost);
            return request;
        }

        // Método auxiliar para executar o cliente
        private IRestResponse ExecuteRequest(string xmlData)
        {
            var client = new RestClient(_url);
            var request = CreateRequest(xmlData);
            return client.Execute(request);
        }

        // Método auxiliar para construir o XML
        private string BuildXml(string command, Dictionary<string, string> elements)
        {
            var xml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                         <request>
                            <command>{command}</command>
                            <login>{_username}</login>
                            <password>{_password}</password>";
            foreach (var element in elements)
            {
                xml += $"<{element.Key}>{element.Value}</{element.Key}>";
            }
            xml += "</request>";
            return xml;
        }

        public GenericResult<ResponseOrders> Orders()
        {
            var result = new GenericResult<ResponseOrders>();
            try
            {
                var xmlData = BuildXml("GET_ALL_ORDERS", new Dictionary<string, string>());
                var response = ExecuteRequest(xmlData);

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
                var xmlData = BuildXml("GET_ORDER", new Dictionary<string, string>
                {
                    { "cod_pedido", codigo_pedido }
                });

                var response = ExecuteRequest(xmlData);

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
                var xmlData = BuildXml("SET_ORDERS", new Dictionary<string, string>
                {
                    { "row", $@"<rowpedidos><cod_pedido>{codigo_pedido}</cod_pedido><importado>1</importado></rowpedidos>" }
                });

                var response = ExecuteRequest(xmlData);

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
                var xmlData = BuildXml("SET_ORDER_STATUS", new Dictionary<string, string>
                {
                    { "cod_pedido", codigo_pedido },
                    { "status", status }
                });

                var response = ExecuteRequest(xmlData);

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

        public GenericResult<ResponseCustomer> GetCustomer(string documento)
        {
            var result = new GenericResult<ResponseCustomer>();
            try
            {
                var xmlData = BuildXml("GET_CUSTOMER", new Dictionary<string, string>
                {
                    { "documento", documento }
                });

                var response = ExecuteRequest(xmlData);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = response.Content.DeserializeXml<ResponseCustomer>();
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
