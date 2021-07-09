package com.Microservice.OrderService.Model;


import lombok.Data;

import java.util.List;
@Data
public class OrderCreateDTO {
    private List<Product> productList;
    private User owner;
}
