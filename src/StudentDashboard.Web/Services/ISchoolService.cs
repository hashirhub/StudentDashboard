using StudentDashboard.Web.Models;

namespace StudentDashboard.Web.Services;

public interface ISchoolService
{
    Task<ReportSummary> GetSummaryAsync();

    Task<List<Student>> GetStudentsAsync(string? search = null);
    Task<Student> SaveStudentAsync(Student student);
    Task DeleteStudentAsync(int id);

    Task<List<Course>> GetCoursesAsync(string? search = null);
    Task<Course> SaveCourseAsync(Course course);
    Task DeleteCourseAsync(int id);

    Task<List<Enrollment>> GetEnrollmentsAsync();
    Task AddEnrollmentAsync(int studentId, int courseId);

    Task<List<AttendanceRecord>> GetAttendanceAsync();
    Task AddAttendanceAsync(AttendanceRecord attendance);

    Task<List<GradeRecord>> GetGradesAsync();
    Task AddGradeAsync(GradeRecord grade);

    Task<List<AssignmentItem>> GetAssignmentsAsync();
    Task AddAssignmentAsync(AssignmentItem assignment);

    Task<List<FeeInvoice>> GetFeesAsync();
    Task AddFeeAsync(FeeInvoice invoice);
    Task MarkFeePaidAsync(int id);

    Task<List<NotificationItem>> GetNotificationsAsync();
    Task AddNotificationAsync(NotificationItem notification);
    Task MarkNotificationReadAsync(int id);

    Task<List<SupportTicket>> GetSupportTicketsAsync();
    Task AddSupportTicketAsync(SupportTicket ticket);
    Task CloseSupportTicketAsync(int id);

    Task<List<CalendarEvent>> GetEventsAsync();
    Task AddEventAsync(CalendarEvent calendarEvent);
}
