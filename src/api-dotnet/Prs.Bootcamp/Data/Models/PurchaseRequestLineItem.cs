using System.ComponentModel.DataAnnotations;

namespace Prs.Bootcamp.Data.Models;

public class PurchaseRequestLineItem
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int PurchaseRequestId { get; set; }
    public PurchaseRequest? PurchaseRequestNavigation { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product? ProductNavigation { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public bool IsFulfilled { get; set; }

    public void Copy(PurchaseRequestLineItem lineItem)
    {
        Id = lineItem.Id;
        PurchaseRequestId = lineItem.PurchaseRequestId;
        ProductId = lineItem.ProductId;
        Quantity = lineItem.Quantity;
        IsFulfilled = lineItem.IsFulfilled;
    }
}
