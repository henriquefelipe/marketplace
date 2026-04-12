using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OpenDelivery.Enum
{
    public class IndoorMode
    {
        public const string DEFAULT = "DEFAULT";                
        public const string PLACE = "PLACE";
        public const string TAB = "TAB";
        public const string TERMINAL = "TERMINAL";

        //DEFAULT: Used for orders placed in the Ordering Application to be consumed inside the merchant without a specific location.
        //PLACE: Used for orders placed in the Ordering Application to be consumed inside the merchant at a specific location already specified, such as a table or a counter.
        //TAB: Used for establishments that control orders via tabs or control cards(can be used in conjunction with the place field).
        //TERMINAL: Used for orders placed through self-services, such as kiosks, totems or tablets.
    }
}
