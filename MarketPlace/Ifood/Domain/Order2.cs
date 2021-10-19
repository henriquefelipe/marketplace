using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class DeliveryAddress
    {
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string formattedAddress { get; set; }
        public string neighborhood { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Delivery
    {
        public string mode { get; set; }
        public string deliveredBy { get; set; }
        public DateTime deliveryDateTime { get; set; }
        public DeliveryAddress deliveryAddress { get; set; }
    }

    public class Merchant
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Phone
    {
        public string number { get; set; }
        public string localizer { get; set; }
        public DateTime localizerExpiration { get; set; }
    }

    public class Customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string documentNumber { get; set; }
        public Phone phone { get; set; }
        public int ordersCountOnMerchant { get; set; }
    }

    public class Option
    {
        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double addition { get; set; }
        public double price { get; set; }
    }

    public class Item
    {
        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public double optionsPrice { get; set; }
        public double totalPrice { get; set; }
        public List<Option> options { get; set; }
        public double price { get; set; }
    }

    public class Total
    {
        public double subTotal { get; set; }
        public double deliveryFee { get; set; }
        public int benefits { get; set; }
        public double orderAmount { get; set; }
        public double additionalFees { get; set; }
    }

    public class Cash
    {
        public double changeFor { get; set; }
    }

    public class Method2
    {
        public double value { get; set; }
        public string currency { get; set; }
        public string method { get; set; }
        public string type { get; set; }
        public Cash cash { get; set; }
        public bool prepaid { get; set; }
    }

    public class Payments
    {
        public int prepaid { get; set; }
        public double pending { get; set; }
        public List<Method2> methods { get; set; }
    }

    public class order2
    {
        public string id { get; set; }
        public Delivery delivery { get; set; }
        public string orderType { get; set; }
        public string orderTiming { get; set; }
        public string displayId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime preparationStartDateTime { get; set; }
        public bool isTest { get; set; }
        public Merchant merchant { get; set; }
        public Customer customer { get; set; }
        public List<Item> items { get; set; }
        public string salesChannel { get; set; }
        public Total total { get; set; }
        public Payments payments { get; set; }
    }


}
