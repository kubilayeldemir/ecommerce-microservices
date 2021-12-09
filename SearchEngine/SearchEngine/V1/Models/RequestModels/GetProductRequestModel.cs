using System.Collections.Generic;

namespace SearchEngine.V1.Models.RequestModels
{
    public class GetProductRequestModel
    {
        public string Name { get; set; }
        public List<string> Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public float RetailPrice { get; set; }
        public float DiscountedPrice { get; set; }
        public int Size { get; set; }
        public int From { get; set; }
    }
}