using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Actions
    {
        public int ActionId { get; set; }
        public int? ActionTypeId { get; set; }
        public DateTime DateOfAction { get; set; }
        public int UserId { get; set; }

        public virtual ActionTypes ActionType { get; set; }
    }
}
