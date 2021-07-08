package com.Ecommerce.ProductCatalog.Controller;

import com.Ecommerce.ProductCatalog.Model.Product;
import com.Ecommerce.ProductCatalog.Model.ProductCreateDTO;
import com.Ecommerce.ProductCatalog.Model.Mapper.ProductMapper;
import com.Ecommerce.ProductCatalog.Service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.*;

@RestController
@RequestMapping("api/products")
public class ProductController {
    private final ProductService productService;

    @Autowired
    public ProductController(ProductService productService) {
        this.productService = productService;
    }

    public List<Product> fetchAllProducts(){
        return productService.getAllProducts();
    }

    public Product insertProduct(ProductCreateDTO p){
        return productService.saveProduct(ProductMapper.getProductDTO(p));
    }

    @PostMapping
    public List<Product> insertProduct(@RequestBody List<ProductCreateDTO> productCreateDTOList){
        System.out.println("Post list Products Size:"+productCreateDTOList.size()+"-----"+ System.currentTimeMillis() );
        return productService.saveProducts(ProductMapper.getProductDTOList(productCreateDTOList));
    }
    @GetMapping
    public ResponseEntity<Map<String, Object>> fetchAllProductsPaged(
            @RequestParam(required = false) String brand,
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "3") int size
    ){
        try {
            var response = productService.getProductsByBrandPaged(brand,page,size);
            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    @GetMapping("/{productId}")
    public Product getProductById(@PathVariable String productId){
        return  productService.getProductById(productId);
    }
    @GetMapping("/list/{productIds}")
    public List<Product> getProducstByIds(@PathVariable List<String> productIds){
        return  productService.getProductsByListOfIds(productIds);
    }

}
