using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Index(name: "IX_VendorPartNumber", Order = 1, IsUnique = true)]
        public int VendorId { get; set; }

        [Required]
        public virtual Vendor Vendor { get; set; }

        [Required]
        [StringLength(50)]
        [Index(name: "IX_VendorPartNumber", Order = 2, IsUnique = true)]
        public string VendorPartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Photopath { get; set; }
    }
}