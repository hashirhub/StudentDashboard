-- Student Dashboard schema reference for SQLite / EF Core.
CREATE TABLE Students (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT NOT NULL,
    Phone TEXT,
    StudentNumber TEXT NOT NULL UNIQUE,
    ProgramName TEXT NOT NULL,
    Semester INTEGER NOT NULL,
    Status TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL
);

CREATE TABLE Courses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Code TEXT NOT NULL UNIQUE,
    Title TEXT NOT NULL,
    CreditHours INTEGER NOT NULL,
    InstructorName TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL
);

CREATE TABLE Enrollments (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    CourseId INTEGER NOT NULL,
    EnrolledOn TEXT NOT NULL,
    Status TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL,
    FOREIGN KEY(StudentId) REFERENCES Students(Id),
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);

CREATE TABLE AttendanceRecords (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    CourseId INTEGER NOT NULL,
    AttendanceDate TEXT NOT NULL,
    Status TEXT NOT NULL,
    Remarks TEXT,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL,
    FOREIGN KEY(StudentId) REFERENCES Students(Id),
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);

CREATE TABLE GradeRecords (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    CourseId INTEGER NOT NULL,
    ExamType TEXT NOT NULL,
    MarksObtained NUMERIC NOT NULL,
    TotalMarks NUMERIC NOT NULL,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL,
    FOREIGN KEY(StudentId) REFERENCES Students(Id),
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);

CREATE TABLE AssignmentItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CourseId INTEGER NOT NULL,
    Title TEXT NOT NULL,
    Description TEXT,
    DueDate TEXT NOT NULL,
    TotalMarks NUMERIC NOT NULL,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL,
    FOREIGN KEY(CourseId) REFERENCES Courses(Id)
);

CREATE TABLE FeeInvoices (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    Amount NUMERIC NOT NULL,
    DueDate TEXT NOT NULL,
    IsPaid INTEGER NOT NULL,
    Notes TEXT,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL,
    FOREIGN KEY(StudentId) REFERENCES Students(Id)
);
