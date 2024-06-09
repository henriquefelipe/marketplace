using FixeCRM.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixeCRM.Service
{
    public class FixeCRMService
    {
        private string _url = "https://api-hml.epossible.com.br/v1/";

        public FixeCRMService() { }


        public GenericResult<login> Login(string email, string password)
        {
            var result = new GenericResult<login>();
            try
            {
                var client = new RestClient(_url + $"auth/login?email={email}&password={password}");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<login>(response.Content);
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

        public GenericResult<consultaRetornaSelo> Pointsv2(string token, string id_passbook, string uniqueId)
        {
            var result = new GenericResult<consultaRetornaSelo>();
            try
            {
                var data = new pointsv2();
                data.id_passbook = id_passbook;
                data.uniqueId = uniqueId;

                token = token.Replace("JWT ", "");

                var client = new RestClient(_url + "pointsv2");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result.Result = JsonConvert.DeserializeObject<consultaRetornaSelo>(response.Content);
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

        public GenericResult<consultaRetornoPoint> AddPoints(string token, point point)
        {
            var result = new GenericResult<consultaRetornoPoint>();
            try
            {
                token = token.Replace("JWT ", "");

                var client = new RestClient(_url + "transaction/addPoints");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("application/json", JsonConvert.SerializeObject(point), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {                    
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                try
                {
                    result.Result = JsonConvert.DeserializeObject<consultaRetornoPoint>(response.Content);
                }
                catch { }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<consultaRetornoPoint> RemovePoints(string token, point point)
        {
            var result = new GenericResult<consultaRetornoPoint>();
            try
            {
                token = token.Replace("JWT ", "");

                var client = new RestClient(_url + "transaction/removePoints");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("application/json", JsonConvert.SerializeObject(point), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result.Success = true;
                }
                else
                {
                    result.Message = response.Content + " - " + response.StatusDescription;
                }

                try
                {
                    result.Result = JsonConvert.DeserializeObject<consultaRetornoPoint>(response.Content);
                }
                catch { }

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
