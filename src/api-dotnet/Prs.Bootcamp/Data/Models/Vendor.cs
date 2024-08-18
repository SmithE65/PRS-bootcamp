using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prs.Bootcamp.Data.Models;

[Index(nameof(Name), IsUnique = true)]
public class Vendor
{
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Code { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string Address { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(2)]
    public string State { get; set; } = null!;

    [Required]
    [StringLength(5)]
    public string Zip { get; set; } = null!;

    [Required]
    [StringLength(12)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(255)]
    public string? Email { get; set; }

    public void Copy(Vendor vendor)
    {
        Code = vendor.Code;
        Name = vendor.Name;
        Address = vendor.Address;
        City = vendor.City;
        State = vendor.State;
        Zip = vendor.Zip;
        Phone = vendor.Phone;
        Email = vendor.Email;
    }
}
