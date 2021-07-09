using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models.Order
{
    public class OrderCreateRequest
    {
        public String basketId { get; set; }
        public User owner { get; set; }
    }
}
