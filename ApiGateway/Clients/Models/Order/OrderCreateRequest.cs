namespace Clients.Models.Order
{
    public class OrderCreateRequest
    {
        public string basketId { get; set; }
        public User owner { get; set; }
    }
}