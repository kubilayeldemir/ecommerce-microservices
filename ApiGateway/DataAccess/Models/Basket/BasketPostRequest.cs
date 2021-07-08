using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models.Basket
{
    public class BasketPostRequest
    {
        public String basketId { get; set; }
        public List<String> products { get; set; }
    }
}
