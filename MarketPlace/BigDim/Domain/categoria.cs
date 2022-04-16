using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class categoria
    {
        public int id { get; set; }
        public empresa empresa { get; set; }
        public string nome { get; set; }
        public string dataExclusao { get; set; }
        public bool status { get; set; }
        public string codigoPdv { get; set; }
        public int ordem { get; set; }
    }
}
