using Lab1.Pages.DataClasses;
using Lab1.Pages.DataClasses.Student;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Lab1.Pages.StudentView
{
    public class ScheduleMeetingModel : PageModel
    {
        [BindProperty]
        [Required]
        public Meeting NewMeeting { get; set; }

        [BindProperty]
        [Required]
        public int SelectedInstructor { get; set; }

        [BindProperty]
        [Required]
        public int SelectedStudent { get; set; }

        public String SelectMessage { get; set; }

        public List<Instructor> InstructorList;

        public List<Students> StudentList;

        public ScheduleMeetingModel() 
        {
            StudentList = new List<Students>();
            InstructorList = new List<Instructor>();
        }
        public void OnGet()
        {
            SqlDataReader instructorReader = DBClass.InstructorReader();
            while (instructorReader.Read())
            {
                InstructorList.Add(new Instructor
                {
                    instructorID = Int32.Parse(instructorReader["instructorID"].ToString()),
                    instructorFirstName = instructorReader["instructorFirstName"].ToString(),
                    instructorLastName = instructorReader["instructorLastName"].ToString(),
                    instructorEmail = instructorReader["instructorEmail"].ToString()

                });
            }
            DBClass.LabDBConnection.Close();

            SqlDataReader studentReader = DBClass.StudentReader();
            while (studentReader.Read())
            {
                StudentList.Add(new Students
                {
                    StudentID = Int32.Parse(studentReader["StudentID"].ToString()),
                    StudentFirstName = studentReader["StudentFirstName"].ToString(),
                    StudentLastName = studentReader["StudentLastName"].ToString(),
                    StudentEmail = studentReader["StudentEmail"].ToString()

                });
            }
            DBClass.LabDBConnection.Close();
        }

        public void OnPost()
        {
            DBClass.InsertMeeting(NewMeeting);
            DBClass.LabDBConnection.Close();

            SelectMessage = "Success! Meeting has been created.";
            
        }
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewMeeting.meetingName = "Test Name";
            NewMeeting.instructorID = 1;
            NewMeeting.studentID = 1;

            return Page();
        }

        public IActionResult OnPostClearHandler()
        {
            ModelState.Clear();

            return Page();
        }
    }


}
