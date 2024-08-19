using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Vendors;

[Route("api/[controller]")]
[ApiController]
public class VendorsController(PrsDbContext context) : ControllerBase
{
    private readonly PrsDbContext _context = context;

    // GET: api/Vendors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendorDto>>> GetVendors(
        [FromServices] IQueryHandler<GetVendorsQuery, IEnumerable<VendorDto>> getVendorsQueryHandler)
    {
        var query = new GetVendorsQuery();
        var vendors = await getVendorsQueryHandler.HandleAsync(query);

        return Ok(vendors);
    }

    // GET: api/Vendors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VendorDto>> GetVendor(
        [FromServices] IQueryHandler<GetVendorQuery, VendorDto?> getVendorQueryHandler,
        int id)
    {
        var query = new GetVendorQuery(id);
        var vendor = await getVendorQueryHandler.HandleAsync(query);

        return vendor == null ? NotFound() : vendor;
    }

    // PUT: api/Vendors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVendor(int id, Vendor vendor)
    {
        if (id != vendor.Id)
        {
            return BadRequest();
        }

        _context.Entry(vendor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Vendors
    [HttpPost]
    public async Task<ActionResult<Vendor>> PostVendor(CreateVendorDto dto)
    {
        var vendor = new Vendor
        {
            Code = dto.Code,
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            State = dto.State,
            Zip = dto.Zip,
            Phone = dto.Phone,
            Email = dto.Email
        };

        _ = _context.Vendors.Add(vendor);
        _ = await _context.SaveChangesAsync();

        return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
    }

    // DELETE: api/Vendors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendor(int id)
    {
        var vendor = await _context.Vendors.FindAsync(id);

        if (vendor != null)
        {
            _ = _context.Vendors.Remove(vendor);
            _ = await _context.SaveChangesAsync();
        }

        return NoContent();
    }

    private bool VendorExists(int id)
    {
        return _context.Vendors.Any(e => e.Id == id);
    }
}
