using GroceryInventory.Pages.DB;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DataClasses.Student;
using System.Data.SqlClient;

namespace Lab1.Pages.DB
{
    public class DBClass
    {
        //Connection object at the class level

        public static SqlConnection LabDBConnection = new SqlConnection();

        //Connection String

        public static readonly String LabDBConnString = "Server=Localhost;Database=Lab3;Trusted_Connection=True";
        public static readonly String? AuthConnString = "Server=Localhost;Database=AUTH;Trusted_Connection=True";

        // Method(s)

        public static SqlDataReader ClassReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Class";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader InstructorReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Instructor";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader MeetingReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Meeting";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader OfficeHoursReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM OfficeHours";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader QueueReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Queue";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader RoomReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Room";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader ScheduleReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Schedule";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }
        public static SqlDataReader StudentReader()
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Students";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader SearchInstructor(String instructorFirstName, String instructorLastName)
        {
            String sqlQuery = "select OH.officeHoursID, OH.officeHoursDay, OH.startTime, OH.endTime, OH.roomNumber " +
                "from Instructor I, OfficeHours OH where I.instructorID = OH.instructorID AND I.instructorFirstName = '";
            sqlQuery += instructorFirstName + "' AND instructorLastName = '" + instructorLastName + "';";

            SqlCommand cmdInstructorRead = new SqlCommand();
            cmdInstructorRead.Connection = LabDBConnection;
            cmdInstructorRead.Connection.ConnectionString = LabDBConnString;
            cmdInstructorRead.CommandText = sqlQuery;
            cmdInstructorRead.Connection.Open();

            SqlDataReader tempReader = cmdInstructorRead.ExecuteReader();

            return tempReader;

        }

        public static void InsertOfficeHours(OfficeHours oh)
        {
            String sqlQuery = "insert into officehours (officeHoursDay, startTime, endTime, instructorID, roomNumber) " +
                "VALUES ('";
            sqlQuery += oh.officeHoursDay + "',";
            sqlQuery += "'" + oh.startTime + "',";
            sqlQuery += "'" + oh.endTime + "',";
            sqlQuery += oh.instructorID + ",";
            sqlQuery += oh.roomNumber + ");";

            SqlCommand cmdOfficeHoursRead = new SqlCommand();
            cmdOfficeHoursRead.Connection = LabDBConnection;
            cmdOfficeHoursRead.Connection.ConnectionString = LabDBConnString;
            cmdOfficeHoursRead.CommandText = sqlQuery;
            cmdOfficeHoursRead.Connection.Open();

            cmdOfficeHoursRead.ExecuteNonQuery();

        }

        public static void InsertMeeting(Meeting m)
        {
            String sqlQuery = "insert into meeting (meetingName, meetingDate, meetingStart, meetingEnd, studentID, instructorID) " +
                "VALUES ('";
            sqlQuery += m.meetingName + "',";
            sqlQuery += "'" + m.meetingDate + "',";
            sqlQuery += "'" + m.meetingStart + "',";
            sqlQuery += "'" + m.meetingEnd + "',";
            sqlQuery += m.studentID + ",";
            sqlQuery += m.instructorID + ");";

            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = LabDBConnection;
            cmdMeetingRead.Connection.ConnectionString = LabDBConnString;
            cmdMeetingRead.CommandText = sqlQuery;
            cmdMeetingRead.Connection.Open();

            cmdMeetingRead.ExecuteNonQuery();

        }

        public static void AddToQueue(int officehoursID, int? studentID)
        {
            String sqlQuery = "INSERT INTO Queue (officeHoursID, studentID) " +
                "VALUES (" + officehoursID + ", " + studentID + ");";
            SqlCommand cmdQueueRead = new SqlCommand();
            cmdQueueRead.Connection = LabDBConnection;
            cmdQueueRead.Connection.ConnectionString = LabDBConnString;
            cmdQueueRead.CommandText = sqlQuery;
            cmdQueueRead.Connection.Open();

            cmdQueueRead.ExecuteNonQuery();

        }

        public static SqlDataReader GeneralReaderQuery(string sqlQuery)
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }
        public static void InsertQuery(string sqlQuery)
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            cmdProductRead.ExecuteNonQuery();

        }

        public static SqlDataReader ViewWaitingRoom(int officeHoursID)
        {
            String sqlQuery = "select S.studentFirstName, S.studentLastName, S.studentID, S.studentEmail " +
                "from Students S, Queue Q where S.studentID = Q.studentID AND Q.officeHoursID = " + officeHoursID + ";";

            SqlCommand cmdViewWRRead = new SqlCommand();
            cmdViewWRRead.Connection = LabDBConnection;
            cmdViewWRRead.Connection.ConnectionString = LabDBConnString;
            cmdViewWRRead.CommandText = sqlQuery;
            cmdViewWRRead.Connection.Open();

            SqlDataReader tempReader = cmdViewWRRead.ExecuteReader();

            return tempReader;

        }
        public static SqlDataReader StudentDropDown(int officeHoursID)
        {
            String sqlQuery = "SELECT DISTINCT Students.StudentID, Students.StudentFirstName, Students.StudentLastName, Students.StudentEmail " +
                "from Students, Queue " +
                "WHERE Students.studentID NOT IN (SELECT Queue.studentID FROM Queue WHERE Queue.officeHoursID = " + officeHoursID + ");";

            SqlCommand cmdSDDRead = new SqlCommand();
            cmdSDDRead.Connection = LabDBConnection;
            cmdSDDRead.Connection.ConnectionString = LabDBConnString;
            cmdSDDRead.CommandText = sqlQuery;
            cmdSDDRead.Connection.Open();

            SqlDataReader tempReader = cmdSDDRead.ExecuteReader();

            return tempReader;

        }


        public static void DeleteStudent(int OfficeHoursID, int StudentID)
        {
            String sqlQuery = "delete from Queue where officeHoursID = " + OfficeHoursID + " AND studentID = " + StudentID + ";";

            SqlCommand cmdDeleteStudent = new SqlCommand();
            cmdDeleteStudent.Connection = LabDBConnection;
            cmdDeleteStudent.Connection.ConnectionString = LabDBConnString;
            cmdDeleteStudent.CommandText = sqlQuery;
            cmdDeleteStudent.Connection.Open();

            cmdDeleteStudent.ExecuteNonQuery();
        }

        public static SqlDataReader GeneralStoredProcedureReader(string StoredProcedureName)
        {

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandType = System.Data.CommandType.StoredProcedure;
            cmdProductRead.CommandText = StoredProcedureName;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }

        public static bool StudentHashedParameterLogin(string Username, string Password)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = LabDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdLogin.CommandText = "Lab3_studentHashedLogin";
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader(); 
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool FacultyHashedParameterLogin(string Username, string Password)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = LabDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdLogin.CommandText = "Lab3_facultyHashedLogin";
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    return true;
                }
            }

            return false;
        }





        public static void CreateStudentHashedUser(string Username, string Password, string firstName, string lastName, string email)
        {
            string loginQuery =
                "INSERT INTO StudentHashedCredentials (Username,Password,firstName,lastName,email) values (@Username, @Password, @firstName, @lastName, @email)";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = LabDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@firstName", firstName);
            cmdLogin.Parameters.AddWithValue("@lastName", lastName);
            cmdLogin.Parameters.AddWithValue("@email", email);
            cmdLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));

            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdLogin.ExecuteNonQuery();

        }

        public static void CreateFacultyHashedUser(string Username, string Password, string firstName, string lastName, string email)
        {
            string loginQuery =
                "INSERT INTO FacultyHashedCredentials (Username,Password,firstName,lastName,email) values (@Username, @Password, @firstName, @lastName, @email)";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = LabDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@firstName", firstName);
            cmdLogin.Parameters.AddWithValue("@lastName", lastName);
            cmdLogin.Parameters.AddWithValue("@email", email);
            cmdLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));

            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdLogin.ExecuteNonQuery();

        }

        public static SqlDataReader PlaceInLineReader(int QueueID, int OfficeHoursID)
        {
            String sqlQuery = "select COUNT(Queue.studentID) NumStudentsAheadsOfYou from Queue, Students" +
            " where Students.studentID = Queue.studentID AND officeHoursID =  " + OfficeHoursID + " AND Queue.queueID < " + QueueID + ";";

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }

        public static SqlDataReader NameReader(string username)
        {
            String sqlQuery = "select studentID, studentFirstName, studentLastName from Students where studentUsername = '" + username + "';";

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }

        public static SqlDataReader InstructorNameReader(string username)
        {
            String sqlQuery = "select instructorID, instructorFirstName, instructorLastName from Instructor where instructorUsername = '" + username + "';";

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = LabDBConnection;
            cmdProductRead.Connection.ConnectionString = LabDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;

        }

    }
}