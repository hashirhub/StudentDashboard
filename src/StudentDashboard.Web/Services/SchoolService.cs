using Microsoft.EntityFrameworkCore;
using StudentDashboard.Web.Data;
using StudentDashboard.Web.Models;

namespace StudentDashboard.Web.Services;

public class SchoolService : ISchoolService
{
    private readonly IDbContextFactory<AppDbContext> dbFactory;

    public SchoolService(IDbContextFactory<AppDbContext> dbFactory)
    {
        this.dbFactory = dbFactory;
    }

    public async Task<ReportSummary> GetSummaryAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();

        var attendanceTotal = await db.AttendanceRecords.CountAsync();
        var presentTotal = await db.AttendanceRecords.CountAsync(item => item.Status == "Present");
        var gradeRecords = await db.GradeRecords.AsNoTracking().ToListAsync();

        return new ReportSummary
        {
            TotalStudents = await db.Students.CountAsync(),
            TotalCourses = await db.Courses.CountAsync(),
            TotalEnrollments = await db.Enrollments.CountAsync(),
            AttendancePercentage = attendanceTotal == 0 ? 0 : Math.Round((decimal)presentTotal / attendanceTotal * 100, 2),
            AverageGradePercentage = gradeRecords.Count == 0 ? 0 : Math.Round(gradeRecords.Average(item => item.Percentage), 2),
            PendingFees = await db.FeeInvoices.Where(item => !item.IsPaid).SumAsync(item => item.Amount),
            OpenTickets = await db.SupportTickets.CountAsync(item => item.Status != "Closed"),
            UnreadNotifications = await db.Notifications.CountAsync(item => !item.IsRead)
        };
    }

    public async Task<List<Student>> GetStudentsAsync(string? search = null)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var query = db.Students.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToLower();
            query = query.Where(student =>
                student.FirstName.ToLower().Contains(term) ||
                student.LastName.ToLower().Contains(term) ||
                student.Email.ToLower().Contains(term) ||
                student.StudentNumber.ToLower().Contains(term) ||
                student.ProgramName.ToLower().Contains(term));
        }

        return await query.OrderBy(student => student.FirstName).ToListAsync();
    }

    public async Task<Student> SaveStudentAsync(Student student)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        if (student.Id == 0)
        {
            db.Students.Add(student);
        }
        else
        {
            db.Students.Update(student);
        }

        await db.SaveChangesAsync();
        return student;
    }

    public async Task DeleteStudentAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var student = await db.Students.FindAsync(id);
        if (student is null)
        {
            return;
        }

        db.Students.Remove(student);
        await db.SaveChangesAsync();
    }

    public async Task<List<Course>> GetCoursesAsync(string? search = null)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var query = db.Courses.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToLower();
            query = query.Where(course =>
                course.Code.ToLower().Contains(term) ||
                course.Title.ToLower().Contains(term) ||
                course.InstructorName.ToLower().Contains(term));
        }

        return await query.OrderBy(course => course.Code).ToListAsync();
    }

    public async Task<Course> SaveCourseAsync(Course course)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        if (course.Id == 0)
        {
            db.Courses.Add(course);
        }
        else
        {
            db.Courses.Update(course);
        }

        await db.SaveChangesAsync();
        return course;
    }

    public async Task DeleteCourseAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var course = await db.Courses.FindAsync(id);
        if (course is null)
        {
            return;
        }

        db.Courses.Remove(course);
        await db.SaveChangesAsync();
    }

    public async Task<List<Enrollment>> GetEnrollmentsAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Enrollments.AsNoTracking()
            .Include(item => item.Student)
            .Include(item => item.Course)
            .OrderByDescending(item => item.EnrolledOn)
            .ToListAsync();
    }

    public async Task AddEnrollmentAsync(int studentId, int courseId)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var exists = await db.Enrollments.AnyAsync(item => item.StudentId == studentId && item.CourseId == courseId);
        if (exists)
        {
            return;
        }

        db.Enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId });
        await db.SaveChangesAsync();
    }

    public async Task<List<AttendanceRecord>> GetAttendanceAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.AttendanceRecords.AsNoTracking()
            .Include(item => item.Student)
            .Include(item => item.Course)
            .OrderByDescending(item => item.AttendanceDate)
            .ToListAsync();
    }

    public async Task AddAttendanceAsync(AttendanceRecord attendance)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.AttendanceRecords.Add(attendance);
        await db.SaveChangesAsync();
    }

    public async Task<List<GradeRecord>> GetGradesAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.GradeRecords.AsNoTracking()
            .Include(item => item.Student)
            .Include(item => item.Course)
            .OrderByDescending(item => item.Id)
            .ToListAsync();
    }

    public async Task AddGradeAsync(GradeRecord grade)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.GradeRecords.Add(grade);
        await db.SaveChangesAsync();
    }

    public async Task<List<AssignmentItem>> GetAssignmentsAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Assignments.AsNoTracking()
            .Include(item => item.Course)
            .OrderBy(item => item.DueDate)
            .ToListAsync();
    }

    public async Task AddAssignmentAsync(AssignmentItem assignment)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.Assignments.Add(assignment);
        await db.SaveChangesAsync();
    }

    public async Task<List<FeeInvoice>> GetFeesAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.FeeInvoices.AsNoTracking()
            .Include(item => item.Student)
            .OrderBy(item => item.DueDate)
            .ToListAsync();
    }

    public async Task AddFeeAsync(FeeInvoice invoice)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.FeeInvoices.Add(invoice);
        await db.SaveChangesAsync();
    }

    public async Task MarkFeePaidAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var invoice = await db.FeeInvoices.FindAsync(id);
        if (invoice is null)
        {
            return;
        }

        invoice.IsPaid = true;
        await db.SaveChangesAsync();
    }

    public async Task<List<NotificationItem>> GetNotificationsAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Notifications.AsNoTracking().OrderByDescending(item => item.Id).ToListAsync();
    }

    public async Task AddNotificationAsync(NotificationItem notification)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.Notifications.Add(notification);
        await db.SaveChangesAsync();
    }

    public async Task MarkNotificationReadAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var notification = await db.Notifications.FindAsync(id);
        if (notification is null)
        {
            return;
        }

        notification.IsRead = true;
        await db.SaveChangesAsync();
    }

    public async Task<List<SupportTicket>> GetSupportTicketsAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.SupportTickets.AsNoTracking()
            .Include(item => item.Student)
            .OrderByDescending(item => item.Id)
            .ToListAsync();
    }

    public async Task AddSupportTicketAsync(SupportTicket ticket)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.SupportTickets.Add(ticket);
        await db.SaveChangesAsync();
    }

    public async Task CloseSupportTicketAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var ticket = await db.SupportTickets.FindAsync(id);
        if (ticket is null)
        {
            return;
        }

        ticket.Status = "Closed";
        await db.SaveChangesAsync();
    }

    public async Task<List<CalendarEvent>> GetEventsAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.CalendarEvents.AsNoTracking().OrderBy(item => item.EventDate).ToListAsync();
    }

    public async Task AddEventAsync(CalendarEvent calendarEvent)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.CalendarEvents.Add(calendarEvent);
        await db.SaveChangesAsync();
    }
}
