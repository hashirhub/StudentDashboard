using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Web.Models;

public class Student : Person
{
    [Required, StringLength(30)]
    public string StudentNumber { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string ProgramName { get; set; } = string.Empty;

    [Range(1, 12)]
    public int Semester { get; set; } = 1;

    [StringLength(30)]
    public string Status { get; set; } = "Active";

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    public ICollection<GradeRecord> GradeRecords { get; set; } = new List<GradeRecord>();
    public ICollection<FeeInvoice> FeeInvoices { get; set; } = new List<FeeInvoice>();

    public override string GetFullName() => $"{FirstName} {LastName} ({StudentNumber})".Trim();
}
