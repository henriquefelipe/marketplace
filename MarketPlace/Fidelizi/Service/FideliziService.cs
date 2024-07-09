using Fidelizi.Domain;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidelizi.Service
{
    public class FideliziService
    {
        private string _url = "https://integracao.fidelizii.com.br/";
        private string _appToken = "";
        private string _accessTokenn = "";
        private string _idParceiro = "";

        public FideliziService(string appToken, string accessToken, string idParceiro)
        {
            _appToken = appToken;
            _accessTokenn = accessToken;
            _idParceiro = idParceiro;
        }

        public FideliziService(string appToken, string accessToken, string idParceiro, string url)
        {
            _appToken = appToken;
            _accessTokenn = accessToken;
            _idParceiro = idParceiro;
            _url = url;
        }

        public GenericResult<configuracao> GetConfiguracoes()
        {
            var result = new GenericResult<configuracao>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/fidelidade");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<configuracao>(response.Content);
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

        public GenericResult<pontuar> Pontuar(decimal valor_gasto, string cpf, string senha_atendente)
        {
            var result = new GenericResult<pontuar>();
            try
            {
                var data = new
                {
                    valor_gasto,
                    cpf,
                    senha_atendente
                };

                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/fidelidade/pontuar");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<pontuar>(response.Content);
                    result.Success = true;
                }
                else
                {
                    try
                    {
                        var erro = JsonConvert.DeserializeObject<erroResult>(response.Content);
                        if (erro.error)
                        {
                            foreach (var item in erro.messages)
                            {
                                result.Message += item;
                            }
                        }
                    }
                    catch { }

                    if (string.IsNullOrEmpty(result.Message))
                    {
                        result.Message = response.Content;
                    }
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<resgate> ResgatarPremio(int id_premio, int id_cliente, string senha_atendente)
        {
            var result = new GenericResult<resgate>();
            try
            {
                var data = new
                {
                    id_premio,
                    id_cliente,
                    senha_atendente
                };

                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/fidelidade/resgatar-premio");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<resgate>(response.Content);
                    result.Success = true;
                }
                else
                {
                    var erro = JsonConvert.DeserializeObject<erroResult>(response.Content);
                    if (erro.error)
                    {
                        foreach (var item in erro.messages)
                        {
                            result.Message += item;
                        }
                    }

                    if (string.IsNullOrEmpty(result.Message))
                    {
                        result.Message = response.Content;
                    }
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<resgate> EstornarPremio(int id_premio_cliente, string motivo)
        {
            var result = new GenericResult<resgate>();
            try
            {
                var data = new
                {
                    id_premio_cliente,
                    motivo
                };

                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/fidelidade/estornar-premio");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<resgate>(response.Content);
                    if (result.Result.success)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.message;
                    }
                }
                else
                {
                    try
                    {
                        var erro = JsonConvert.DeserializeObject<erro>(response.Content);
                        if (erro.error)
                        {
                            if (erro.messages.id_cliente.Any())
                            {
                                foreach (var item in erro.messages.id_cliente)
                                {
                                    result.Message += item;
                                }
                            }
                        }
                    }
                    catch { }

                    if (string.IsNullOrEmpty(result.Message))
                    {
                        result.Message = response.Content;
                    }
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<clientes> GetClientes()
        {
            var result = new GenericResult<clientes>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/clientes");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<clientes>(response.Content);
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

        public GenericResult<cliente> GetClienteId(int id_cliente)
        {
            var result = new GenericResult<cliente>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/clientes/{id_cliente}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<cliente>(response.Content);
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

        public GenericResult<clientes> GetClientePorCPF(string cpf)
        {
            var result = new GenericResult<clientes>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/clientes?cpf={cpf}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<clientes>(response.Content);
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

        public GenericResult<cliente> CadastrarCliente(cliente_cadastro cliente)
        {
            var result = new GenericResult<cliente>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/clientes");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                request.AddParameter("application/json", JsonConvert.SerializeObject(cliente), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<cliente>(response.Content);
                    result.Success = true;
                }
                else
                {
                    try
                    {
                        var erro = JsonConvert.DeserializeObject<erro>(response.Content);
                        if (erro.error)
                        {
                            if (erro.messages.nome.Any())
                            {
                                foreach (var item in erro.messages.nome)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.email.Any())
                            {
                                foreach (var item in erro.messages.email)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.cpf.Any())
                            {
                                foreach (var item in erro.messages.cpf)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.celular.Any())
                            {
                                foreach (var item in erro.messages.celular)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.data_nascimento.Any())
                            {
                                foreach (var item in erro.messages.data_nascimento)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.sexo.Any())
                            {
                                foreach (var item in erro.messages.sexo)
                                {
                                    result.Message += item;
                                }
                            }

                            if (erro.messages.estado.Any())
                            {
                                foreach (var item in erro.messages.estado)
                                {
                                    result.Message += item;
                                }
                            }
                        }
                    }
                    catch { }

                    if (string.IsNullOrEmpty(result.Message))
                    {
                        result.Message = response.Content;
                    }
                }

                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<List<atendente>> GetAtendentes()
        {
            var result = new GenericResult<List<atendente>>();
            try
            {
                var client = new RestClient(_url + $"v3/estabelecimentos/{_idParceiro}/atendentes");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("appToken", _appToken);
                request.AddHeader("accessToken", _accessTokenn);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<atendente>>(response.Content);
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
    }
}
