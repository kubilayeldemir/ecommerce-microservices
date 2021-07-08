package com.Ecommerce.ProductCatalog.Model;

import lombok.Data;

import java.util.List;
@Data
public class ProductCreateDTO {
    private String unique_id;
    private String URL;
    private String name;
    private List<String> category;
    private String description;
    private String brand;
    private int retailPrice;
    private int discountedPrice;
    private int stock;
    private List<String> images;
}
