using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        [Required]
        public Vendor Vendor { get; set; }

        [Required]
        [StringLength(50)]
        public string VendorPartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Required]
        [StringLength(50)]
        public string Photopath { get; set; }
    }
}