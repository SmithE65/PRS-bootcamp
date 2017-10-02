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
        public User User { get; set; }

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
        public Status Status { get; set; }

        public decimal Total { get; set; }

        public DateTime SubmittedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string ReasonForRejection { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        public int UpdatedByUser { get; set; }
    }
}