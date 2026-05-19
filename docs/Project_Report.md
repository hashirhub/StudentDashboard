# Student Dashboard Project Report

## Project Overview

The Student Dashboard is a Blazor Server web application focused on the student user. It allows a student to login and manage personal academic information including courses, attendance, grades, assignments, fees, notifications, events and support tickets.

## Architecture

The application follows a three-tier architecture:

1. UI Layer: Blazor components and pages
2. Business Logic Layer: School service and dashboard state services
3. Data Access Layer: Entity Framework Core with SQLite database

## Student User Scope

Only the student role is included in this version. The dashboard is designed around student tasks instead of staff management tasks.

## Main Modules

- Login
- Dashboard overview
- Profile
- Courses
- Attendance
- Grades
- Assignments
- Fees
- Notifications
- Events
- Support

## Design

The UI uses a clean sidebar layout, responsive cards, tables, forms, and a student-focused visual dashboard.

## Database

The application uses normalized entities such as Student, Course, Enrollment, AttendanceRecord, GradeRecord, AssignmentItem, FeeInvoice, NotificationItem, CalendarEvent, and SupportTicket.

## Deployment

Open `StudentDashboard.slnx` in Visual Studio and run the `StudentDashboard.Web` profile.
