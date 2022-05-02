using Americanas.Domain;
using Americanas.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Americanas.Service
{
    public class AmericanasService
    {
        private string _urlBase;
        public AmericanasService(bool desenvolvedor = false) 
        {
            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<token> OathToken(string client_id, string client_secret)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    grant_type = "client_credentials",
                    client_id = client_id,
                    client_secret = client_secret
                };

                var url = _urlBase + Constants.URL_OAUTH;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");               
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);

                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                    result.Success = true;
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<erro>(responseToken.Content);
                    result.Message = responseToken.StatusDescription + $" {error.error} => {error.message}";
                }

                result.StatusCode = responseToken.StatusCode;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<List<orders>> Orders(string storeId, string token)
        {
            var result = new GenericResult<List<orders>>();

            var url = string.Format("{0}{1}{2}/{3}", _urlBase,  Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<orders>>(response.Content);
                result.Success = true;                
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<pedido> Order(string storeId, string id, string token)
        {
            var result = new GenericResult<pedido>();

            var url = string.Format("{0}{1}{2}/{3}/{4}", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<pedido>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        public GenericResult<retorno_status> Approve(string storeId, string id, string token)
        {
            var result = new GenericResult<retorno_status>();

            var url = string.Format("{0}{1}{2}/{3}/{4}/approve", _urlBase, Constants.URL_ORDERS, storeId, Constants.URL_ORDERS_ORDERS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<retorno_status>(response.Content);
                if (result.Result.order != null && result.Result.order.status == "A")
                {
                    result.Success = true;
                }
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;

            return result;
        }

        #region Ambiente de Teste

        public GenericResult<produto_teste> GetProducts(string storeId, string token)
        {
            var result = new GenericResult<produto_teste>();

            var url = string.Format("{0}{1}{2}/products", _urlBase, Constants.URL_ORDERS, storeId);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<produto_teste>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericSimpleResult CreateOrder(string client_id, string storeId, int produtoId, int quantidade)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    cliente_id = client_id,
                    loja_id = storeId,
                    produto_id = produtoId,
                    quantidade = quantidade
                };

                var url = "https://n8n.packk.com.br/webhook/create-order";
                //var url = "https://webhook.site/381c95d4-5fa7-4027-913c-7f1a21a2b87c";

                var client = new RestClient(url);

                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIyIiwianRpIjoiNTFkZjAyMzE1OTU2MjhjMGI4ZDVlZDc1Njg3YmFjMWZjZDlmMzA3ZGFmMWM0OWM0ZTAwM2NkZjcwMDA5M2YwZjdkNzY0ZmI5YmEzNzMxN2EiLCJpYXQiOjE2NDc1NDc4MjUuODM4NDQ0LCJuYmYiOjE2NDc1NDc4MjUuODM4NDg0LCJleHAiOjE2NzkwODM4MjUuODI1MTc2LCJzdWIiOiIiLCJzY29wZXMiOltdfQ.Uc56Usz3OFj45q1Z2oqKkcp7uV2PK1Z-dBNLxGZetCGpxSF42fAAy446SYpyIP6sh6m_OaFJ-bS6lRmtcAC1h18ZwTGeBoW5kqfs8IWEtej7gPkc3yPqJJY4xokTjsuBU4jKiRwprQLXlDwBbpVpIgjUmvk1qTkM3ZdG9ttb5NP190-igSf8MSwcBAZarHWsI7OkMXxmXluzcnBJT0wnkcebVr_mTCGdAxwirvulGyF3zLHJcQgnqrA0bnhq7GU0PpNBbMgyAynAvwdHHoIq1ZhHuZ9bLYWB4kOdvK2cnmzStpohCXFkT6hcKMHrL2ssPRk9VTm6Il9L_my90peWYOe32CkCVMWohOUfnfPMPY1ncpjlDf9nEv2CQ7ezvkGu6eOHOCxk7WwNz6lTWhKkJ8HgVQ4EpP2_sHJLqAHbJO0fJ96u4iIGKNKk8IO0PZgNJo-8KqmupgDLrdJEDzEfmRkU3LQTj23OkJZVQjrFtua3poc-aB-mFc17Cqi5QSKQduho23PAFsJNhG8MQHUsnlfxqVswEvZTZQ1Uy19qX6DAM54i5y2CJGfcBtJjCzriT6-Iz1HqfQHBUtGZOCGhyR8xfbtGbkU2LjGU5jadR7YD-K8USYuZFF07fgr49tdteohMExVnFBrRKz_jXnljpa41ALI8C8SVBgeKFlRakfY");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);

                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resultJson = responseToken.Content;
                    result.Success = true;
                }
                else
                {                    
                    result.Message = responseToken.Content;
                }

                result.StatusCode = responseToken.StatusCode;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        #endregion
    }
}
