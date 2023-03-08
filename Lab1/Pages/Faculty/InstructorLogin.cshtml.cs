using Lab1.Pages.DataClasses.Student;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.Faculty
{
    public class InstructorLoginModel : PageModel
    {
        [BindProperty]
        public string FacultyUsername { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int instructorID { get; set; }

        public String LoginMessage { get; set; }
        public void OnGet(String logout)
        {
            if (logout != null)
            {
                HttpContext.Session.Clear();
                LoginMessage = "Logged out Successfully!";
            }


        }

        public IActionResult OnPost()
        {

            if (DBClass.FacultyHashedParameterLogin(FacultyUsername, Password))
            {

                DBClass.LabDBConnection.Close();
                SqlDataReader namereader = DBClass.InstructorNameReader(FacultyUsername);

                while (namereader.Read())
                {
                    instructorID = Convert.ToInt32(namereader["instructorID"]);
                    FirstName = namereader["instructorFirstName"].ToString();
                    LastName = namereader["instructorLastName"].ToString();
                }

                HttpContext.Session.SetString("FacultyUsername", FacultyUsername);
                HttpContext.Session.SetInt32("instructorID", instructorID);
                HttpContext.Session.SetString("instructorFirstName", FirstName);
                HttpContext.Session.SetString("instructorLastName", LastName);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.LabDBConnection.Close();
                return RedirectToPage("FacultyHome");
            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                DBClass.LabDBConnection.Close();
                return Page();
            }
        }
    }
}
