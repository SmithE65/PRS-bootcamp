using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        public int UpdatedByUser { get; set; }
        public User User { get; set; }
    }
}