using System;
using System.Collections.Generic;

namespace Clients.Models.Basket
{
    public class BasketPostRequest
    {
        public String basketId { get; set; }
        public List<String> products { get; set; }
    }
}
