package com.Microservice.OrderService.Controller;

import com.Microservice.OrderService.Model.Order;
import com.Microservice.OrderService.Repository.OrderRepository;
import io.swagger.annotations.Api;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/order")
@Api(value = "Order Api")
public class OrderController {
    OrderRepository orderRepository;

    @Autowired
    public OrderController(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }

    @PostMapping
    public Order saveOrder(@RequestBody Order order){
        return orderRepository.save(order);
    }
}
