using EuFalo.Domain;
using EuFalo.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace EuFalo.Service
{
    public class EuFaloService
    {    
        public EuFaloService()
        {
           
        }

        public GenericResult<login> Login(string email, string token)
        {
            var result = new GenericResult<login>();

            var data = new
            {
                revendaId = "10",
                userID = email,
                accessKey = token
            };

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_LOGIN);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);            
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<login>(response.Content);
                result.Success = true;
            }
            else
            {
                if (string.IsNullOrEmpty(response.Content))
                    result.Message = response.StatusDescription;
                else
                    result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        public GenericResult<retorno> CategoriaLista(string token, List<categoria> dados)
        {
            var result = new GenericResult<retorno>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_CATEGORIA_LISTA);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<retorno> ProdutoLista(string token, List<produto> dados)
        {
            var result = new GenericResult<retorno>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_PRODUTO_LISTA);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<retorno2> FormaPagamento(string token, formpagamento dados)
        {
            var result = new GenericResult<retorno2>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_FORMAPAGAMENTO);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno2>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<retorno2> Vendedor(string token, vendedor dados)
        {
            var result = new GenericResult<retorno2>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_VENDEDOR);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno2>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<retorno> Contato(string token, contato dados)
        {
            var result = new GenericResult<retorno>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_CONTATO_SALVAR);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
                        result.Message = response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<retorno> Venda(string token, venda dados)
        {
            var result = new GenericResult<retorno>();
            try
            {

                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_VENDA);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<saldo> ConsultarSaldoInstantaneo(string token, string documento)
        {
            var result = new GenericResult<saldo>();
            try
            {

                var url = string.Format("{0}{1}?CPF={2}", Constants.URL_BASE, Constants.URL_CONSULTA_SALDO, documento);
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");                
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<saldo>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<resgate> BaixarVoucherInstantaneo(string token, string documento, DateTime data, decimal valor)
        {
            var result = new GenericResult<resgate>();
            try
            {
                var dados = new
                {
                    cpf = documento,
                    dataResgate = data.ToString("yyyy-MM-ddTHH:mm:ss"),
                    valor = valor
                };


                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_BAIXAR_VOUCHER_INSTANTANEO);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<resgate>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<List<lista_cpf>> ListarPorCPF(string token, string documento)
        {
            var result = new GenericResult<List<lista_cpf>>();
            try
            {
                var dados = new
                {
                    cpf = documento,                    
                };


                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_LISTAR_POR_CPF);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<lista_cpf>>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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

        public GenericResult<retorno> BaixarVoucherMeta(string token, string documento, string numeroVoucher, DateTime data)
        {
            var result = new GenericResult<retorno>();
            try
            {
                var dados = new
                {
                    numeroVoucher,                    
                    cpf = documento,
                    dataBaixa = data.ToString("yyyy-MM-ddTHH:mm:ss"),
                };


                var url = string.Format("{0}{1}", Constants.URL_BASE, Constants.URL_BAIXAR_VOUCHER_META);
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dados), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno>(response.Content);
                    result.Success = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(response.Content))
                        result.Message = response.StatusDescription;
                    else
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
    }
}
