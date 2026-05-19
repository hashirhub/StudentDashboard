# UML Explanation

The application uses a student-centered domain model. `BaseEntity` provides shared entity fields such as `Id`, `CreatedAt`, and display labeling. `Person` is an abstract base class for person-like records and `Student` derives from it to add student-specific fields such as student number, program, semester, and status.

`Student` has collection relationships with enrollments, attendance records, grade records, fee invoices, and support tickets. `Course` connects to `Student` through `Enrollment`, while assignments belong to courses. Notifications and calendar events are independent entities that are shown to the student dashboard.

The design keeps responsibilities separated: Blazor pages handle UI, `SchoolService` handles business logic, and `AppDbContext` handles data access through Entity Framework Core.
