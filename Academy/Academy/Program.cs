using Academy;

class Program
{
    static void Main(string[] args)
    {
        var sqlHelper = new SqlHelper();

        sqlHelper.CreateStudent("Seljan", "Karimli", new DateTime(2000, 1, 1), "Selcaster", "password123", DateTime.Now);

        var students = sqlHelper.GetStudentInfo();
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FullName} is in {student.GroupName} at {student.Schedule}, Room: {student.RoomName}");
        }

        sqlHelper.UpdateStudent(1, "Ruslan", "Bayramov", new DateTime(2000, 1, 1), "RBARYAM", "newpassword", DateTime.Now);

        sqlHelper.DeleteStudent(1);

        sqlHelper.CreateGroup("New Group");

        var groups = sqlHelper.GetGroups();
        foreach (var group in groups)
        {
            Console.WriteLine(group);
        }
    }
}