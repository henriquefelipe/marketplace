using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzzyGO.Domain
{
    public class NotificationFlags
    {
        public bool? NotifyReadyForPickup { get; set; }
        public bool? NotifyPickup { get; set; }
        public bool? NotifyConclusion { get; set; }
    }
}
