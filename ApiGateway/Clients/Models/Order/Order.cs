using System.Collections.Generic;

namespace Clients.Models.Order
{
    public class Order
    {
        public User owner { get; set; }
        public List<OrderProduct> productList { get; set; }
    }
}