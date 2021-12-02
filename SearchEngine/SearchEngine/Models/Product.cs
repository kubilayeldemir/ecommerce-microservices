using System;
using System.Collections.Generic;

namespace SearchEngine.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string UniqueId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<string> Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int RetailPrice { get; set; }
        public int DiscountedPrice { get; set; }
        public List<string> Images { get; set; }
        public int Stock { get; set; }
    }
}