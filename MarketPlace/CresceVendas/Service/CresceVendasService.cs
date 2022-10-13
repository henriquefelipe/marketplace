using CresceVendas.Domain;
using CresceVendas.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Service
{
    public class CresceVendasService
    {
        private string _urlBase;
        private string _email;        
        private string _token;        

        public CresceVendasService(string email, string token, bool desenvolvedor = false)
        {
            this._email = email;
            this._token = token;

            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<responseFinalCompra> Compra(compra model)
        {
            var result = new GenericResult<responseFinalCompra>();
            try
            {                
                var url = _urlBase + Constants.URL_COMPRA;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-AdminUser-Email", _email);
                request.AddHeader("X-AdminUser-Token", _token);                             
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseFinalCompra>(response.Content);
                    if (result.Result.response.code == 200)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        foreach (var erro in result.Result.response.errors)
                            result.Message += erro.message;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var retorno = JsonConvert.DeserializeObject<responseError>(response.Content);
                    result.Message = retorno.response.error;
                }
                else if ((int)response.StatusCode == 422)
                {
                    var retorno = JsonConvert.DeserializeObject<responseValidacao>(response.Content);
                    foreach (var erro in retorno.response.errors)
                        result.Message += erro.message;
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<responseCheckBalance> ConsultarSaldo(string registration, decimal balance)
        {
            var result = new GenericResult<responseCheckBalance>();
            try
            {
                var model = new
                {
                    registration,
                    balance
                };

                var url = _urlBase + Constants.URL_CONSULTAR_SALDO;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-AdminUser-Email", _email);
                request.AddHeader("X-AdminUser-Token", _token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<responseCheckBalance>(response.Content);
                    if (result.Result.response.code == 200)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        foreach (var erro in result.Result.response.errors)
                            result.Message += erro.message;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var retorno = JsonConvert.DeserializeObject<responseError>(response.Content);
                    result.Message = retorno.response.error;
                }
                else if ((int)response.StatusCode == 422)
                {
                    var retorno = JsonConvert.DeserializeObject<responseValidacao>(response.Content);
                    foreach (var erro in retorno.response.errors)
                        result.Message += erro.message;
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericSimpleResult Cancelar(string coupon)
        {
            var result = new GenericSimpleResult();
            try
            {
                var model = new
                {
                    coupon
                };

                var url = _urlBase + Constants.URL_CANCELAR;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-AdminUser-Email", _email);
                request.AddHeader("X-AdminUser-Token", _token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var retorno = JsonConvert.DeserializeObject<responseError>(response.Content);
                    result.Message = retorno.response.error;
                }
                else if ((int)response.StatusCode == 422)
                {
                    var retorno = JsonConvert.DeserializeObject<responseValidacao>(response.Content);
                    foreach (var erro in retorno.response.errors)
                        result.Message += erro.message;
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericSimpleResult DiarioTotalCompras(int quantity, decimal total, string date)
        {
            var result = new GenericSimpleResult();
            try
            {
                var model = new
                {
                    quantity,
                    total,
                    date
                };

                var url = _urlBase + Constants.URL_DIARIO_TOTAL_COMPRAS;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-AdminUser-Email", _email);
                request.AddHeader("X-AdminUser-Token", _token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var retorno = JsonConvert.DeserializeObject<responseError>(response.Content);
                    result.Message = retorno.response.error;
                }
                else if ((int)response.StatusCode == 422)
                {
                    var retorno = JsonConvert.DeserializeObject<responseValidacao>(response.Content);
                    foreach (var erro in retorno.response.errors)
                        result.Message += erro.message;
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericSimpleResult PreCadastro(string registration, string phone)
        {
            var result = new GenericSimpleResult();
            try
            {
                var model = new
                {
                    registration,
                    phone
                };

                var url = _urlBase + Constants.URL_PRE_CADASTRO;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-AdminUser-Email", _email);
                request.AddHeader("X-AdminUser-Token", _token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var retorno = JsonConvert.DeserializeObject<responseError>(response.Content);
                    result.Message = retorno.response.error;
                }
                else if ((int)response.StatusCode == 422)
                {
                    var retorno = JsonConvert.DeserializeObject<responseValidacao>(response.Content);
                    foreach (var erro in retorno.response.errors)
                        result.Message += erro.message;
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
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
