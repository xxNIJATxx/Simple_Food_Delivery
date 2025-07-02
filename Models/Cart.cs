using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Cart
    {
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public int CountOfProduct { get; set; }
        public string FoodImage { get; set; }
        public decimal FoodPrice { get; set; }
        public int CartActionId { get; set; }
    }
}
