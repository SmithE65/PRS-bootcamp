using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Vendors;

public record VendorDto(
    int Id,
    string Code,
    string Name,
    string Address,
    string City,
    string State,
    string Zip,
    string? Phone,
    string? Email);


public static class VendorDtoExtensions
{
    public static VendorDto ToDto(this Vendor vendor) =>
        new(
            vendor.Id,
            vendor.Code,
            vendor.Name,
            vendor.Address,
            vendor.City,
            vendor.State,
            vendor.Zip,
            vendor.Phone,
            vendor.Email);
}