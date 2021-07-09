package com.Microservice.OrderService.Model;


import com.fasterxml.jackson.annotation.JsonIgnore;
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
    @JsonIgnore
    private Long id;

    @NotNull
    private String productId;
    private String unique_id;

    @Column(length = 9999)
    private String URL;
    private String name;
    private String category;

    @Column(length = 9999)
    private String description;
    private String brand;
    private int retailPrice;
    private int discountedPrice;

    @Column(length = 9999)
    private String images;
    private int stock;
}
