package com.Ecommerce.ProductCatalog.Repository;

import com.Ecommerce.ProductCatalog.Model.Product;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;
import java.util.Optional;

public interface ProductRepository
        extends MongoRepository<Product,String> {
    Page<Product> findByBrandContainingIgnoreCase(String brand,Pageable pageable);
    Optional<Product> findById(String id);
    List<Product> findByIdIn(List<String> productIds);

    //Page<Product> findAll(Pageable pageable);
}
