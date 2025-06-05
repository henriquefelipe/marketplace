using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    [XmlRoot("response")]
    public class ResponseOrder
    {
        [XmlElement]
        public string command { get; set; }
        [XmlElement(Type = typeof(Order))]
        public Order order { get; set; }
        [XmlElement]
        public string erro { get; set; }
    }
}
