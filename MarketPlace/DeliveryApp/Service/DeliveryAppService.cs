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
        

        public GenericResult<IEnumerable<order>> Order(string token)
        {
            var result = new GenericResult<IEnumerable<order>>();
            try
            {
                var url = string.Format("{0}", _urlBase);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", token);
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var orders = JsonConvert.DeserializeObject<IEnumerable<order>>(response.Content);
                    result.Result = orders;
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
