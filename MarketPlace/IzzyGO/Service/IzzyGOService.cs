using IzzyGO.Domain;
using IzzyGO.Enum;
using IzzyGO.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Service
{
    public class IzzyGOService
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public IzzyGOService(string baseUrl, string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient(baseUrl.TrimEnd('/'));
            // Configurar serialização camelCase
            SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
        }

        /// <summary>
        /// Cria uma nova entrega
        /// </summary>
        public DeliveryData CreateDelivery(DeliveryRequest request)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var restRequest = new RestRequest("/logistics/delivery", Method.POST);
            restRequest.AddHeader("X-API-Key", _apiKey);
            restRequest.AddHeader("Content-Type", "application/json");

            var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = _client.Execute(restRequest);

            if (!response.IsSuccessful)
            {
                throw new IzzyGOApiException(
                    $"Erro ao criar entrega: {response.StatusCode}",
                    (int)response.StatusCode,
                    response.Content
                );
            }

            return JsonConvert.DeserializeObject<DeliveryData>(response.Content);
        }

        public UpdateDeliveryStatusResponse UpdateDeliveryStatus(
                   string orderId,
                   string newStatus)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("orderId é obrigatório", nameof(orderId));

            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("newStatus é obrigatório", nameof(newStatus));

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = new RestRequest($"/logistics/delivery/{orderId}/status", Method.PATCH);
            request.AddHeader("X-API-Key", _apiKey);
            request.AddHeader("Content-Type", "application/json");

            var body = new UpdateDeliveryStatusRequest { Status = newStatus };
            request.AddJsonBody(body);

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new IzzyGOApiException(
                    $"Erro ao atualizar status: {response.StatusCode}",
                    (int)response.StatusCode,
                    response.Content);
            }

            return JsonConvert.DeserializeObject<UpdateDeliveryStatusResponse>(response.Content);
        }



        /// <summary>
        /// Busca entregas com filtros opcionais
        /// </summary>
        public List<DeliveryData> GetDeliveries(string status = null, string orderId = null)
        {
            var restRequest = new RestRequest("/logistics/delivery", Method.GET);
            restRequest.AddHeader("X-API-Key", _apiKey);

            if (!string.IsNullOrEmpty(status))
                restRequest.AddQueryParameter("status", status.ToUpper());

            if (!string.IsNullOrEmpty(orderId))
                restRequest.AddQueryParameter("orderId", orderId);
            
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = _client.Execute(restRequest);

            if (!response.IsSuccessful)
            {
                throw new IzzyGOApiException(
                    $"Erro ao buscar entregas: {response.StatusCode}",
                    (int)response.StatusCode,
                    response.Content
                );
            }

            var result = JsonConvert.DeserializeObject<GetDeliveriesResponse>(response.Content);
            return result?.Deliveries ?? new List<DeliveryData>();
        }

        /// <summary>
        /// Busca uma entrega específica pelo orderId
        /// </summary>
        public DeliveryData GetDeliveryByOrderId(string orderId)
        {
            var deliveries = GetDeliveries(orderId: orderId);
            return deliveries.Count > 0 ? deliveries[0] : null;
        }

        /// <summary>
        /// Busca entregas por status
        /// </summary>
        public List<DeliveryData> GetDeliveriesByStatus(string status)
        {
            return GetDeliveries(status: status.ToString().ToLower());
        }
    }

    // Response wrapper para GET
    public class GetDeliveriesResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("deliveries")]
        public List<DeliveryData> Deliveries { get; set; }
    }

    // Exceção customizada
    public class IzzyGOApiException : Exception
    {
        public int StatusCode { get; }
        public string ResponseBody { get; }

        public IzzyGOApiException(string message, int statusCode, string responseBody)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
        }
    }

}

