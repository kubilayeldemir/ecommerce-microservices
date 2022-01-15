using System.Collections.Generic;

namespace Clients.Models.Order
{
    public class OrderProductMapper
    {
        public static OrderProduct MapOrderProduct(Product product)
        {
            var op = new OrderProduct();
            op.brand = product.brand;
            op.category = product.category[0];
            op.description = product.description;
            op.discountedPrice = product.discountedPrice;
            op.images = product.images[0];
            op.name = product.name;
            op.productId = product.id;
            op.retailPrice = product.retailPrice;
            op.stock = product.stock;
            op.unique_id = product.unique_id;
            op.URL = product.URL;
            return op;
        }
        public static List<OrderProduct> MapOrderProductsList(List<Product> products)
        {
            var mappedProducts = new List<OrderProduct>();
            foreach(var product in products)
            {
                mappedProducts.Add(MapOrderProduct(product));
            }
            return mappedProducts;
        }
    }
}
