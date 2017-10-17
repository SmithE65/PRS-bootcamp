using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class PurchaseRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Justification { get; set; }

        public DateTime DateNeeded { get; set; }

        [Required]
        [StringLength(25)]
        public string DeliveryMode { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public decimal Total { get; set; }

        public DateTime SubmittedDate { get; set; }

        [StringLength(100)]
        public string ReasonForRejection { get; set; }

        public void Copy(PurchaseRequest purchaseRequest)
        {
            Id = purchaseRequest.Id;
            UserId = purchaseRequest.UserId;
            Description = purchaseRequest.Description;
            Justification = purchaseRequest.Justification;
            DateNeeded = purchaseRequest.DateNeeded;
            DeliveryMode = purchaseRequest.DeliveryMode;
            StatusId = purchaseRequest.StatusId;
            Status = purchaseRequest.Status;
            Total = purchaseRequest.Total;
            SubmittedDate = purchaseRequest.SubmittedDate;
            ReasonForRejection = purchaseRequest.ReasonForRejection;
        }
    }
}