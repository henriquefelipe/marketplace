using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    [XmlRoot("response")]
    public class ResponseOrders
    {
        [XmlElement("total_registos")]
        public int totalRegistos {  get; set; }
        [XmlArray("orders")]
        [XmlArrayItem("row")]
        public List<Order> orders { get; set; }
        [XmlElement]
        public string erro { get; set; }
    }
}
