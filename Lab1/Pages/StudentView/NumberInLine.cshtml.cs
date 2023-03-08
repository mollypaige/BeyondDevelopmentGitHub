using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.StudentView
{
    public class NumberInLineModel : PageModel
    {
        public List<int> numInLine = new List<int>();

        public void OnGetNumInLine(int queueid, int officehoursid)
        {
            SqlDataReader numInLineReader = DBClass.PlaceInLineReader(queueid, officehoursid);

            while (numInLineReader.Read())
            {
                numInLine.Add(Convert.ToInt32(numInLineReader["NumStudentsAheadsOfYou"]));
            }

            numInLineReader.Close();

            DBClass.LabDBConnection.Close();
        }
    }
}
