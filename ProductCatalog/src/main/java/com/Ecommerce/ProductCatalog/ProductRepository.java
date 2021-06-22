package com.Ecommerce.ProductCatalog;

import org.springframework.data.mongodb.repository.MongoRepository;

public interface ProductRepository
        extends MongoRepository<Product,String> {

}
