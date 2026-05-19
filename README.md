# Student Dashboard - .NET 10 Blazor Server Project

This is a Visual Studio-ready **Student Dashboard** project built with Blazor Server and .NET 10.

## Important

- Open `StudentDashboard.slnx` in Visual Studio.
- This package intentionally includes only `.slnx`.
- There is no `.sln` file.
- The project runs on HTTP only to avoid local HTTPS developer certificate errors.
- Default URL: `http://localhost:5234`

## Student-only scope

This version contains only the **Student** user flow. Non-student role workflows have been removed because the project topic is Student Dashboard.

The student can:

1. Login as student
2. View personal dashboard
3. View profile
4. Update phone/contact number
5. View enrolled courses
6. View attendance
7. View grade records
8. View assignments
9. View fee invoices
10. Pay/mark pending fee invoice as paid
11. Read notifications
12. Mark notifications as read
13. View events
14. Create support tickets
15. Track own support tickets

## Demo accounts

Use one of these seeded student emails:

- `irtaza@studentdash.local`
- `sufyan@studentdash.local`
- `hashir@studentdash.local`

## Technology

- .NET 10
- Blazor Server
- Entity Framework Core
- SQLite
- Bootstrap + custom CSS
- Three-tier pattern: UI, Services/Business Logic, Data Access
