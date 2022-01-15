using System.Collections.Generic;

namespace Clients.Models.Basket
{
    public class BasketPostRequest
    {
        public string basketId { get; set; }
        public List<string> products { get; set; }
    }
}