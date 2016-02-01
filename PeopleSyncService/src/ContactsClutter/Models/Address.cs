﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsClutter.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
        public string CountryOrRegion { get; set; }
        public string PostalCode { get; set; }
    }
        
}
