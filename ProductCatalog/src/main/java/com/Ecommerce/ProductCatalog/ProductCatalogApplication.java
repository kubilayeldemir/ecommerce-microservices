package com.Ecommerce.ProductCatalog;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.core.env.Environment;

import java.util.Properties;

@SpringBootApplication
public class ProductCatalogApplication {

	public static void main(String[] args) {
		//System.out.println(System.getenv("selam"));
		SpringApplication.run(ProductCatalogApplication.class, args);
	}

}
