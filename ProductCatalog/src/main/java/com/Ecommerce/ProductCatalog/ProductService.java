package com.Ecommerce.ProductCatalog;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Service
public class ProductService {
    @Autowired
    private final ProductRepository productRepository;

    public ProductService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public List<Product> getAllProducts(){
        return productRepository.findAll();
    }

    public Map<String, Object> getProductsByBrandPaged(String brand,int page, int size){
        if(size>50){
            size=50;
        }
        List<Product> products = new ArrayList<Product>();
        Pageable paging = PageRequest.of(page, size);

        Page<Product> pageProducts;
        if (brand == null)
            pageProducts = findAll(paging);
        else
            pageProducts = productRepository.findByBrandContainingIgnoreCase(brand, paging);

        products = pageProducts.getContent();

        Map<String, Object> response = new HashMap<>();
        response.put("products", products);
        response.put("currentPage", pageProducts.getNumber());
        response.put("totalItems", pageProducts.getTotalElements());
        response.put("totalPages", pageProducts.getTotalPages());

        return response;
    }

    public Product saveProduct(Product p){
        return productRepository.save(p);
    }
    public List<Product> saveProducts(List<Product> productLists){
        return productRepository.saveAll(productLists);
    }

    public Page<Product> findAll(Pageable paging) {
        return productRepository.findAll(paging);
    }
}
