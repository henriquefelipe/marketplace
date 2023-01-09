using QueroDelivery.Domain;
using QueroDelivery.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;


namespace QueroDelivery.Service
{
    public class QueroDeliveryService
    {
        public QueroDeliveryService() { }

        public GenericResult<List<orders>> Orders(string token, string placeid)
        {
            var result = new GenericResult<List<orders>>();
            try
            {
                var url = string.Format("{0}{1}/{2}?placeId={3}", Constants.URL_BASE, Constants.URL_ORDER, Constants.URL_EVENT_POOLING, placeid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic "+token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<orders>>(response.Content);
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

        public GenericResult<order> Order(string token, string placeid, string orderid)
        {
            var result = new GenericResult<order>();
            try
            {
                var url = string.Format("{0}{1}?placeId={2}&orderId={3}", Constants.URL_BASE, Constants.URL_ORDER, placeid, orderid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Basic " + token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<order>(response.Content);
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

        public GenericSimpleResult Accept(string token, string placeid, string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}/{2}/{3}?placeId={4}", Constants.URL_BASE, Constants.URL_ORDER, orderid, Constants.URL_ORDER_CONFIRM, placeid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
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

        public GenericSimpleResult Ready(string token, string placeid, string orderid)
        {
            var result = new GenericSimpleResult();
            try
            {
                var url = string.Format("{0}{1}/{2}/{3}?placeId={4}", Constants.URL_BASE, Constants.URL_ORDER, orderid, Constants.URL_ORDER_READY_TO_PICKUP, placeid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + token);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
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

        public GenericSimpleResult Cancel(string token, string placeid, string orderid, string motivo)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    reason = motivo,
                    code = "SYSTEMIC_ISSUES",
                    mode = "AUTO"
                };

                var url = string.Format("{0}{1}/{2}/{3}?placeId={4}", Constants.URL_BASE, Constants.URL_ORDER, orderid, Constants.URL_ORDER_REJECTION, placeid);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic " + token);
                request.AddJsonBody(data);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
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
