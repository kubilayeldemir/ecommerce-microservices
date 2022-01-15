using System.Collections.Generic;

namespace Clients.Models.Basket
{
    public class BasketPostResponse
    {
        public string basketId { get; set; }
        public List<Product> products { get; set; }
    }
}