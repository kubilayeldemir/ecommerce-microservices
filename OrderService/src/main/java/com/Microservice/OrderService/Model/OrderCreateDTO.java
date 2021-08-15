package com.Microservice.OrderService.Model;


import lombok.Data;

import java.util.List;

@Data
public class OrderCreateDTO {
    private List<ProductCreateDTO> productList;
    private User owner;
}
