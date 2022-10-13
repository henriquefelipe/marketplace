using System;
using System.Collections.Generic;
using System.Text;

namespace CresceVendas.Domain
{
    public class responseFinalCompra
    {
        public responseFinalCompraObjeto response { get; set; }
    }

    public class responseFinalCompraObjeto
    {
        public responseFinalCompraObjeto()
        {
            errors = new List<error>();
        }

        public int code { get; set; }
        public string shop_id { get; set; }
        public int points { get; set; }
        public decimal balance { get; set; }
        public responseFinalCompraUser user { get; set; }
        public List<error> errors { get; set; }
    }

    public class responseFinalCompraUser
    {
        public string name { get; set; }
        public int total_points { get; set; }
        public decimal total_balance { get; set; }
        public responseFinalCompraUserAdress address { get; set; }
    }

    public class responseFinalCompraUserAdress
    {
        public string street { get; set; }
        public int number { get; set; }
        public string district { get; set; }
        public string adjunct { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
    }
}
