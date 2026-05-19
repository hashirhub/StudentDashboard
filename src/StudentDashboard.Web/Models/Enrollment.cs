using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class Enrollment : BaseEntity
{
    [Required]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [Required]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    public DateTime EnrolledOn { get; set; } = DateTime.Today;

    [StringLength(30)]
    public string Status { get; set; } = "Enrolled";
}
