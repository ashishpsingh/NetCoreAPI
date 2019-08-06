using System;
using System.Collections.Generic;

namespace CoreAPI.DatabaseModels
{
    public partial class Customer
    {
        public int Customerid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Zip { get; set; }
        public string City { get; set; }
        public int? Phone { get; set; }
    }
}
