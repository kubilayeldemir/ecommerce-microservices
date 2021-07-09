package com.Microservice.OrderService.Controller;

import com.Microservice.OrderService.Model.Order;
import com.Microservice.OrderService.Model.OrderCreateDTO;
import com.Microservice.OrderService.Model.OrderMapper;
import com.Microservice.OrderService.Repository.OrderRepository;
import io.swagger.annotations.Api;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

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
    public Order saveOrder(@RequestBody OrderCreateDTO order){
        return orderRepository.save(OrderMapper.mapOrder(order));
    }
    @GetMapping("/{orderId}")
    public ResponseEntity<Order> getOrder(@PathVariable UUID orderId){
        var order = orderRepository.findById(orderId);
        if(!order.isPresent()){
            return new ResponseEntity<>(null, HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(order.get(), HttpStatus.OK);
    }
}
