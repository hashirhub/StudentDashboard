using Microsoft.EntityFrameworkCore;
using StudentDashboard.Web.Models;

namespace StudentDashboard.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    public DbSet<GradeRecord> GradeRecords => Set<GradeRecord>();
    public DbSet<AssignmentItem> Assignments => Set<AssignmentItem>();
    public DbSet<FeeInvoice> FeeInvoices => Set<FeeInvoice>();
    public DbSet<NotificationItem> Notifications => Set<NotificationItem>();
    public DbSet<SupportTicket> SupportTickets => Set<SupportTicket>();
    public DbSet<CalendarEvent> CalendarEvents => Set<CalendarEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasIndex(student => student.StudentNumber)
            .IsUnique();

        modelBuilder.Entity<Course>()
            .HasIndex(course => course.Code)
            .IsUnique();

        modelBuilder.Entity<Enrollment>()
            .HasIndex(enrollment => new { enrollment.StudentId, enrollment.CourseId })
            .IsUnique();

        modelBuilder.Entity<Enrollment>()
            .HasOne(enrollment => enrollment.Student)
            .WithMany(student => student.Enrollments)
            .HasForeignKey(enrollment => enrollment.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Enrollment>()
            .HasOne(enrollment => enrollment.Course)
            .WithMany(course => course.Enrollments)
            .HasForeignKey(enrollment => enrollment.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AttendanceRecord>()
            .HasOne(attendance => attendance.Student)
            .WithMany(student => student.AttendanceRecords)
            .HasForeignKey(attendance => attendance.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GradeRecord>()
            .HasOne(grade => grade.Student)
            .WithMany(student => student.GradeRecords)
            .HasForeignKey(grade => grade.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FeeInvoice>()
            .HasOne(invoice => invoice.Student)
            .WithMany(student => student.FeeInvoices)
            .HasForeignKey(invoice => invoice.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssignmentItem>()
            .HasOne(assignment => assignment.Course)
            .WithMany(course => course.Assignments)
            .HasForeignKey(assignment => assignment.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
