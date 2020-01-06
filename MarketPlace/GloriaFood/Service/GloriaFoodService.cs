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

        public GenericResult<order> Polling(string token)
        {            
            var result = new GenericResult<order>();

            var url = string.Format("{0}{1}", _urlBase, Constants.POOL_LOCAL_SYSTEM);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization",  token);
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }
    }
}
