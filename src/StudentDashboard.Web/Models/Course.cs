using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class Course : BaseEntity
{
    [Required, StringLength(20)]
    public string Code { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    [Range(1, 6)]
    public int CreditHours { get; set; } = 3;

    [Required, StringLength(100)]
    public string InstructorName { get; set; } = string.Empty;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<AssignmentItem> Assignments { get; set; } = new List<AssignmentItem>();

    public override string EntityLabel => $"{Code} - {Title}";
}
