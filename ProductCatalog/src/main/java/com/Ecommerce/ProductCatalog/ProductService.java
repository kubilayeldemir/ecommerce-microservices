package com.Ecommerce.ProductCatalog;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductService {
    @Autowired
    private final ProductRepository productRepository;

    public ProductService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public List<Product> getAllStudents(){
        return productRepository.findAll();
    }

    public Product saveProduct(Product p){
        return productRepository.save(p);
    }
    public List<Product> saveProducts(List<Product> productLists){
        return productRepository.saveAll(productLists);
    }
}
