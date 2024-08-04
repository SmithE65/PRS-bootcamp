using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prs.Bootcamp.Data.Models;

[Index(nameof(UserName), IsUnique = true)]
public class User
{
    public int Id { get; set; }

    [StringLength(20)]
    [Required]
    public string UserName { get; set; } = null!;

    [StringLength(10)]
    [Required]
    public string Password { get; set; } = null!;

    [StringLength(20)]
    [Required]
    public string FirstName { get; set; } = null!;

    [StringLength(20)]
    [Required]
    public string LastName { get; set; } = null!;

    [StringLength(12)]
    [Required]
    public string Phone { get; set; } = null!;

    [StringLength(75)]
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public bool IsAdmin { get; set; }

    [Required]
    public bool IsReviewer { get; set; }

    public void Copy(User user)
    {
        Id = user.Id;
        UserName = user.UserName;
        Password = user.Password;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Phone = user.Phone;
        Email = user.Email;
        IsAdmin = user.IsAdmin;
        IsReviewer = user.IsReviewer;
    }
}
