﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Responses
{
    public class LookupOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}