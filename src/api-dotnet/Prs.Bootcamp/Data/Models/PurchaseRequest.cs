using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prs.Bootcamp.Data.Models;

public class PurchaseRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Description { get; set; } = null!;

    [Required]
    [StringLength(80)]
    public string Justification { get; set; } = null!;

    [StringLength(80)]
    public string ReasonForRejection { get; set; } = string.Empty;

    public DateTime DateNeeded { get; set; }

    [Required]
    [StringLength(20)]
    public string DeliveryMode { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "DECIMAL(11,2)")]
    public decimal Total { get; set; }

    public DateTime SubmittedDate { get; set; }

    public int UserId { get; set; }
    public User? UserNavigation { get; set; }

    public void Copy(PurchaseRequest purchaseRequest)
    {
        Id = purchaseRequest.Id;
        UserId = purchaseRequest.UserId;
        Description = purchaseRequest.Description;
        Justification = purchaseRequest.Justification;
        DateNeeded = purchaseRequest.DateNeeded;
        DeliveryMode = purchaseRequest.DeliveryMode;
        Status = purchaseRequest.Status;
        Total = purchaseRequest.Total;
        SubmittedDate = purchaseRequest.SubmittedDate;
        ReasonForRejection = purchaseRequest.ReasonForRejection;
    }
}
