using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prs.Bootcamp.Data.Models;

[Index(nameof(VendorId), nameof(VendorPartNumber), IsUnique = true)]
public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string VendorPartNumber { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "DECIMAL(11,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(30)]
    public string Unit { get; set; } = null!;

    [StringLength(255)]
    public string? Photopath { get; set; }

    [Required]
    public int VendorId { get; set; }
    public Vendor? VendorNavigation { get; set; }

    public void Copy(Product product)
    {
        Id = product.Id;
        VendorId = product.VendorId;
        VendorNavigation = product.VendorNavigation;
        VendorPartNumber = product.VendorPartNumber;
        Name = product.Name;
        Price = product.Price;
        Unit = product.Unit;
        Photopath = product.Photopath;
    }
}
