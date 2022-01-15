namespace Clients.Models.Order
{
    public class OrderProduct
    {
        public string productId { get; set; }
        public string unique_id { get; set; }
        public string URL { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public int retailPrice { get; set; }
        public int discountedPrice { get; set; }
        public string images { get; set; }
        public int stock { get; set; }
    }
}