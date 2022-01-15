using System;
using System.Collections.Generic;

namespace Clients.Models.Basket
{
    public class BasketPostResponse
    {
        public String basketId { get; set; }
        public List<Product> products { get; set; }
    }
}
