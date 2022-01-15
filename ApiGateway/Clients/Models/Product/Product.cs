using System.Collections.Generic;

namespace Clients.Models
{
    public class Product
    {
        public string id { get; set; }
        public string unique_id { get; set; }
        public string URL { get; set; }
        public string name { get; set; }
        public List<string> category { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public int retailPrice { get; set; }
        public int discountedPrice { get; set; }
        public List<string> images { get; set; }
        public int stock { get; set; }
    }
}