using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class responseConsultaPremios : response_base
    {
        public Dictionary<string, premios> data { get; set; }
    }    
}
