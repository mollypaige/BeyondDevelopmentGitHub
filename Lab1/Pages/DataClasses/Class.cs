using Lab1.Pages.DB;

namespace Lab1.Pages.DataClasses
{
    public class Class
    {   
        public int? classID { get; set; }

        public String? className { get; set; }

        public int? instructorID { get; set; }

        public static implicit operator Class(DBClass v)
        {
            throw new NotImplementedException();
        }
    }
}
