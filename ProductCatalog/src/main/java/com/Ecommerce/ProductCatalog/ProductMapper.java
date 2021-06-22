package com.Ecommerce.ProductCatalog;

import java.util.ArrayList;
import java.util.List;

public class ProductMapper {
    public static Product getProductDTO(ProductCreateDTO pc){
        return new Product().builder().brand(pc.getBrand())
                .category(pc.getCategory())
                .description(pc.getDescription())
                .discountedPrice(pc.getDiscountedPrice())
                .images(pc.getImages())
                .name(pc.getName())
                .retailPrice(pc.getRetailPrice())
                .unique_id(pc.getUnique_id())
                .URL(pc.getURL())
                .stock(pc.getStock())
                .build();
    }
    public static List<Product> getProductDTOList(List<ProductCreateDTO> productCreateDTOList){
        List<Product> products = new ArrayList<>();
        for (ProductCreateDTO productDto : productCreateDTOList) {
           products.add(getProductDTO(productDto));
        }
        return products;
    }

}
