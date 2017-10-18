using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class PurchaseRequestLineItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

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
        }
    }
}