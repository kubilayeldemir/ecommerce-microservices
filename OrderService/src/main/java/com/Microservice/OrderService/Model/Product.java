package com.Microservice.OrderService.Model;


import com.sun.istack.NotNull;
import lombok.Data;

import javax.persistence.*;
import java.util.List;
@Data
@Entity
public class Product {
    @Id
    @Column(name = "Id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotNull
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
