using System;

namespace Clients.Models.Order
{
    public class OrderCreateRequest
    {
        public String basketId { get; set; }
        public User owner { get; set; }
    }
}
