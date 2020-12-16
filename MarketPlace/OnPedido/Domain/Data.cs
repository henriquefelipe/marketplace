using System;
using System.Xml.Serialization;

namespace OnPedido.Domain
{
    [Serializable]
    public class Data
    {
        [XmlElement]
        public long timestamp { get; set; }
        [XmlElement]
        public string corrente { get; set; }
        [XmlIgnore]
        public DateTime local
        {
            get
            {
                return FromUnixDateTime(this.timestamp);
            }
        }

        private DateTime FromUnixDateTime(long timestamp)
        {
            DateTime dataInicial = new DateTime(1970, 1, 1, 0, 0, 0);

            DateTime dataFinal = dataInicial.AddSeconds((double)timestamp).ToLocalTime();

            return dataFinal;
        }
    }
}
