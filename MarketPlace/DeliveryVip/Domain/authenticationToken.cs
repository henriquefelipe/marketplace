﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryVip.Domain
{
    public class authenticationToken
    {
        public string access_token {  get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public int created_at { get; set; }
    }
}
