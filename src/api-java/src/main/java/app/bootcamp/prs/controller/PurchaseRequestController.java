package app.bootcamp.prs.controller;

import app.bootcamp.prs.dto.PurchaseRequestDto;
import app.bootcamp.prs.model.PurchaseRequest;
import app.bootcamp.prs.repository.PurchaseRequestRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/PurchaseRequests")
public class PurchaseRequestController {

    private final PurchaseRequestRepository purchaseRequestRepository;

    public PurchaseRequestController(PurchaseRequestRepository purchaseRequestRepository) {
        this.purchaseRequestRepository = purchaseRequestRepository;
    }

    @GetMapping
    public List<PurchaseRequestDto> getAllPurchaseRequests() {
        return purchaseRequestRepository.findAll().stream().map(this::convertToDto).collect(Collectors.toList());
    }

    @PostMapping
    public ResponseEntity<PurchaseRequestDto> createPurchaseRequest(
            @RequestBody PurchaseRequestDto purchaseRequestDto) {
        PurchaseRequest purchaseRequest = convertToEntity(purchaseRequestDto);
        PurchaseRequest savedPurchaseRequest = purchaseRequestRepository.save(purchaseRequest);
        return ResponseEntity.ok(convertToDto(savedPurchaseRequest));
    }

    @GetMapping("/{id}")
    public ResponseEntity<PurchaseRequestDto> getPurchaseRequestById(@PathVariable Integer id) {
        return purchaseRequestRepository.findById(id)
                .map(purchaseRequest -> ResponseEntity.ok(convertToDto(purchaseRequest)))
                .orElse(ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<PurchaseRequestDto> updatePurchaseRequest(@PathVariable Integer id,
            @RequestBody PurchaseRequestDto purchaseRequestDto) {
        return purchaseRequestRepository.findById(id)
                .map(existingPurchaseRequest -> {
                    PurchaseRequest updatedPurchaseRequest = convertToEntity(purchaseRequestDto);
                    updatedPurchaseRequest.setId(existingPurchaseRequest.getId());
                    purchaseRequestRepository.save(updatedPurchaseRequest);
                    return ResponseEntity.ok(convertToDto(updatedPurchaseRequest));
                })
                .orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deletePurchaseRequest(@PathVariable Integer id) {
        if (purchaseRequestRepository.existsById(id)) {
            purchaseRequestRepository.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    private PurchaseRequestDto convertToDto(PurchaseRequest purchaseRequest) {
        PurchaseRequestDto dto = new PurchaseRequestDto();
        dto.setId(purchaseRequest.getId());
        dto.setDescription(purchaseRequest.getDescription());
        dto.setJustification(purchaseRequest.getJustification());
        dto.setReasonForRejection(purchaseRequest.getReasonForRejection());
        dto.setDateNeeded(purchaseRequest.getDateNeeded());
        dto.setDeliveryMode(purchaseRequest.getDeliveryMode());
        dto.setStatus(purchaseRequest.getStatus());
        dto.setTotal(purchaseRequest.getTotal());
        dto.setSubmittedDate(purchaseRequest.getSubmittedDate());
        dto.setUserId(purchaseRequest.getUser().getId());
        // Line items conversion can be added here
        return dto;
    }

    private PurchaseRequest convertToEntity(PurchaseRequestDto dto) {
        PurchaseRequest purchaseRequest = new PurchaseRequest();
        purchaseRequest.setDescription(dto.getDescription());
        purchaseRequest.setJustification(dto.getJustification());
        purchaseRequest.setReasonForRejection(dto.getReasonForRejection());
        purchaseRequest.setDateNeeded(dto.getDateNeeded());
        purchaseRequest.setDeliveryMode(dto.getDeliveryMode());
        purchaseRequest.setStatus(dto.getStatus());
        purchaseRequest.setTotal(dto.getTotal());
        purchaseRequest.setSubmittedDate(dto.getSubmittedDate());
        // User association should be handled here
        return purchaseRequest;
    }
}