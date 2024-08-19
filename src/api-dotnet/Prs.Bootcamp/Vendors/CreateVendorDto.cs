namespace Prs.Bootcamp.Vendors;

public record CreateVendorDto(
    string Code,
    string Name,
    string Address,
    string City,
    string State,
    string Zip,
    string? Phone,
    string? Email
);
