using GloriaFood.Domain;
using GloriaFood.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Service
{
    public class GloriaFoodService
    {
        private string _urlBase = Constants.URL_BASE;
        public GloriaFoodService() { }

        public GloriaFoodService(string urlBase)
        {
            _urlBase = urlBase;
        }

        public GenericResult<IEnumerable<order>> Polling(string token)
        {            
            var result = new GenericResult<IEnumerable<order>>();

            var url = string.Format("{0}{1}", _urlBase, Constants.POOL_LOCAL_SYSTEM);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization",  token);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var pollings = JsonConvert.DeserializeObject<polling>(response.Content);
                result.Result = pollings.orders;
                result.Success = true;
                result.Json = response.Content;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }
    }
}
