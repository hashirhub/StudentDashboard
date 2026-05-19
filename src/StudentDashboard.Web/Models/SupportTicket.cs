using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class SupportTicket : BaseEntity
{
    public int? StudentId { get; set; }
    public Student? Student { get; set; }

    [Required, StringLength(120)]
    public string Subject { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [StringLength(30)]
    public string Status { get; set; } = "Open";

    [StringLength(30)]
    public string Priority { get; set; } = "Medium";
}
