
namespace Lab1.Pages.DataClasses
{
    public class Meeting
    {
        public String? meetingName { get; set; }

        public DateOnly? meetingDate { get; set; }

        public TimeOnly? meetingStart { get; set; }

        public TimeOnly? meetingEnd { get; set; }

        public int? studentID { get; set; }

        public int? instructorID { get; set; }
    }
}
