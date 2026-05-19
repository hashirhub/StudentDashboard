using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public abstract class Person : BaseEntity
{
    [Required, StringLength(80)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Phone, StringLength(30)]
    public string Phone { get; set; } = string.Empty;

    public virtual string GetFullName() => $"{FirstName} {LastName}".Trim();

    public override string EntityLabel => GetFullName();
}
