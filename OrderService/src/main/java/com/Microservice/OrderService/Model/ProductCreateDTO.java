package com.Microservice.OrderService.Model;

import lombok.Data;

@Data
public class ProductCreateDTO {
    private String productId;
    private String unique_id;
    private String URL;
    private String name;
    private String category;
    private String description;
    private String brand;
    private int retailPrice;
    private int discountedPrice;
    private String images;
    private int stock;
}
