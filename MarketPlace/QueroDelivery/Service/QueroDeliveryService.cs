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
    }
}
