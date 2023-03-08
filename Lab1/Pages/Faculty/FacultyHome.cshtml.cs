using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.Faculty
{
    public class FacultyHomeModel : PageModel
    {
        [BindProperty]
        public String? SelectedInstructorFirstName { get; set; }

        [BindProperty]
        public String? SelectedInstructorLastName { get; set; }
        [BindProperty] public int SelectedOfficeHours { get; set; }

        public int? instructorID { get; set; }

        public List<OfficeHours> YourOfficeHours;


        public FacultyHomeModel()
        {
            
            YourOfficeHours = new List<OfficeHours>();
            
        }


        public void OnGet()
        {

            SelectedInstructorFirstName = HttpContext.Session.GetString("instructorFirstName");
            SelectedInstructorLastName = HttpContext.Session.GetString("instructorLastName");

            SqlDataReader YourOfficeHoursReader = DBClass.SearchInstructor(SelectedInstructorFirstName, SelectedInstructorLastName);
            while (YourOfficeHoursReader.Read())
            {
                YourOfficeHours.Add(new OfficeHours
                {
                    officeHoursID = Int32.Parse(YourOfficeHoursReader["officeHoursID"].ToString()),
                    officeHoursDay = YourOfficeHoursReader["officeHoursDay"].ToString(),
                    startTime = TimeOnly.Parse(YourOfficeHoursReader["startTime"].ToString()),
                    endTime = TimeOnly.Parse(YourOfficeHoursReader["endTime"].ToString()),
                    roomNumber = Int32.Parse(YourOfficeHoursReader["roomNumber"].ToString())

                });
            }

            DBClass.LabDBConnection.Close();



        }

    }
}
