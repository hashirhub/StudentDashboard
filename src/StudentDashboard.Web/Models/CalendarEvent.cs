using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class CalendarEvent : BaseEntity
{
    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    public DateTime EventDate { get; set; } = DateTime.Today;

    [Required, StringLength(100)]
    public string Location { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}
