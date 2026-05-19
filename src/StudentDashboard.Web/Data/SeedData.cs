using StudentDashboard.Web.Models;

namespace StudentDashboard.Web.Data;

public static class SeedData
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Students.Any())
        {
            return;
        }

        var students = new List<Student>
        {
            new() { FirstName = "Irtaza", LastName = "Shahid", Email = "irtaza@studentdash.local", Phone = "03000000001", StudentNumber = "STD-001", ProgramName = "BS Software Engineering", Semester = 4, Status = "Active" },
            new() { FirstName = "Sufyan", LastName = "Amjad", Email = "sufyan@studentdash.local", Phone = "03000000002", StudentNumber = "STD-002", ProgramName = "BS Computer Science", Semester = 5, Status = "Active" },
            new() { FirstName = "Hashir", LastName = "Hassan", Email = "hashir@studentdash.local", Phone = "03000000003", StudentNumber = "STD-003", ProgramName = "BS Information Technology", Semester = 3, Status = "Active" }
        };

        var courses = new List<Course>
        {
            new() { Code = "VP-401", Title = "Visual Programming", CreditHours = 3, InstructorName = "Mr. Naveed" },
            new() { Code = "DB-302", Title = "Database Systems", CreditHours = 3, InstructorName = "Ms. Hina" },
            new() { Code = "SE-410", Title = "Software Engineering", CreditHours = 3, InstructorName = "Dr. Kamran" }
        };

        db.Students.AddRange(students);
        db.Courses.AddRange(courses);
        await db.SaveChangesAsync();

        db.Enrollments.AddRange(
            new Enrollment { StudentId = students[0].Id, CourseId = courses[0].Id },
            new Enrollment { StudentId = students[1].Id, CourseId = courses[0].Id },
            new Enrollment { StudentId = students[2].Id, CourseId = courses[1].Id });

        db.AttendanceRecords.AddRange(
            new AttendanceRecord { StudentId = students[0].Id, CourseId = courses[0].Id, Status = "Present", AttendanceDate = DateTime.Today.AddDays(-1) },
            new AttendanceRecord { StudentId = students[1].Id, CourseId = courses[0].Id, Status = "Absent", AttendanceDate = DateTime.Today.AddDays(-1), Remarks = "Medical leave" },
            new AttendanceRecord { StudentId = students[2].Id, CourseId = courses[1].Id, Status = "Present", AttendanceDate = DateTime.Today.AddDays(-1) });

        db.GradeRecords.AddRange(
            new GradeRecord { StudentId = students[0].Id, CourseId = courses[0].Id, ExamType = "Quiz", MarksObtained = 18, TotalMarks = 20 },
            new GradeRecord { StudentId = students[1].Id, CourseId = courses[0].Id, ExamType = "Assignment", MarksObtained = 42, TotalMarks = 50 },
            new GradeRecord { StudentId = students[2].Id, CourseId = courses[1].Id, ExamType = "Midterm", MarksObtained = 74, TotalMarks = 100 });

        db.Assignments.AddRange(
            new AssignmentItem { CourseId = courses[0].Id, Title = "Blazor CRUD Task", Description = "Create a reusable CRUD component.", TotalMarks = 50 },
            new AssignmentItem { CourseId = courses[1].Id, Title = "ERD Design", Description = "Design a normalized database schema.", TotalMarks = 30 });

        db.FeeInvoices.AddRange(
            new FeeInvoice { StudentId = students[0].Id, Amount = 45000, DueDate = DateTime.Today.AddDays(10), IsPaid = false },
            new FeeInvoice { StudentId = students[1].Id, Amount = 45000, DueDate = DateTime.Today.AddDays(5), IsPaid = true },
            new FeeInvoice { StudentId = students[2].Id, Amount = 42000, DueDate = DateTime.Today.AddDays(12), IsPaid = false });

        db.Notifications.AddRange(
            new NotificationItem { Title = "Semester Registration", Message = "Registration is open for the next semester.", Audience = "All" },
            new NotificationItem { Title = "Fee Reminder", Message = "Please clear pending dues before the deadline.", Audience = "Students" });

        db.CalendarEvents.AddRange(
            new CalendarEvent { Title = "Project Viva", EventDate = DateTime.Today.AddDays(7), Location = "Lab 2", Description = "Final viva and Q&A." },
            new CalendarEvent { Title = "Sports Day", EventDate = DateTime.Today.AddDays(14), Location = "Main Ground", Description = "Annual sports activities." });

        db.SupportTickets.Add(new SupportTicket { StudentId = students[0].Id, Subject = "Portal password issue", Description = "Student cannot reset the portal password.", Priority = "High" });

        await db.SaveChangesAsync();
    }
}
