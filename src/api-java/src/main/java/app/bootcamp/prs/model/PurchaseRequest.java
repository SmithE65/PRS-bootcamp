package app.bootcamp.prs.model;

import jakarta.persistence.*;
import java.math.BigDecimal;
import java.time.ZonedDateTime;
import java.util.List;

@Entity
@Table(name = "purchase_request")
public class PurchaseRequest {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "description", nullable = false)
    private String description;

    @Column(name = "justification", nullable = false)
    private String justification;

    @Column(name = "reason_for_rejection")
    private String reasonForRejection;

    @Column(name = "date_needed", nullable = false)
    private ZonedDateTime dateNeeded;

    @Column(name = "delivery_mode", nullable = false)
    private String deliveryMode;

    @ManyToOne
    @JoinColumn(name = "status_id", nullable = false)
    private RequestStatus status;

    @Column(name = "total", nullable = false)
    private BigDecimal total;

    @Column(name = "submitted_date", nullable = false)
    private ZonedDateTime submittedDate;

    @ManyToOne
    @JoinColumn(name = "user_id", nullable = false)
    private AppUser user;

    @OneToMany(mappedBy = "purchaseRequest", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<PurchaseRequestLineItem> lineItems;

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

    public AppUser getUser() {
        return user;
    }

    public void setUser(AppUser user) {
        this.user = user;
    }

    public List<PurchaseRequestLineItem> getLineItems() {
        return lineItems;
    }

    public void setLineItems(List<PurchaseRequestLineItem> lineItems) {
        this.lineItems = lineItems;
    }
}