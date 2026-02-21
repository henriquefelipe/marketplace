using OpenDelivery.Domain;
using OpenDelivery.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace OpenDelivery.Service
{
    public class OpenDeliveryService
    {
        private string _urlBase;

        public OpenDeliveryService(string urlBase)
        {
            _urlBase = urlBase;
        }


        public GenericResult<token> OathToken(string client_id, string client_secret)
        {
            var result = new GenericResult<token>();
            try
            {
                var data = new
                {
                    client_id,
                    client_secret,
                    grant_type = "client_credentials"
                };

                var url = _urlBase + Constants.URL_TOKEN;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

                IRestResponse responseToken = client.Execute(request);
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<token>(responseToken.Content);
                    result.Success = true;
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<error_return>(responseToken.Content);
                    result.Message = responseToken.StatusDescription + $" => {error.error.message}";
                }

                result.StatusCode = responseToken.StatusCode;
                result.Json = responseToken.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }


        #region Eventos

        public GenericResult<List<status>> Status(string token, string merchantGuid)
        {
            var result = new GenericResult<List<status>>();

            var url = string.Format("{0}merchant/v1.0/merchants/{1}/status/", _urlBase, merchantGuid);
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<status>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
            }
            else
            {
                var retorno = JsonConvert.DeserializeObject<error_return>(response.Content);
                if (retorno != null && retorno.error != null)
                    result.Message = retorno.error.message;
                else
                    result.Message = response.Content;
            }

            result.StatusCode = response.StatusCode;
            return result;
        }

        /// <summary>
        /// Obtém todos os eventos ainda não recebidos.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public GenericResult<List<poolingEvent>> EventPolling(string token, string merchantid, string eventTypes = "?eventType=CREATED")
        {
            var result = new GenericResult<List<poolingEvent>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_EVENT_POOLING, eventTypes);
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            if (!string.IsNullOrEmpty(merchantid))
                request.AddHeader("x-polling-merchants", merchantid);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<poolingEvent>>(response.Content);
                result.Success = true;
                result.Json = response.Content;

            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result.Result = new List<poolingEvent>();
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            result.StatusCode = response.StatusCode;
            result.Request = client.requestResult;
            result.Response = client.responsetResult;

            return result;
        }

        /// <summary>
        /// Após o e-PDV receber os eventos do IFood, para cada evento que o e-PDV conseguiu realizar o parse e integrá-lo com sucesso, o e-PDV deve enviar uma requisição confirmando o recebimento dos eventos.
        /// Recomenda-se que o e-PDV envie uma lista de todos os eventos recebidos com sucesso de uma única vez.Importante salientar que apenas o id do evento é obrigatório.
        /// O IFood processará as notificações e removê-los da fila de eventos do e-PDV.
        /// Na próxima requisição que o e-PDV consulta por novos eventos, os eventos previamente confirmados não farão mais parte da resposta..  
        /// </summary>
        /// <param name="token"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public GenericSimpleResult EventAcknowledgment(string token, List<eventAcknowledgment> events)
        {
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}", _urlBase, Constants.URL_EVENT_ACNOWLEDGMENT);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(events);
            //request.AddParameter("data", events, ParameterType.RequestBody);            
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            return result;
        }


        #endregion

        #region Pedido

        /// <summary>
        /// Geralmente, após o e-PDV receber um evento com o código 'PLACED', é necessário obter os detalhes do pedido.
        /// Neste cenário, o campo correlationId do evento refere-se à referência do pedido e deve ser fornecido a este endpoint.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericResult<order> Orders(string token, string reference)
        {
            var result = new GenericResult<order>();
            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_ORDER, reference);
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            var response = client.Execute<RestObject>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<order>(response.Content);
                result.Success = true;
                result.Json = response.Content;
                result.Request = client.requestResult;
                result.Response = client.responsetResult;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            result.Request = client.requestResult;
            result.Response = client.responsetResult;
            result.StatusCode = response.StatusCode;
            return result;
        }

        /// <summary>
        /// Informa ao IFood que o pedido foi confirmado pelo e-PDV.        
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericSimpleResult OrdersConfirmation(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_CONFIRM);
            var client = new RestClientBase(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.Request = client.requestResult;
            result.Response = client.responsetResult;
            result.StatusCode = response.StatusCode;

            return result;
        }

        public GenericSimpleResult OrdersStarPreparation(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_PREPARING);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }

            return result;
        }


        /// <summary>
        /// Informa ao IFood que o pedido saiu para ser entregue ao cliente.       
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericSimpleResult OrdersDispatch(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_DISPATCH);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;

            return result;
        }

        /// <summary>
        /// Informa ao IFood que o pedido foi rejeitado pelo e-PDV.  
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericSimpleResult OrdersRejection(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_REJECTION);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;

            return result;
        }

        public GenericSimpleResult OrdersReadyToPickup(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_READY_TO_PICKUP);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;

            return result;
        }

        #endregion

        #region Cancelamento

        /// <summary>
        /// Solicita o Cancelamento do Pedido
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <param name="code"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public GenericSimpleResult CancellationRequested(string token, string reference, short code, string detail)
        {
            var data = new
            {
                cancellationCode = code.ToString(),
                reason = detail
            };

            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_CANCELATION);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(response.Content))
                {
                    try
                    {
                        var resultMessage = JsonConvert.DeserializeObject<error_cancel>(response.Content);
                        result.Message = resultMessage.error.message;
                    }
                    catch { }
                }

                if (string.IsNullOrEmpty(result.Message))
                    result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;

            return result;
        }

        /// <summary>
        /// Aceita a solicitação de cancelamento feita pelo cliente
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericSimpleResult CancellationAccepted(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_CANCELATION_ACCEPTED);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;
            return result;
        }

        /// <summary>
        /// Rejeita a solicitação de cancelamento feita pelo cliente
        /// </summary>
        /// <param name="token"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public GenericSimpleResult CancellationDenied(string token, string reference)
        {
            var data = new { };
            var result = new GenericSimpleResult();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_ORDER, reference, Constants.URL_ORDER_CANCELATION_ACCEPTED);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Success = true;
            }
            else
            {
                result.Message = response.StatusDescription;
            }
            result.StatusCode = response.StatusCode;
            return result;
        }

        #endregion

    }
}
