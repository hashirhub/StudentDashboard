namespace StudentDashboard.Web.Models;

public class ReportSummary
{
    public int TotalStudents { get; set; }
    public int TotalCourses { get; set; }
    public int TotalEnrollments { get; set; }
    public decimal AttendancePercentage { get; set; }
    public decimal AverageGradePercentage { get; set; }
    public decimal PendingFees { get; set; }
    public int OpenTickets { get; set; }
    public int UnreadNotifications { get; set; }
}
