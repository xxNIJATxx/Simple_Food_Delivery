using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Products>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
