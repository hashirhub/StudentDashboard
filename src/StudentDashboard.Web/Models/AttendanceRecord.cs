using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class AttendanceRecord : BaseEntity
{
    [Required]
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public DateTime AttendanceDate { get; set; } = DateTime.Today;

    [Required, StringLength(20)]
    public string Status { get; set; } = "Present";

    [StringLength(250)]
    public string Remarks { get; set; } = string.Empty;
}
