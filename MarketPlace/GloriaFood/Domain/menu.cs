using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloriaFood.Domain
{
    public class menu
    {
        public menu()
        {
            categories = new List<menu_categories>();
        }

        public string[] languages { get; set; }
        public int id { get; set; }
        public string currency { get; set; }
        public string default_language { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int account_id { get; set; }
        public List<menu_categories> categories { get; set; }
    }
}
