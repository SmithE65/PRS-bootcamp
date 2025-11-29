package app.bootcamp.prs.controller;

import app.bootcamp.prs.dto.ProductDto;
import app.bootcamp.prs.model.Product;
import app.bootcamp.prs.repository.ProductRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    private final ProductRepository productRepository;

    public ProductController(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @GetMapping
    public List<ProductDto> getAllProducts() {
        return productRepository.findAll().stream().map(this::convertToDto).collect(Collectors.toList());
    }

    @PostMapping
    public ResponseEntity<ProductDto> createProduct(@RequestBody ProductDto productDto) {
        Product product = convertToEntity(productDto);
        Product savedProduct = productRepository.save(product);
        return ResponseEntity.ok(convertToDto(savedProduct));
    }

    @GetMapping("/{id}")
    public ResponseEntity<ProductDto> getProductById(@PathVariable Integer id) {
        return productRepository.findById(id)
                .map(product -> ResponseEntity.ok(convertToDto(product)))
                .orElse(ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<ProductDto> updateProduct(@PathVariable Integer id, @RequestBody ProductDto productDto) {
        return productRepository.findById(id)
                .map(existingProduct -> {
                    Product updatedProduct = convertToEntity(productDto);
                    updatedProduct.setId(existingProduct.getId());
                    productRepository.save(updatedProduct);
                    return ResponseEntity.ok(convertToDto(updatedProduct));
                })
                .orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteProduct(@PathVariable Integer id) {
        if (productRepository.existsById(id)) {
            productRepository.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    private ProductDto convertToDto(Product product) {
        ProductDto dto = new ProductDto();
        dto.setId(product.getId());
        dto.setVendorPartNumber(product.getVendorPartNumber());
        dto.setName(product.getName());
        dto.setPrice(product.getPrice());
        dto.setUnit(product.getUnit());
        dto.setPhotopath(product.getPhotoPath());
        dto.setVendorId(product.getVendor().getId());
        return dto;
    }

    private Product convertToEntity(ProductDto dto) {
        Product product = new Product();
        product.setVendorPartNumber(dto.getVendorPartNumber());
        product.setName(dto.getName());
        product.setPrice(dto.getPrice());
        product.setUnit(dto.getUnit());
        product.setPhotoPath(dto.getPhotopath());
        // Vendor association should be handled here
        return product;
    }
}