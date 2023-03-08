using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.StudentView
{
    public class CreateStudentAccountModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string studentFirstName { get; set; }

        [BindProperty]
        public string studentLastName { get; set; }

        [BindProperty]
        public string studentEmail { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            

            DBClass.CreateStudentHashedUser(Username, Password, studentFirstName, studentLastName, studentEmail);
            DBClass.LabDBConnection.Close();

            // Perform actual logic to check if user was successfully
            //  added in your projects but for demo purposes we can say:

            ViewData["UserCreate"] = "User Successfully Created!";

            return RedirectToPage("StudentLogin");
        }
    }
}
