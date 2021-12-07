using System.Collections.Generic;

namespace SearchEngine.V1.Models.RequestModels
{
    public class GetProductRequestModel
    {
        public string Name { get; set; }
        public List<string> Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int RetailPrice { get; set; }
        public int DiscountedPrice { get; set; }

    }
}