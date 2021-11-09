using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prs.Bootcamp.Dal.Models;

[Index(nameof(VendorId), nameof(VendorPartNumber), IsUnique = true)]
public class Product
{
    public int Id { get; set; }

    [Required]
    public int VendorId { get; set; }
    public Vendor? VendorNavigation { get; set; }

    [Required]
    [StringLength(50)]
    public string VendorPartNumber { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "DECIMAL(19,4)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(50)]
    public string Unit { get; set; } = null!;

    [StringLength(50)]
    public string Photopath { get; set; } = null!;

    public void Copy(Product product)
    {
        Id = product.Id;
        VendorId = product.VendorId;
        VendorNavigation = product.VendorNavigation;
        VendorPartNumber = product.VendorPartNumber;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Unit = product.Unit;
        Photopath = product.Photopath;
    }
}
