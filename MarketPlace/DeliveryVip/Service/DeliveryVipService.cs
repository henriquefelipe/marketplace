using DeliveryVip.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryVip.Service
{
    public class DeliveryVipService
    {
        private string _url = "https://api.deliveryvip.com.br/";
       
        public GenericResult<authenticationToken> AuthenticationToken(string client_id, string client_secret)
        {
            var result = new GenericResult<authenticationToken>();
            try
            {
                var client = new RestClient(_url + $"authentication/v1/oauth/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Cookie", "X-Clever-Cloud-Sticky-Id=vj8znkedq9gldgmq9yvahw");
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("client_id", client_id);
                request.AddParameter("client_secret", client_secret);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<authenticationToken>(response.Content);
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

        public GenericResult<List<eventPooling>> EventPooling(string token, string merchants)
        {
            var result = new GenericResult<List<eventPooling>>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/events:polling");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("x-polling-merchants", merchants);
                request.AddHeader("Cookie", "X-Clever-Cloud-Sticky-Id=vj8znkedq9gldgmq9yvahw");

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<eventPooling>>(response.Content);
                    result.Success = true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    result.Result = new List<eventPooling>();
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

        public GenericResult<order> Order(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericResult<order> Confirm(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}/confirm");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericResult<order> ReadyForPickup(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}/readyForPickup");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericResult<order> Dispatch(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}/dispatch");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericResult<order> RequestCancellation(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}/requestCancellation");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericResult<order> Delivered(string token, string orderId)
        {
            var result = new GenericResult<order>();
            try
            {
                var client = new RestClient(_url + $"merchant/v3/orders/{orderId}/delivered");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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
