using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class NotificationItem : BaseEntity
{
    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(800)]
    public string Message { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string Audience { get; set; } = "All";

    public bool IsRead { get; set; }
}
