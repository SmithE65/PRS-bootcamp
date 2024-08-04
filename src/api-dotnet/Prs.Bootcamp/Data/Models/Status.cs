using System.ComponentModel.DataAnnotations;

namespace Prs.Bootcamp.Data.Models;

public class Status
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Description { get; set; } = null!;

    public void Copy(Status status)
    {
        Id = status.Id;
        Description = status.Description;
    }
}
