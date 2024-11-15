CREATE DATABASE Academy
USE Academy
CREATE Table Students(
	Id int IDENTITY primary key,
	Firstname nvarchar(15) NOT NULL,
	Lastname nvarchar(20) NOT NULL,
	DateOfBirth DATE,
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR(15) NOT NULL, 
	EnrollmentDate DATE
)
CREATE TABLE Departments
(
	Id int identity primary key,
	DepartmentName NVARCHAR(25)
)
CREATE TABLE INSTRUCTORS
(
	Id int identity primary key,
	Firstname nvarchar(15) NOT NULL,
	Lastname nvarchar(20) NOT NULL,
	HireDate DATE,
	DepartmentId int references Departments(Id),
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR(15) NOT NULL, 
	PIN NVARCHAR(7) NOT NULL
)

Create TABLE Groups
(
	Id int identity primary key,
	Groupname nvarchar(15),
	DepartmentId int references Departments(Id),
	StartDate Date,
	EndDate Date
)

CREATE TABLE Enrollments
(
	Id int identity primary key,
	StudentID int references Students(Id),
	GroupId int references GRoups(Id)
)
CREATE TABLE Classes
(
	Id int identity primary key,
	GroupId int references GRoups(Id),
	InstructorID int references Instructors(Id),
	Schedule nvarchar(20),
	RoomName nvarchar(20)
)

CREATE PROCEDURE ac_CreateGroup
    @GroupName NVARCHAR(15)
AS
BEGIN
    INSERT INTO Groups (GroupName)
    VALUES (@GroupName);
END;

EXEC ac_CreateGroup SELJAN

Select * From GROUPs

CREATE VIEW StudentInfo AS
SELECT 
    CONCAT(Students.FirstName, ' ', Students.LastName) AS FullName, 
    Students.Id,
    Groups.Groupname,
    Classes.Schedule,
	Classes.RoomName
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentID
JOIN Groups ON Enrollments.GroupId = Groups.Id
JOIN Classes ON Groups.Id = Classes.GroupId;

SELECT * FROM StudentInfo;