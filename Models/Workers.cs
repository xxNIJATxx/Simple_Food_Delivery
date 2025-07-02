using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Workers
    {
        public Workers()
        {
            Orders = new HashSet<Orders>();
        }

        public int WorkerId { get; set; }
        public string WorkerLogin { get; set; }
        public string WorkerPassword { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerPhone { get; set; }
        public string WorkerAddress { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurName { get; set; }
        public string WorkerLastName { get; set; }
        public string WorkerImage { get; set; }
        public int RoleId { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartWork { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
