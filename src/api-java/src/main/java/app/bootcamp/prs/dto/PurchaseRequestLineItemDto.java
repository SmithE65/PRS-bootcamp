package app.bootcamp.prs.dto;

public class PurchaseRequestLineItemDto {
    private Integer id;
    private Integer purchaseRequestId;
    private Integer productId;
    private Integer quantity;

    // Getters and Setters
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getPurchaseRequestId() {
        return purchaseRequestId;
    }

    public void setPurchaseRequestId(Integer purchaseRequestId) {
        this.purchaseRequestId = purchaseRequestId;
    }

    public Integer getProductId() {
        return productId;
    }

    public void setProductId(Integer productId) {
        this.productId = productId;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }
}