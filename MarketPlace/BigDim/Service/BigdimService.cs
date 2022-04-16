using Bigdim.Utils;
using Bigdim.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System;

namespace Bigdim.Service
{
    public class BigdimService
    {
        private string _token;
        public BigdimService(string token)
        {
            _token = token;
        }

        public GenericResult<result> PedidosPendentes()
        {
            var genericResult = new GenericResult<result>();

            try
            {
                var url = string.Format("{0}{1}", Constants.URL_ORDER, Constants.URL_ORDER_PENDENTES);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    genericResult.Result = JsonConvert.DeserializeObject<result>(response.Content);
                    genericResult.Success = true;
                }
                else
                {
                    try
                    {
                        var retorno = JsonConvert.DeserializeObject<error_result>(response.Content);
                        genericResult.Message = retorno.message;
                    }
                    catch
                    {
                        genericResult.Message = response.Content;
                    }
                }

                genericResult.Json = response.Content;
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }
            return genericResult;
        }


        public GenericSimpleResult AlterarStatus(string id, string status, string motivo = "")
        {
            var data = new
            {
                pedidoId = id,
                status = status,
                motivoCancelamento = motivo
            };


            var genericResult = new GenericSimpleResult();

            try
            {
                var url = string.Format("{0}alterar/status", Constants.URL_ORDER);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", string.Format("Bearer {0}", _token));
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    genericResult.Success = true;
                }
                else
                {
                    try
                    {
                        var retorno = JsonConvert.DeserializeObject<error_result>(response.Content);
                        genericResult.Message = retorno.message;
                    }
                    catch
                    {
                        genericResult.Message = response.Content;
                    }
                }
            }
            catch (Exception ex)
            {
                genericResult.Message = ex.Message;
            }

            return genericResult;
        }
    }
}
