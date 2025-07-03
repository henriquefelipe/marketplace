using FoodyDelivery.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace FoodyDelivery.Service
{
    public class FoodyDeliveryService
    {
        private const string URL = "https://app.foodydelivery.com/rest/1.2/";
        private string _tokenParceiro;
        private string _token;

        public FoodyDeliveryService(string tokenParceiro, string token)
        {
            _tokenParceiro = tokenParceiro;
            _token = token;
        }

        public GenericResult<OrderCreateResult> CreateOrder(OrderCreate model)
        {
            var result = new GenericResult<OrderCreateResult>();
            try
            {                
                var json = JsonConvert.SerializeObject(model);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient($"{URL}orders");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json;charset=UTF-8");
                request.AddHeader("Authorization", _token);
                request.AddHeader("SoftwareCompanyPartnerToken", _tokenParceiro);
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<OrderCreateResult>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericSimpleResult UpdateStatus(string uid, string status)
        {
            var result = new GenericSimpleResult();
            try
            {
                var model = new { status = status };
                var json = JsonConvert.SerializeObject(model);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient($"{URL}orders/updatestatus/{uid}");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json;charset=UTF-8");
                request.AddHeader("Authorization", _token);
                request.AddHeader("SoftwareCompanyPartnerToken", _tokenParceiro);
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {                    
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<OrderCreateResult> Order(string uid)
        {
            var result = new GenericResult<OrderCreateResult>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient($"{URL}orders/{uid}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json;charset=UTF-8");
                request.AddHeader("Authorization", _token);
                request.AddHeader("SoftwareCompanyPartnerToken", _tokenParceiro);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<OrderCreateResult>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<List<OrderCreateResult>> Orders(DateTime inicio, DateTime fim)
        {
            var result = new GenericResult<List<OrderCreateResult>>();
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient($"{URL}orders?startDate={inicio.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}&endDate={fim.ToString("yyyy-MM-dd'T'HH:mm:ssZ")}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json;charset=UTF-8");
                request.AddHeader("Authorization", _token);
                request.AddHeader("SoftwareCompanyPartnerToken", _tokenParceiro);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<OrderCreateResult>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content;
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
