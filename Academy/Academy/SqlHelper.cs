using Academy;
using Microsoft.Data.SqlClient;
namespace Academy;
public class SqlHelper
    {
    const string _connStr = "Server=JUPITER01\\MAINDB;Database=Academy; Trusted_Connection=True;  TrustServerCertificate = True";
        public void CreateStudent(string firstName, string lastName, DateTime? dateOfBirth, string username, string password, DateTime? enrollmentDate)
        {
            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();

                var query = @"INSERT INTO Students (Firstname, Lastname, DateOfBirth, Username, Password, EnrollmentDate) 
                                  VALUES (@Firstname, @Lastname, @DateOfBirth, @Username, @Password, @EnrollmentDate)";

                using (var command = new SqlCommand(query, connection))
                {
                        command.Parameters.AddWithValue("@Firstname", firstName);
                        command.Parameters.AddWithValue("@Lastname", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", (object)dateOfBirth ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@EnrollmentDate", (object)enrollmentDate ?? DBNull.Value);
                        command.ExecuteNonQuery();
                }            
            }
        }

        public List<StudentInfo> GetStudentInfo()
        {
            var studentInfoList = new List<StudentInfo>();

            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();
                var query = @"SELECT 
                              Students.Id,
                              CONCAT(Students.Firstname, ' ', Students.Lastname) AS FullName,
                              Groups.Groupname,
                              Classes.Schedule,
                              Classes.RoomName
                              FROM Students
                              JOIN Enrollments ON Students.Id = Enrollments.StudentID
                              JOIN Groups ON Enrollments.GroupId = Groups.Id
                              JOIN Classes ON Groups.Id = Classes.GroupId";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         var studentInfo = new StudentInfo
                         {
                             StudentId = reader.GetInt32(reader.GetOrdinal("Id")),
                             FullName = reader.GetString(reader.GetOrdinal("FullName")),
                             GroupName = reader.GetString(reader.GetOrdinal("Groupname")),
                             Schedule = reader.GetString(reader.GetOrdinal("Schedule")),
                             RoomName = reader.GetString(reader.GetOrdinal("RoomName"))
                         };
                         studentInfoList.Add(studentInfo);
                    }
                }
            }
            return studentInfoList;
        }

        public void UpdateStudent(int studentId, string firstName, string lastName, DateTime? dateOfBirth, string username, string password, DateTime? enrollmentDate)
        {
            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();

                    var query = @"UPDATE Students 
                                  SET Firstname = @Firstname, Lastname = @Lastname, DateOfBirth = @DateOfBirth, 
                                      Username = @Username, Password = @Password, EnrollmentDate = @EnrollmentDate
                                  WHERE Id = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        command.Parameters.AddWithValue("@Firstname", firstName);
                        command.Parameters.AddWithValue("@Lastname", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", (object)dateOfBirth ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@EnrollmentDate", (object)enrollmentDate ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var connection = new SqlConnection(_connStr))
            {
                    connection.Open();

                    var query = @"DELETE FROM Students WHERE Id = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        command.ExecuteNonQuery();
                    }
            }
        }

        public void CreateGroup(string groupName)
        {
            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();

                    var query = @"INSERT INTO Groups (GroupName) VALUES (@GroupName)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroupName", groupName);
                        command.ExecuteNonQuery();
                    }
            }
        }

        public List<string> GetGroups()
        {
            var groupList = new List<string>();

            using (var connection = new SqlConnection(_connStr))
                {
                    connection.Open();
                    var query = "SELECT Groupname FROM Groups";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groupList.Add(reader.GetString(0));
                        }
                    }
                }

            return groupList;
        }
    }
    public class StudentInfo
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string GroupName { get; set; }
        public string Schedule { get; set; }
        public string RoomName { get; set; }
    }