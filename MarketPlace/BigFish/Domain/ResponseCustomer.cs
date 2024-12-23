using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BigFish.Domain
{
    [XmlRoot("response")]
    public class ResponseCustomer
    {
        [XmlElement]
        public Customer customer { get; set; }
}
}
