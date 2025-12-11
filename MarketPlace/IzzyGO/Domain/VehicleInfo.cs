using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class VehicleInfo
    {
        public List<string> Types { get; set; }
        public string Container { get; set; }
        public string ContainerSize { get; set; }
        public string Instruction { get; set; }
    }
}
