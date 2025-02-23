using System;
using System.Collections.Generic;
using System.Text;

namespace DegustaAi.Domain
{
    public class notification
    {
        public string created_at { get; set; }
        public int tipo { get; set; }
        public string cod_notification { get; set; }
        public string cod_pdv_mesa { get; set; }
    }

    public class notificationResult : response_base
    {
        public notificationResult()
        {
            notifications = new List<notification>();
        }
        public List<notification> notifications { get; set; }
    }
}
