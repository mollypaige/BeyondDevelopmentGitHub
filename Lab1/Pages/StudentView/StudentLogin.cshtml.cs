using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.StudentView
{
    public class StudentLoginModel : PageModel
    {
        [BindProperty]
        public string studentUsername { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int studentID { get; set; }

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

            if (DBClass.StudentHashedParameterLogin(studentUsername, Password))
            {
                DBClass.LabDBConnection.Close();
                SqlDataReader namereader = DBClass.NameReader(studentUsername);

                while (namereader.Read())
                {
                    studentID = Convert.ToInt32(namereader["studentID"]);
                    FirstName = namereader["studentFirstName"].ToString();
                    LastName = namereader["studentLastName"].ToString();
                }

                HttpContext.Session.SetString("studentUsername", studentUsername);
                HttpContext.Session.SetInt32("studentID", studentID);
                HttpContext.Session.SetString("studentFirstName", FirstName);
                HttpContext.Session.SetString("studentLastName", LastName);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.LabDBConnection.Close();
                return RedirectToPage("StudentHome");
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
