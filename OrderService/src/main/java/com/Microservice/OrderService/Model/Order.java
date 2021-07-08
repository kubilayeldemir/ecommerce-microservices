package com.Microservice.OrderService.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
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
    @JsonIgnore
    private Long id;

    @OneToMany(cascade = {CascadeType.ALL})
    private List<Product> productList;

    @ManyToOne(cascade = {CascadeType.ALL})
    private User owner;
}
