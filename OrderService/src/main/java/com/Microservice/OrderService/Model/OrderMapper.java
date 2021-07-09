package com.Microservice.OrderService.Model;

public class OrderMapper {
    public static Order mapOrder(OrderCreateDTO dto){
        return new Order().builder()
                .owner(dto.getOwner())
                .productList(dto.getProductList())
                .build();
    }
}
