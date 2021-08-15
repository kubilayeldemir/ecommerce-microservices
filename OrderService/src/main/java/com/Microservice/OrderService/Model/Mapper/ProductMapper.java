package com.Microservice.OrderService.Model.Mapper;

import com.Microservice.OrderService.Model.Product;
import com.Microservice.OrderService.Model.ProductCreateDTO;

import java.util.ArrayList;
import java.util.List;

public class ProductMapper {
    public static Product mapProduct(ProductCreateDTO dto) {
        return new Product().builder()
                .brand(dto.getBrand())
                .category(dto.getCategory())
                .description(dto.getDescription())
                .discountedPrice(dto.getDiscountedPrice())
                .productId(dto.getProductId())
                .images(dto.getImages())
                .name(dto.getName())
                .retailPrice(dto.getRetailPrice())
                .stock(dto.getStock())
                .unique_id(dto.getUnique_id())
                .URL(dto.getURL())
                .build();
    }

    public static List<Product> mapProducts(List<ProductCreateDTO> dto) {
        List<Product> productList = new ArrayList<>();
        for (ProductCreateDTO product : dto) {
            productList.add(mapProduct(product));
        }
        return productList;
    }
}