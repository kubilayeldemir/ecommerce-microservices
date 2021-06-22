package com.Ecommerce.ProductCatalog;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface ProductRepository
        extends MongoRepository<Product,String> {
    Page<Product> findByBrandContainingIgnoreCase(String brand,Pageable pageable);

    //Page<Product> findAll(Pageable pageable);
}
