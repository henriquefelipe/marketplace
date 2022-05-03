using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Domain
{
    public class order
    {
        public order()
        {
            payments = new List<payment>();
            products = new List<product>();
        }

        public int id { get; set; }
        public int orderNumber { get; set; }
        public string externalId { get; set; }
        public string status { get; set; }
        public string deviceType { get; set; }
        public string table { get; set; }  //Mesa
        public string tab { get; set; } //Comanda
        public string identifierName { get; set; }
        public string identifierCode { get; set; }
        public string operation { get; set; }
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }
        public string deliveryWay { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal serviceFee { get; set; }
        public string orderDateTime { get; set; }
        public string deliveryDateTime { get; set; }
        public bool scheduled { get; set; }
        public string scheduledDateTime { get; set; }
        public address address { get; set; }
        public customer customer { get; set; }
        public string cpfFiscal { get; set; }
        public List<payment> payments { get; set; }
        public decimal paymentChange { get; set; }
        public List<product> products { get; set; }        
    }
}
