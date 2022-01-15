using System;

namespace Clients.Models.Order
{
    public class OrderProduct
    {
        public String productId { get; set; }
        public String unique_id { get; set; }
        public String URL { get; set; }
        public String name { get; set; }
        public String category { get; set; }
        public String description { get; set; }
        public String brand { get; set; }
        public int retailPrice { get; set; }
        public int discountedPrice { get; set; }
        public String images { get; set; }
        public int stock { get; set; }
    }
}
