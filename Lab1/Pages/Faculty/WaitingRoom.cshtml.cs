using Lab1.Pages.DataClasses;
using Lab1.Pages.DataClasses.Student;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Lab1.Pages.Faculty
{
    public class WaitingRoomModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int OfficeHoursID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StudentID { get; set; }

        public String SelectMessage { get; set; }


        public List<Students> StudentList;

        public WaitingRoomModel()
        {
           StudentList = new List<Students>();
        }

        public void OnGetStudents(int officehoursid)
        {
            officehoursid = OfficeHoursID;
            SqlDataReader studentsReader = DBClass.ViewWaitingRoom(officehoursid);
            while (studentsReader.Read())
            {
                StudentList.Add( new Students
                {
                    StudentID = Int32.Parse(studentsReader["StudentID"].ToString()),
                    StudentFirstName = studentsReader["StudentFirstName"].ToString(),
                    StudentLastName = studentsReader["StudentLastName"].ToString(),
                    StudentEmail = studentsReader["StudentEmail"].ToString()

                });
            }
            
            DBClass.LabDBConnection.Close();
        }

        public IActionResult OnGetRemove(int studentid, int officehoursid) 
        {
            StudentID = studentid;
            DBClass.DeleteStudent(officehoursid, StudentID);
            DBClass.LabDBConnection.Close();

            SelectMessage = "Success! This student has been removed from the Queue.";

            return Page();

        }


    }
}
