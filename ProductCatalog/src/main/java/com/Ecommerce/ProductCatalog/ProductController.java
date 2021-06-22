package com.Ecommerce.ProductCatalog;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("api/products")
public class ProductController {
    private final ProductService productService;

    @Autowired
    public ProductController(ProductService productService) {
        this.productService = productService;
    }
    @GetMapping
    public List<Product> fetchAllProducts(){
        return productService.getAllStudents();
    }

//    @PostMapping
//    public Product insertProduct(ProductCreateDTO p){
//        return productService.saveProduct(ProductMapper.getProductDTO(p));
//    }
    @PostMapping
    public List<Product> insertProduct(@RequestBody List<ProductCreateDTO> productCreateDTOList){
        return productService.saveProducts(ProductMapper.getProductDTOList(productCreateDTOList));
    }

}
