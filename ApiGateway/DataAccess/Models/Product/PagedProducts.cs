using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class PagedProducts
    {
        public int totalItems { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public List<Product> products { get; set; }
    }
}
