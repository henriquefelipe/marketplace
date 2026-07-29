using GoomerAbrahao.Domain;
using GoomerAbrahao.Enum;
using GoomerAbrahao.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GoomerAbrahao.Service
{
    public class GoomerAbrahaoService
    {
        private readonly RestClient _client;
        public GoomerAbrahaoService(string url, string token)
        {
            _client = new RestClient(url);

            _client.Authenticator = new JwtAuthenticator(token);
        }

        private string GetOrderTypeRoute(byte type)
        {
            return type == (byte)OrderType.Mesa ? "table" : "card";
        }

        #region Listagens pedido (mesa/comanda)
        /// <summary>
        /// Lista os pedidos pendentes.
        /// </summary>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<ResponseOrders> Orders()
        {
            var result = new GenericResult<ResponseOrders>();
            var request = new RestRequest($"{Constants.URL_ORDER}s", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                result.Result = JsonConvert.DeserializeObject<ResponseOrders>(response.Content);

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Listar as comandas/mesas em aberto.
        /// </summary>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<ResponseTableCard> OrdersOpen(byte type)
        {
            var result = new GenericResult<ResponseTableCard>();

            var orderType = GetOrderTypeRoute(type);
            var request = new RestRequest($"{orderType}s", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                result.Result = JsonConvert.DeserializeObject<ResponseTableCard>(response.Content);

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }
        #endregion

        #region Ações pedido (mesa/comanda)

        /// <summary>
        /// Marca um pedido como recebido.
        /// </summary>
        /// <param name="orderId">O id do pedido que será marcado como recebido.</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> OrderReceived(string orderId)
        {
            var result = new GenericResult<Response<object>>();
            
            var resource = $"{Constants.URL_ORDER}/{orderId}/{Constants.URL_RECEIVED}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                // Tenta deserializar. (Veja a observação abaixo)
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Marca um pedido como erro.
        /// </summary>
        /// <param name="orderId">O id do pedido que será marcado como erro.</param>
        /// <param name="errorMessage">Mensagem do erro retornado pela integração.</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> OrderError(string orderId, string errorMessage = null)
        {
            var result = new GenericResult<Response<object>>();

            var resource = $"{Constants.URL_ORDER}/{orderId}/{Constants.URL_ERROR}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                var body = new { error = errorMessage };
                request.AddJsonBody(body);
            }

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Fecha o consumo de uma mesa ou comanda e libera para uso novamente.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> CloseOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_CLOSE}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Cancela o consumo de uma mesa ou comanda e libera para uso novamente.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> CancelOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_CANCEL}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Reabre o consumo de uma mesa ou comanda que foi cancelada ou finalizada por engano.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> ReopenOrder(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_REOPEN}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Transfere os itens de uma mesa ou comanda para outra.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="newTableCode">O código da nova mesa ou comanda de destino.</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> TransferOrder(int tableCode, byte type, int newTableCode)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_TRANSFER}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            object body = type == (byte)OrderType.Mesa
            ? (object)new { new_table = newTableCode }
            : (object)new { new_card = newTableCode };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Obter extrato do consumo de uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<ResponseOrderBill>> OrderBill(int tableCode, byte type)
        {
            var result = new GenericResult<Response<ResponseOrderBill>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_BILL}";

            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<ResponseOrderBill>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Solicitar o fechamento do consumo de uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> OrderRequestBill(int tableCode, byte type)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_REQUEST_BILL}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        #region Ações itens da mesa/comanda
        /// <summary>
        /// Adiciona um item novo a uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item novo que será adicionado ao pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do item adicionado.</returns>
        public GenericResult<Response<OrderItem>> AddItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<OrderItem>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}";

            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(item);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<OrderItem>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Altera um item de uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item que será alterado no pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do item alterado.</returns>
        public GenericResult<Response<OrderItem>> UpdateItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<OrderItem>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(item);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<OrderItem>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Transfere um item de uma mesa ou comanda para outra.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item que será transferido do pedido (Mesa ou Comanda).</param>
        /// <param name="newTableCode">O código da nova mesa ou comanda de destino.</param>
        /// <returns>Um GenericResult contendo o status e os dados do item transferido.</returns>
        public GenericResult<Response<ResponseOrderNewItem>> TransferItemOrder(int tableCode, byte type, OrderItem item, int newTableCode)
        {
            var result = new GenericResult<Response<ResponseOrderNewItem>>();
            
            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}/{Constants.URL_TRANSFER}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            // Código da mesa/comanda e quantidade a ser transferida
            object body = type == (byte)OrderType.Mesa
            ? (object)new { new_table = newTableCode, quantity = item.Quantity }
            : (object)new { new_card = newTableCode, quantity = item.Quantity };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<ResponseOrderNewItem>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Cancela um item de uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item que será transferido do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do item cancelado.</returns>
        public GenericResult<Response<OrderItem>> CancelItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<OrderItem>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}/{Constants.URL_CANCEL}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            // Código da mesa/comanda e quantidade a ser transferida
            object body = new { quantity = item.Quantity };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<OrderItem>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }
        #endregion

        #region Ações pagamentos mesa/comanda
        /// <summary>
        /// Adiciona um novo pagamento a uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="paymentRequest">O novo pagamento que será adicionado ao pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do pagamento adicionado.</returns>
        public GenericResult<Response<OrderPaymentRequest>> AddPaymentOrder(int tableCode, byte type, OrderPaymentRequest paymentRequest)
        {
            var result = new GenericResult<Response<OrderPaymentRequest>>();
            
            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_PAYMENT}";

            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(paymentRequest);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<OrderPaymentRequest>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Cancela um pagamento de uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda de origem.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item que será transferido do pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do pagamento cancelado.</returns>
        public GenericResult<Response<OrderPayment>> CancelPaymentOrder(int tableCode, byte type, OrderPayment item)
        {
            var result = new GenericResult<Response<OrderPayment>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_PAYMENT}/{item.Id}/{Constants.URL_CANCEL}";

            var request = new RestRequest(resource, Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<OrderPayment>>(response.Content);
                }

                result.Success = result.Result.Success;
                if (!result.Success)
                    result.Message = result.Result.Message;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }
        #endregion

        #endregion
    }
}
