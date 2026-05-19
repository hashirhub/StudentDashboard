using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class AssignmentItem : BaseEntity
{
    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(7);

    [Range(1, 1000)]
    public decimal TotalMarks { get; set; } = 100;
}
