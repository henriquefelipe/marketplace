using IDelivery.Domain;
using IDelivery.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDelivery.Service
{
    public class IDeliveryService
    {
        private string _url;
        private string _token;
        private string _merchantId;

        public IDeliveryService(string url, string merchantId, string token)
        {
            _url = url;
            _token = token;
            _merchantId = merchantId;
        }

        public GenericResult<List<order>> Orders(bool test = false)
        {
            var result = new GenericResult<List<order>>();
            try
            {
                var url = string.Format("{0}{1}?id_establishment={2}&test={3}", _url, Constants.URL_ORDER, _merchantId, test ? "true" : "false");
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", _token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseResult = JsonConvert.DeserializeObject<order_result>(response.Content);
                    if (responseResult.success)
                    {
                        result.Result = responseResult.data;
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = responseResult.message;
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

        public GenericSimpleResult Status(int id, int status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    id = id,
                    status = status
                };

                var url = string.Format("{0}{1}", _url, Constants.URL_ORDER_APPROVE);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (response.Content == Constants.STATUS_PEDIDO_ATUALIZADO)
                    {
                        result.Success = true;
                        result.Json = response.Content;
                    }
                    else
                    {
                        result.Message = response.Content;
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
