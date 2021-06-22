package com.Ecommerce.ProductCatalog;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.core.env.Environment;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

import java.util.Properties;

@SpringBootApplication
@EnableSwagger2
public class ProductCatalogApplication {

	public static void main(String[] args) {
		//System.out.println(System.getenv("selam"));
		SpringApplication.run(ProductCatalogApplication.class, args);
	}

}
