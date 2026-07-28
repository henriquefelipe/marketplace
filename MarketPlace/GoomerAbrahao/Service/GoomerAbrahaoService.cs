using GoomerAbrahao.Domain;
using GoomerAbrahao.Enum;
using GoomerAbrahao.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using RestSharp.Serializers.NewtonsoftJson;

namespace GoomerAbrahao.Service
{
    public class GoomerAbrahaoService
    {
        private readonly RestClient _client;
        public GoomerAbrahaoService(string token)
        {
            var options = new RestClientOptions(Constants.URL_BASE)
            {
                Authenticator = new JwtAuthenticator(token)
            };
            _client = new RestClient(
                options,
                configureSerialization: s => s.UseNewtonsoftJson()
            );
        }

        private string GetOrderTypeRoute(byte type)
        {
            return type == (byte)OrderType.Mesa ? "table" : "card";
        }

        /// <summary>
        /// Lista os pedidos pendentes.
        /// </summary>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<ResponseOrders> Orders()
        {
            var result = new GenericResult<ResponseOrders>();
            var request = new RestRequest(Constants.URL_ORDERS, Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                result.Result = JsonConvert.DeserializeObject<ResponseOrders>(response.Content);
                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        #region Ações pedido (mesa/comanda)

        /// <summary>
        /// Marca um pedido como recebido.
        /// </summary>
        /// <param name="orderId">O id do pedido que será marcado como recebido.</param>
        /// <returns>Um GenericResult contendo o status e os dados da resposta da API.</returns>
        public GenericResult<Response<object>> OrderReceived(Guid orderId)
        {
            var result = new GenericResult<Response<object>>();
            
            var resource = $"{Constants.URL_ORDERS}/{orderId}/{Constants.URL_RECEIVED}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                // Tenta deserializar. (Veja a observação abaixo)
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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
        public GenericResult<Response<object>> OrderError(Guid orderId, string errorMessage = null)
        {
            var result = new GenericResult<Response<object>>();

            var resource = $"{Constants.URL_ORDERS}/{orderId}/{Constants.URL_ERROR}";

            var request = new RestRequest(resource, Method.Put);
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

                result.Success = true;
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

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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

            var request = new RestRequest(resource, Method.Put);
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

                result.Success = true;
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
        /// <returns>Um GenericResult contendo o status e os dados do pedido adicionado.</returns>
        public GenericResult<Response<object>> AddItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}";

            var request = new RestRequest(resource, Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(item);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
            }
            else
            {
                result.Message = response.Content;
            }

            result.Json = response.Content;
            return result;
        }

        /// <summary>
        /// Adiciona um item novo a uma mesa ou comanda.
        /// </summary>
        /// <param name="tableCode">O código da mesa ou comanda.</param>
        /// <param name="type">O tipo do pedido (Mesa ou Comanda).</param>
        /// <param name="item">O item que será alterado no pedido (Mesa ou Comanda).</param>
        /// <returns>Um GenericResult contendo o status e os dados do pedido alterado.</returns>
        public GenericResult<Response<object>> UpdateItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(item);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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
        /// <returns>Um GenericResult contendo o status e os dados do pedido alterado.</returns>
        public GenericResult<Response<object>> TransferItemOrder(int tableCode, byte type, OrderItem item, int newTableCode)
        {
            var result = new GenericResult<Response<object>>();
            
            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}/{Constants.URL_TRANSFER}";

            var request = new RestRequest(resource, Method.Put);
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
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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
        /// <returns>Um GenericResult contendo o status e os dados do pedido alterado.</returns>
        public GenericResult<Response<object>> CancelItemOrder(int tableCode, byte type, OrderItem item)
        {
            var result = new GenericResult<Response<object>>();

            var orderType = GetOrderTypeRoute(type);
            var resource = $"{orderType}/{tableCode}/{Constants.URL_ITEM}/{item.Id}/{Constants.URL_CANCEL}";

            var request = new RestRequest(resource, Method.Put);
            request.AddHeader("Accept", "application/json");

            // Código da mesa/comanda e quantidade a ser transferida
            object body = new { quantity = item.Quantity };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    result.Result = JsonConvert.DeserializeObject<Response<object>>(response.Content);
                }

                result.Success = true;
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
