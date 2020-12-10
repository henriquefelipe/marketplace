using OnPedido.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OnPedido.Domain;

namespace OnPedido.Service
{
    public class OnPedidoService
    {       
        public OnPedidoService() { }        

        public GenericResult<result> Orders(string token)
        {
            var result = new GenericResult<result>();
            try
            {
                var url = string.Format("{0}{1}{2}", Constants.URL, token, Constants.URL_ORDERS);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(response.Content);

                    string json = JsonConvert.SerializeXmlNode(xml);
                    result.Result = JsonConvert.DeserializeObject<result>(json);
                    result.Success = true;
                    result.Json = json;
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

        public GenericResult<result> Order(string token, string id)
        {
            var result = new GenericResult<result>();
            try
            {
                var url = string.Format("{0}{1}{2}{3}", Constants.URL, token, Constants.URL_ORDER, id);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(response.Content);

                    string json = JsonConvert.SerializeXmlNode(xml);
                    result.Result = JsonConvert.DeserializeObject<result>(json);                    
                    result.Success = true;
                    result.Json = json;
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
