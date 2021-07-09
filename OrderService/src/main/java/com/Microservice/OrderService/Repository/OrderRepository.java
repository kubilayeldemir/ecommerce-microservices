package com.Microservice.OrderService.Repository;

import com.Microservice.OrderService.Model.Order;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;
import java.util.UUID;

@Repository
public interface OrderRepository extends JpaRepository<Order,UUID> {
    Optional<Order> findById(UUID id);
}
