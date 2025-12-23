using System;
using System.Collections.Generic;
using IzzyGO.Domain;
using IzzyGO.Enum;
using IzzyGO.Service;

namespace IzzyGO.OpenDelivery.Examples
{
    public class IzzyGOExamples
    {
        private readonly IzzyGOService _service;

        private DeliveryResponse _response;

        public IzzyGOExamples(string url, string token)
        {
            _service = new IzzyGOService(url, token);
            _response = new DeliveryResponse() { Data = new List<string>() };
        }

        /// <summary>
        /// Exemplo 1: Criar entrega simples (campos mínimos obrigatórios)
        /// </summary>
        public DeliveryResponse CriarEntregaSimples()
        {
            var request = new DeliveryRequest
            {
                OrderId = "PED-" + DateTime.Now.Ticks,
                Customer = new CustomerInfo
                {
                    Name = "João Silva",
                    Phone = "85999998888"
                },
                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "Rua das Flores, 123 - Centro, Fortaleza - CE",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7319,
                        Longitude = -38.5267
                    }
                }
            };

            var response = _service.CreateDelivery(request);

            if (response.Success)
            {
                _response.Data.Add($"Entrega criada com sucesso!");
                _response.Data.Add($"ID: {response.Id}");
                _response.Data.Add($"Distância: {response.Distance} km");
                _response.Data.Add($"Taxa: R$ {response.Fee}");
                _response.Data.Add($"Tempo estimado: {response.EstimatedTime} min");
            }
            return _response;

        }

        /// <summary>
        /// Exemplo 2: Criar entrega completa (todos os campos)
        /// </summary>
        public DeliveryResponse CriarEntregaCompleta()
        {
            var request = new DeliveryRequest
            {
                OrderId = "PED-2024-001234",

                // Informações do estabelecimento
                Merchant = new MerchantInfo
                {
                    Id = "merchant-123",
                    Name = "Pizzaria Bella Napoli"
                },

                // Informações do cliente
                Customer = new CustomerInfo
                {
                    Name = "Maria Santos",
                    Phone = "85988887777",
                    PhoneLocalizer = "85"
                },

                // Endereço de entrega
                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "Av. Beira Mar, 4050, Apto 1201 - Meireles, Fortaleza - CE",
                    StreetName = "Avenida Beira Mar",
                    StreetNumber = "4050",
                    Neighborhood = "Meireles",
                    City = "Fortaleza",
                    State = "CE",
                    Country = "BR",
                    PostalCode = "60165-121",
                    Complement = "Apto 1201, Bloco A",
                    Reference = "Próximo ao Hotel Gran Marquise",
                    Instructions = "Ligar no interfone 1201",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7256,
                        Longitude = -38.4892
                    }
                },

                // Endereço de coleta
                PickupAddress = new PickupAddress
                {
                    FormattedAddress = "Rua Silva Jatahy, 1060 - Meireles, Fortaleza - CE",
                    StreetName = "Rua Silva Jatahy",
                    StreetNumber = "1060",
                    Neighborhood = "Meireles",
                    City = "Fortaleza",
                    State = "CE",
                    Country = "BR",
                    PostalCode = "60165-070",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7280,
                        Longitude = -38.4950
                    }
                },

                // Especificações do veículo
                Vehicle = new VehicleInfo
                {
                    Types = new List<string> { "motorcycle", "bicycle" },
                    Container = "bag",
                    ContainerSize = "large",
                    Instruction = "Manter na posição vertical"
                },

                // Informações do pacote
                Package = new PackageInfo
                {
                    Quantity = 2,
                    Volume = 15.5,
                    Weight = 2.3
                },

                // Flags de notificação
                Notifications = new NotificationFlags
                {
                    NotifyReadyForPickup = true,
                    NotifyPickup = true,
                    NotifyConclusion = true
                },

                // Preços do pedido
                Pricing = new OrderPricing
                {
                    TotalPrice = 89.90m,
                    TotalCurrency = "BRL",
                    DeliveryFee = 8.00m,
                    DeliveryFeeCurrency = "BRL"
                },

                // Formas de pagamento
                Payments = new List<PaymentInfo>
                {
                    new PaymentInfo
                    {
                        Method = "CREDIT_CARD",
                        Type = "ONLINE",
                        Value = 89.90m,
                        Currency = "BRL"
                    }
                },

                // Itens do pedido
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Name = "Pizza Grande Calabresa",
                        Quantity = 1,
                        Price = 59.90m,
                        Unit = "un",
                        ExternalCode = "PIZZA-001"
                    },
                    new OrderItem
                    {
                        Name = "Refrigerante 2L",
                        Quantity = 2,
                        Price = 15.00m,
                        Unit = "un",
                        ExternalCode = "BEB-002"
                    }
                },

                // Rastreamento de origem

                SourceAppId = "ifood",
                SourceOrderId = "IFOOD-ABC123",


                // Configurações adicionais
                SpecialInstructions = "Cliente alérgico a amendoim. Não incluir sachês.",
                PreparationStartDatetime = DateTime.Now,
                PickupLimit = 30,      // 30 minutos para coleta
                DeliveryLimit = 45,    // 45 minutos para entrega
                CanCombine = false,    // Não combinar com outras entregas
                ReturnToMerchant = false,
                ConfirmationCodeRequired = true
            };

            var response = _service.CreateDelivery(request);

            if (response.Success)
            {
                _response.Data.Add("═══════════════════════════════════════");
                _response.Data.Add("       ENTREGA CRIADA COM SUCESSO      ");
                _response.Data.Add("═══════════════════════════════════════");
                _response.Data.Add($"ID:              {response.Id}");
                _response.Data.Add($"Order ID:        {response.OrderId}");
                _response.Data.Add($"Status:          {response.Status}");
                _response.Data.Add($"Distância:       {response.Distance:F2} km");
                _response.Data.Add($"Taxa:            R$ {response.Fee:F2}");
                _response.Data.Add($"Tempo Estimado:  {response.EstimatedTime} min");
                _response.Data.Add($"Criado em:       {response.CreatedAt:dd/MM/yyyy HH:mm}");
                _response.Data.Add("═══════════════════════════════════════");
            }
            else
            {
                _response.Data.Add($"Erro: {response.Message}");
            }
            return _response;
        }

        /// <summary>
        /// Exemplo 3: Criar entrega com pagamento em dinheiro (troco)
        /// </summary>
        public void CriarEntregaComTroco()
        {
            var request = new DeliveryRequest
            {
                OrderId = "PED-DINHEIRO-001",
                Customer = new CustomerInfo
                {
                    Name = "Carlos Oliveira",
                    Phone = "85977776666"
                },
                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "Rua Padre Valdevino, 800 - Aldeota, Fortaleza - CE",
                    Neighborhood = "Aldeota",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7400,
                        Longitude = -38.5100
                    }
                },
                Pricing = new OrderPricing
                {
                    TotalPrice = 47.50m,
                    TotalCurrency = "BRL"
                },
                Payments = new List<PaymentInfo>
                {
                    new PaymentInfo
                    {
                        Method = "CASH",
                        Type = "OFFLINE",
                        Value = 47.50m,
                        Currency = "BRL",
                        ChangeFor = 100.00m  // Troco para R$ 100
                    }
                },
                SpecialInstructions = "Cliente pagará em dinheiro. Levar troco para R$ 100,00"
            };

            var response = _service.CreateDelivery(request);

            if (response.Success)
            {
                Console.WriteLine($"Entrega com troco criada: {response.Id}");
            }
        }

        /// <summary>
        /// Exemplo 4: Criar entrega integração iFood
        /// </summary>
        public void CriarEntregaIntegracaoIFood()
        {
            var request = new DeliveryRequest
            {
                OrderId = "IFOOD-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),

                Merchant = new MerchantInfo
                {
                    Id = "ifood-merchant-456",
                    Name = "Hamburgueria Top Burger"
                },

                Customer = new CustomerInfo
                {
                    Name = "Ana Paula",
                    Phone = "85966665555"
                },

                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "Rua Torres Câmara, 200 - Dionísio Torres",
                    StreetName = "Rua Torres Câmara",
                    StreetNumber = "200",
                    Neighborhood = "Dionísio Torres",
                    City = "Fortaleza",
                    State = "CE",
                    PostalCode = "60135-190",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7450,
                        Longitude = -38.5050
                    }
                },


                SourceAppId = "ifood",
                SourceOrderId = "IFOOD-ORIG-789456",

                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Name = "X-Bacon Duplo",
                        Quantity = 2,
                        Price = 35.90m,
                        ExternalCode = "XBACON-D"
                    },
                    new OrderItem
                    {
                        Name = "Batata Frita Grande",
                        Quantity = 1,
                        Price = 18.00m,
                        ExternalCode = "BATATA-G"
                    },
                    new OrderItem
                    {
                        Name = "Milk Shake Chocolate",
                        Quantity = 2,
                        Price = 16.00m,
                        ExternalCode = "MILK-CHOC"
                    }
                },

                Vehicle = new VehicleInfo
                {
                    Types = new List<string> { "motorcycle" },
                    Container = "bag"
                },

                Notifications = new NotificationFlags
                {
                    NotifyReadyForPickup = true,
                    NotifyPickup = true,
                    NotifyConclusion = true
                }
            };

            var response = _service.CreateDelivery(request);

            if (response.Success)
            {
                Console.WriteLine($"Entrega iFood criada: {response.Id}");
                Console.WriteLine($"Origem: {request.SourceAppId} - {request.OrderId}");
            }
        }

        /// <summary>
        /// Exemplo 5: Buscar todas as entregas
        /// </summary>
        public void BuscarTodasEntregas()
        {
            var deliveries = _service.GetDeliveries();

            Console.WriteLine($"\nTotal de entregas: {deliveries.Count}\n");

            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"[{delivery.Status}] {delivery.OrderId} - {delivery?.Id}");
            }
        }

        /// <summary>
        /// Exemplo 6: Buscar entregas por status
        /// </summary>
        public void BuscarEntregasPorStatus()
        {
            // Buscar entregas pendentes
            var pendentes = _service.GetDeliveriesByStatus(DeliveryStatus.Pending);
            Console.WriteLine($"Entregas pendentes: {pendentes.Count}");

            // Buscar entregas em trânsito
            var emTransito = _service.GetDeliveriesByStatus(DeliveryStatus.InTransit);
            Console.WriteLine($"Entregas em trânsito: {emTransito.Count}");

            // Buscar entregas entregues
            var entregues = _service.GetDeliveriesByStatus(DeliveryStatus.Delivered);
            Console.WriteLine($"Entregas concluídas: {entregues.Count}");
        }

        /// <summary>
        /// Exemplo 7: Buscar entrega específica por OrderId
        /// </summary>
        public void BuscarEntregaPorOrderId(string orderId)
        {
            var delivery = _service.GetDeliveryByOrderId(orderId);

            if (delivery != null)
            {
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("         DETALHES DA ENTREGA           ");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine($"ID:         {delivery?.Id}");
                Console.WriteLine($"Order ID:   {delivery.OrderId}");
                Console.WriteLine($"Status:     {delivery.Status}");
                Console.WriteLine($"Distância:  {delivery?.Distance:F2} km");
                Console.WriteLine($"Taxa:       R$ {delivery?.Fee:F2}");
                Console.WriteLine("═══════════════════════════════════════");
            }
            else
            {
                Console.WriteLine($"Entrega não encontrada: {orderId}");
            }
        }

        /// <summary>
        /// Exemplo 8: Fluxo completo - Criar e acompanhar entrega
        /// </summary>
        public DeliveryResponse FluxoCompleto()
        {
            _response.Data.Add("=== INICIANDO FLUXO COMPLETO ===\n");

            // 1. Criar entrega
            var request = new DeliveryRequest
            {
                OrderId = "FLUXO-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Customer = new CustomerInfo
                {
                    Name = "Cliente Teste Fluxo",
                    Phone = "85955554444"
                },
                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "Av. Santos Dumont, 1500 - Aldeota",
                    Neighborhood = "Aldeota",
                    Coordinates = new Coordinates
                    {
                        Latitude = -3.7350,
                        Longitude = -38.5000
                    }
                },
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Produto Teste", Quantity = 1, Price = 50.00m }
                },
                Pricing = new OrderPricing
                {
                    TotalPrice = 50.00m,
                    TotalCurrency = "BRL"
                }
            };

            _response.Data.Add("1. Criando entrega...");
            var response = _service.CreateDelivery(request);

            if (!response.Success)
            {
                _response.Data.Add($"Erro ao criar: {response.Message}");
                return _response;
            }

            _response.Data.Add($"   ✓ Entrega criada: {response.OrderId}");

            // 2. Consultar entrega criada
            _response.Data.Add("\n2. Consultando entrega...");
            var delivery = _service.GetDeliveryByOrderId(request.OrderId);

            if (delivery != null)
            {
                _response.Data.Add($"   ✓ Status atual: {delivery.Status}");
            }


            _response.Data.Add($"   ✓ Taxa calculada: R$ {response.Fee:F2}");

            var changestatus = _service.UpdateDeliveryStatus(response.OrderId, "READY_FOR_PICKUP");
            if (changestatus != null)
            {
                _response.Data.Add($"   ✓ Status Atualizado de {changestatus.PreviousStatus} para {changestatus.NewStatus}  ");
            }
            // 3. Listar todas pendentes
            _response.Data.Add("\n3. Listando entregas pendentes...");
            var pendentes = _service.GetDeliveriesByStatus(DeliveryStatus.Pending);
            _response.Data.Add($"   ✓ Total pendentes: {pendentes.Count}");

            _response.Data.Add("\n=== FLUXO COMPLETO FINALIZADO ===");

            return _response;
        }
    }
    public class DeliveryResponse
    {
        public bool Success { get; set; }
        public List<string> Data { get; set; }  // Lista de strings
        public string Error { get; set; }
    }
}
