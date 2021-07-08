using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models.Basket
{
    public class BasketPostResponse
    {
        public String basketId { get; set; }
        public List<Product> products { get; set; }
    }
}
