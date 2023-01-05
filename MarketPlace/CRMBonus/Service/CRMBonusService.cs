using CRMBonus.Domain;
using CRMBonus.Enum;
using CRMBonus.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMBonus.Service
{
    public class CRMBonusService
    {
        private string _urlBase;
        private string _celular;
        private int _codloja;
        private string _authorizationBase64;
        private string _codempresaBase64;
        private string _celularBase64;

        public CRMBonusService(string authorization, string codempresa, int codloja, string celular, bool desenvolvedor = false)
        {
            this._codloja = codloja;
            this._celular = celular;

            byte[] authorizationAsBytes = Encoding.ASCII.GetBytes(authorization);
            this._authorizationBase64 = System.Convert.ToBase64String(authorizationAsBytes);

            byte[] codempresaAsBytes = Encoding.ASCII.GetBytes(codempresa);
            this._codempresaBase64 = System.Convert.ToBase64String(codempresaAsBytes);

            if (!string.IsNullOrEmpty(celular))
            {
                byte[] celularAsBytes = Encoding.ASCII.GetBytes(celular);
                this._celularBase64 = System.Convert.ToBase64String(celularAsBytes);
            }

            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<retorno<retorno_inicio>> Inicio(string customerName, string customerEmail, string customerBirth, string customercpf)
        {
            var result = new GenericResult<retorno<retorno_inicio>>();
            try
            {
                var data = new
                {
                    cod_loja = _codloja,
                    customer_name = customerName,
                    customer_cel = _celular,
                    customer_email = customerEmail,
                    customer_birth = customerBirth,
                    customer_cpf = customercpf
                };

                var url = _urlBase + Constants.URL_INICIO;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);                
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_inicio>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericResult<retorno<retorno_validar_pin>> ValidarPin(string pin, int customer_id)
        {
            var result = new GenericResult<retorno<retorno_validar_pin>>();
            try
            {
                var data = new
                {
                    pin = pin,
                    loja_id = _codloja,
                    customer_id = customer_id
                };

                var url = _urlBase + Constants.URL_VALIDAR_PIN;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_validar_pin>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericResult<retorno<retorno_inicio>> ReenviarPin(int customer_id)
        {
            var result = new GenericResult<retorno<retorno_inicio>>();
            try
            {
                var data = new
                {                    
                    loja_id = _codloja,
                    customer_id = customer_id
                };

                var url = _urlBase + Constants.URL_REENVIAR_PIN;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_inicio>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericResult<retorno<retorno_bonus_disponivel>> BonusDisponivel(int customer_id, decimal valorBruto)
        {
            var result = new GenericResult<retorno<retorno_bonus_disponivel>>();
            try
            {
                var data = new
                {
                    loja_id = _codloja,
                    customer_id = customer_id,
                    valor_bruto = valorBruto
                };

                var url = _urlBase + Constants.URL_BONUS_DISPONIVEL;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_bonus_disponivel>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericResult<retorno<retorno_campanha_disponivel>> CampanhaDisponivel(decimal totalLiquido)
        {
            var result = new GenericResult<retorno<retorno_campanha_disponivel>>();
            try
            {
                var data = new
                {
                    loja_id = _codloja,
                    total_liquido = totalLiquido
                };

                var url = _urlBase + Constants.URL_CAMPANHA_DISPONIVEL;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_campanha_disponivel>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericResult<retorno<retorno_finalizar_compra>> FinalizarCompra(bool restricaoHorario, bool vaiUtilizarBonus, string idsBonus,
                int customerId, decimal bonusResgatado, int campanhaId, string sms, bool pinMaster, string nf, string nomeVendedor, decimal valorBruto,
                string terminal, string ticket)
        {
            var result = new GenericResult<retorno<retorno_finalizar_compra>>();
            try
            {
                var data = new
                {
                    loja_id = _codloja,
                    restricao_horario = restricaoHorario,
                    vai_utilizar_bonus = vaiUtilizarBonus,
                    ids_bonus = idsBonus,
                    customer_id = customerId,
                    valor_bruto = valorBruto,
                    bonus_resgatado = bonusResgatado,
                    campanha_id = campanhaId,
                    sms = sms,
                    pin_master = pinMaster,
                    nome_vendedor = nomeVendedor,
                    nf = nf,
                    terminal = terminal,
                    ticket = ticket
                };

                var url = _urlBase + Constants.URL_FINALIZA_COMPRA;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_finalizar_compra>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
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

        public GenericResult<retorno<retorno_venda_totais>> VendaTotais(decimal totalVendaLiquida, int qtdTotalItens, string nomeVendedor,
                    string nomeConsumidor, string celularConsumidor, int bonusId, int orderId, string nrPedido)
        {
            var result = new GenericResult<retorno<retorno_venda_totais>>();
            try
            {
                var data = new
                {
                    total_venda_liquida = totalVendaLiquida,
                    qtd_total_itens = qtdTotalItens,
                    nome_vendedor = nomeVendedor,
                    nome_consumidor = nomeConsumidor,
                    celular_consumidor = celularConsumidor,
                    bonus_id = bonusId,
                    order_id = orderId,
                    nr_pedido = nrPedido
                };

                var url = _urlBase + Constants.URL_VENDAS_TOTAIS;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<retorno<retorno_venda_totais>>(response.Content);
                    if (result.Result.message == Message.SUCESSO || result.Result.message == Message.SUCESSO_COM_PONTO)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = result.Result.data.msg;
                    }
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

        public GenericSimpleResult CancelarBonus(string nrPedido, int customer_id)
        {
            var result = new GenericSimpleResult();
            try
            {
                var data = new
                {
                    loja_id = _codloja,
                    customer_id = customer_id,                   
                    bonus_id = nrPedido
                };

                var url = _urlBase + Constants.URL_CANCELAR_BONUS;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorizationBase64);
                request.AddHeader("Codempresa", _codempresaBase64);
                request.AddHeader("Celular", _celularBase64);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var retorno = JsonConvert.DeserializeObject<retorno_cancelar_bonus>(response.Content);
                    if (retorno.status)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        if (retorno.message != null)
                            result.Message = retorno.message.msg;
                        else if (retorno.data != null)
                            result.Message = retorno.data.msg;
                        else
                            result.Message = response.Content;
                    }
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
