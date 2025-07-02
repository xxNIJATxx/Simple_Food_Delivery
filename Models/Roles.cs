using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Workers = new HashSet<Workers>();
        }

        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
