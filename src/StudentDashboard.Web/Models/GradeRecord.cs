using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class GradeRecord : BaseEntity
{
    [Required]
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    [Required, StringLength(50)]
    public string ExamType { get; set; } = "Quiz";

    [Range(0, 1000)]
    public decimal MarksObtained { get; set; }

    [Range(1, 1000)]
    public decimal TotalMarks { get; set; } = 100;

    public decimal Percentage => TotalMarks == 0 ? 0 : Math.Round((MarksObtained / TotalMarks) * 100, 2);
}
