using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
        public int UnitsSaled { get; set; }
        public int CountLeft { get; set; }
        public string ProductImage { get; set; }
        public string ProductDesc { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
