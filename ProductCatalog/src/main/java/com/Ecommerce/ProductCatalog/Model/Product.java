package com.Ecommerce.ProductCatalog.Model;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.List;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Document(collection = "products")
public class Product {
    @Id
    private String id;

    private String unique_id;
    private String URL;
    private String name;
    private List<String> category;
    private String description;
    private String brand;
    private int retailPrice;
    private int discountedPrice;
    private List<String> images;
    private int stock;
}
