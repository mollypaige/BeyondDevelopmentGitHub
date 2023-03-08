using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;

namespace Lab1.Pages.Student
{
    public class DashboardModel : PageModel
    {
        // Property to bind the selected class value from the form
        [BindProperty] public int SelectedClass { get; set; }

        // List to store the available classes
        public List<Class> ClassList;

        public DashboardModel()
        {
            ClassList = new List<Class>();
        }

        public void OnGet()
        {
            SqlDataReader classReader = DBClass.ClassReader();
            // Loop through the results and add each class to the list
            while (classReader.Read())
            {
                ClassList.Add(new Class
                {
                    classID = Int32.Parse(classReader["classID"].ToString()),
                    className = classReader["className"].ToString(),
                });
            }
            // Close the database connection
            DBClass.LabDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("StudentHome", new { selectedClass = SelectedClass });
        }
    }
}