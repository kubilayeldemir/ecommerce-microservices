package com.Ecommerce.ProductCatalog;

import lombok.Data;

import java.util.List;
@Data
public class ProductCreateDTO {
    private String unique_id;
    private String URL;
    private String name;
    private String category;
    private String description;
    private String brand;
    private int retailPrice;
    private int discountedPrice;
    private int stock;
    private List<String> images;
}
