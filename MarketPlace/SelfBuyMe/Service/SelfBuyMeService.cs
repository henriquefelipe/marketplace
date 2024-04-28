using SelfBuyMe.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBuyMe.Service
{
    public class SelfBuyMeService
    {
        private string _url = "https://selfbuyme-dev.me2.com.br/api/";

        public SelfBuyMeService() { }

        public GenericResult<result<List<order>>> Orders(string token, string parametros)
        {
            var result = new GenericResult<result<List<order>>>();
            try
            {                
                var client = new RestClient(_url + $"orders{parametros}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);                

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<List<order>>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result<order>> Order(string token, int id)
        {
            var result = new GenericResult<result<order>>();
            try
            {
                var client = new RestClient(_url + $"orders/{id}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<order>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result<List<point_sale>>> PointSales(string token)
        {
            var result = new GenericResult<result<List<point_sale>>>();
            try
            {
                var client = new RestClient(_url + "pointSales");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<List<point_sale>>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result<List<point_sale_point_sale_group>>> PointSalesGroup(string token)
        {
            var result = new GenericResult<result<List<point_sale_point_sale_group>>>();
            try
            {
                var client = new RestClient(_url + "pointSalesGroups");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<List<point_sale_point_sale_group>>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<result<mark_read>> MarkRead(string token, List<int> ids)
        {
            var result = new GenericResult<result<mark_read>>();
            try
            {
                var dados = new
                {
                    order_ids = ids
                };

                var client = new RestClient(_url + "orders/izzy/mark-read");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<result<mark_read>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
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
