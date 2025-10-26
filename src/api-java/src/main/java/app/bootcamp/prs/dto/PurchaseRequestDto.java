package app.bootcamp.prs.dto;

import java.math.BigDecimal;
import java.time.ZonedDateTime;
import java.util.List;

import app.bootcamp.prs.model.RequestStatus;

public class PurchaseRequestDto {
    private Integer id;
    private String description;
    private String justification;
    private String reasonForRejection;
    private ZonedDateTime dateNeeded;
    private String deliveryMode;
    private RequestStatus status;
    private BigDecimal total;
    private ZonedDateTime submittedDate;
    private Integer userId;
    private List<PurchaseRequestLineItemDto> lineItems;

    // Getters and Setters
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getJustification() {
        return justification;
    }

    public void setJustification(String justification) {
        this.justification = justification;
    }

    public String getReasonForRejection() {
        return reasonForRejection;
    }

    public void setReasonForRejection(String reasonForRejection) {
        this.reasonForRejection = reasonForRejection;
    }

    public ZonedDateTime getDateNeeded() {
        return dateNeeded;
    }

    public void setDateNeeded(ZonedDateTime dateNeeded) {
        this.dateNeeded = dateNeeded;
    }

    public String getDeliveryMode() {
        return deliveryMode;
    }

    public void setDeliveryMode(String deliveryMode) {
        this.deliveryMode = deliveryMode;
    }

    public RequestStatus getStatus() {
        return status;
    }

    public void setStatus(RequestStatus status) {
        this.status = status;
    }

    public BigDecimal getTotal() {
        return total;
    }

    public void setTotal(BigDecimal total) {
        this.total = total;
    }

    public ZonedDateTime getSubmittedDate() {
        return submittedDate;
    }

    public void setSubmittedDate(ZonedDateTime submittedDate) {
        this.submittedDate = submittedDate;
    }

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
    }

    public List<PurchaseRequestLineItemDto> getLineItems() {
        return lineItems;
    }

    public void setLineItems(List<PurchaseRequestLineItemDto> lineItems) {
        this.lineItems = lineItems;
    }
}