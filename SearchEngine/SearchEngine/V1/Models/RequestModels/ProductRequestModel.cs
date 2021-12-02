using System;
using System.Collections.Generic;
using SearchEngine.Models;

namespace SearchEngine.V1.Models.RequestModels
{
    public class ProductRequestModel
    {
        public Guid Id { get; set; }
        public string UniqueId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<string> Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int RetailPrice { get; set; }
        public int DiscountedPrice { get; set; }
        public List<string> Images { get; set; }
        public int Stock { get; set; }

        public Product ToModel()
        {
            var product = new Product();
            product.Id = Id;
            product.UniqueId = UniqueId;
            product.Url = Url;
            product.Name = Name;
            product.Category = Category;
            product.Description = Description;
            product.Brand = Brand;
            product.RetailPrice = RetailPrice;
            product.DiscountedPrice = DiscountedPrice;
            product.Images = Images;
            product.Stock = Stock;
            return product;
        }
    }
}