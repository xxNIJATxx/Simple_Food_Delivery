using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersCompositions = new HashSet<OrdersCompositions>();
        }

        public int OrderId { get; set; }
        public int CourierId { get; set; }
        public int UserId { get; set; }
        public string UserAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderStatus { get; set; }
        public decimal FinalPrice { get; set; }

        public virtual Workers Courier { get; set; }
        public virtual ActionTypes OrderStatusNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrdersCompositions> OrdersCompositions { get; set; }
    }
}
