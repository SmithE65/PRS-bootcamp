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

        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Required]
        [StringLength(50)]
        [Index(name: "IX_VendorPartNumber", Order = 2, IsUnique = true)]
        public string VendorPartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Photopath { get; set; }

        public void Copy(Product product)
        {
            Id = product.Id;
            VendorId = product.VendorId;
            Vendor = product.Vendor;
            VendorPartNumber = product.VendorPartNumber;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Unit = product.Unit;
            Photopath = product.Photopath;
        }
    }
}