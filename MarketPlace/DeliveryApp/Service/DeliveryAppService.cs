using DeliveryApp.Domain;
using DeliveryApp.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Service
{
    public class DeliveryAppService
    {
        private string _urlBase = Constants.URL_BASE;
        public DeliveryAppService() { }


        public GenericResult<IEnumerable<order>> Orders(string token, int status = -1, byte limit = 50)
        {
            var result = new GenericResult<IEnumerable<order>>();
            try
            {
                var url = string.Format("{0}", _urlBase);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("token_account", token);
                request.AddParameter("limit", limit);
                if (status >= 0)
                {
                    request.AddParameter("status", status);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var resultOrder = JsonConvert.DeserializeObject<result_order>(response.Content);
                    if (resultOrder.code == 200)
                    {
                        result.Result = resultOrder.Orders;
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = string.Join(",", resultOrder.causes.Select(s => s.message));
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

        public GenericResult<order> Order(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var url = string.Format("{0}/{1}", _urlBase, orderId);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("token_account", token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var resultOrder = JsonConvert.DeserializeObject<result_order>(response.Content);
                    if (resultOrder.code == 200)
                    {
                        result.Result = resultOrder.Order;
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = string.Join(",", resultOrder.causes.Select(s => s.message));
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

        public GenericResult<order> Status(string token, string orderId, byte status)
        {
            var result = new GenericResult<order>();
            try
            {
                var url = string.Format("{0}/{1}", _urlBase, orderId);
                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("token_account", token);
                request.AddParameter("status", status);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var resultOrder = JsonConvert.DeserializeObject<result_order>(response.Content);
                    if (resultOrder.code == 200)
                    {
                        result.Result = resultOrder.Order;
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = string.Join(",", resultOrder.causes.Select(s => s.message));
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
    }
}
