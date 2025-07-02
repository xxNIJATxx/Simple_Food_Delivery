using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class OrdersCompositions
    {
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int CountOfProduct { get; set; }
        public int UselessColumn { get; set; }

        public virtual Orders Order { get; set; }
    }
}
