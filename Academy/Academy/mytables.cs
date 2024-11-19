using System;
using System.Collections.Generic;
namespace Academy;
public class Student
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public ICollection<Instructor> Instructors { get; set; }
    public ICollection<Group> Groups { get; set; }
}

public class Instructor
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime? HireDate { get; set; }
    public int DepartmentId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PIN { get; set; }
    public Department Department { get; set; }
    public ICollection<Class> Classes { get; set; }
}

public class Group
{
    public int Id { get; set; }
    public string GroupName { get; set; }
    public int DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Department Department { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Class> Classes { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }
    public int StudentID { get; set; }
    public int GroupId { get; set; }
    public Student Student { get; set; }
    public Group Group { get; set; }
}

public class Class
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int InstructorID { get; set; }
    public string Schedule { get; set; }
    public string RoomName { get; set; }
    public Group Group { get; set; }
    public Instructor Instructor { get; set; }
}
