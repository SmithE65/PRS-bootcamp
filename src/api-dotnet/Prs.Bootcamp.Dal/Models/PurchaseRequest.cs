using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prs.Bootcamp.Dal.Models;

public class PurchaseRequest
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? UserNavigation { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string Justification { get; set; } = null!;

    public DateTime DateNeeded { get; set; }

    [Required]
    [StringLength(25)]
    public string DeliveryMode { get; set; } = null!;

    public int StatusId { get; set; }
    public Status? StatusNavigation { get; set; }

    [Column(TypeName = "DECIMAL(19,4)")]
    public decimal Total { get; set; }

    public DateTime SubmittedDate { get; set; }

    [StringLength(100)]
    public string ReasonForRejection { get; set; } = string.Empty;

    public void Copy(PurchaseRequest purchaseRequest)
    {
        Id = purchaseRequest.Id;
        UserId = purchaseRequest.UserId;
        Description = purchaseRequest.Description;
        Justification = purchaseRequest.Justification;
        DateNeeded = purchaseRequest.DateNeeded;
        DeliveryMode = purchaseRequest.DeliveryMode;
        StatusId = purchaseRequest.StatusId;
        Total = purchaseRequest.Total;
        SubmittedDate = purchaseRequest.SubmittedDate;
        ReasonForRejection = purchaseRequest.ReasonForRejection;
    }
}
