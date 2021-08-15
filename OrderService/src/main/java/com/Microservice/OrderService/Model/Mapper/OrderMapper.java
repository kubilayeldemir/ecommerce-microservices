package com.Microservice.OrderService.Model.Mapper;

import com.Microservice.OrderService.Model.Order;
import com.Microservice.OrderService.Model.OrderCreateDTO;
import com.Microservice.OrderService.Model.Product;

public class OrderMapper {
    public static Order mapOrder(OrderCreateDTO dto) {

        var order = new Order().builder()
                .owner(dto.getOwner())
                .productList(ProductMapper.mapProducts(dto.getProductList()))
                .build();

        for (Product product : order.getProductList()) {
            product.setOrder(order);
        }
        return order;
    }
}
