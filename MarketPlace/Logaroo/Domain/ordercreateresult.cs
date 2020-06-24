using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class ordercreateresult
    {        
        public ordercreateresultdata data { get; set; }
    }
   
    public class ordercreateresultdata
    {
        public int id { get; set; }       
    }
}
