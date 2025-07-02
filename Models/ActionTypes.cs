using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class ActionTypes
    {
        public ActionTypes()
        {
            Actions = new HashSet<Actions>();
            Orders = new HashSet<Orders>();
        }

        public int ActionTypeId { get; set; }
        public string ActionTitle { get; set; }

        public virtual ICollection<Actions> Actions { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
