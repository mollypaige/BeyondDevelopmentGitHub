using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Lab1.Pages.StudentView
{
    public class HomeModel : PageModel
    {
        
        [BindProperty]
        [Required]
        public String SelectedInstructorFirstName { get; set; }


        [BindProperty]
        [Required]
        public String SelectedInstructorLastName { get; set;}

        [BindProperty]

        public int? studentID { get; set; }
        public int SelectedOfficeHours { get; set; }

        public List<Instructor> InstructorList;

        public List<OfficeHours> OfficeHoursList;



        public HomeModel()
        {
            InstructorList = new List<Instructor>();
            OfficeHoursList = new List<OfficeHours>();
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

        }
        public IActionResult OnPostSearchInstructor()
        {
            SqlDataReader officeHoursReader = DBClass.SearchInstructor(SelectedInstructorFirstName, SelectedInstructorLastName);
            while (officeHoursReader.Read())
            {
                OfficeHoursList.Add(new OfficeHours
                {
                    officeHoursID = Int32.Parse(officeHoursReader["officeHoursID"].ToString()),
                    officeHoursDay = officeHoursReader["officeHoursDay"].ToString(),
                    startTime = TimeOnly.Parse(officeHoursReader["startTime"].ToString()),
                    endTime = TimeOnly.Parse(officeHoursReader["endTime"].ToString()),
                    roomNumber = Int32.Parse(officeHoursReader["roomNumber"].ToString())

                });
            }
            DBClass.LabDBConnection.Close();


            return Page();
        }

        public RedirectToPageResult OnPostViewOfficeHours()
        {
            return new RedirectToPageResult("UpcomingOfficeHours");
        }

        public RedirectToPageResult OnPostScheduleMeeting()
        {
            return new RedirectToPageResult("ScheduleMeeting");
        }

        public IActionResult OnGetSignUp(int officehoursid)
        {
            studentID = HttpContext.Session.GetInt32("studentID");

            DBClass.AddToQueue(officehoursid, studentID);
            DBClass.LabDBConnection.Close();

            return Page();


        }
    }
}