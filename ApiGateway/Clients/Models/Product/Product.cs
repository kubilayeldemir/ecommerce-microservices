using System;
using System.Collections.Generic;

namespace Clients.Models
{
    public class Product
    {
        public String id { get; set; }
        public String unique_id { get; set; }
        public String URL { get; set; }
        public String name { get; set; }
        public List<String> category { get; set; }
        public String description { get; set; }
        public String brand { get; set; }
        public int retailPrice { get; set; }
        public int discountedPrice { get; set; }
        public List<String> images { get; set; }
        public int stock { get; set; }
    }
}
