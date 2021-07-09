using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models.Order
{
    public class Order
    {
        public User owner { get; set; }
        public List<OrderProduct> productList { get; set; }
    }
}
