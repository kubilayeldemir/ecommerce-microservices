package com.Microservice.OrderService.Model;

import lombok.Data;

import javax.persistence.*;
import java.util.List;

@Entity
@Data
@Table(name = "ORDERTABLE")
public class Order {
    @Id
    @Column(name = "OrderId")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @OneToMany
    private List<Product> productList;
}
