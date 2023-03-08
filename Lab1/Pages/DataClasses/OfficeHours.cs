namespace Lab1.Pages.DataClasses
{
    public class OfficeHours
    {
        public int? officeHoursID { get; set; }

        public String? officeHoursDay { get; set; }

        public DateOnly? meetingDate { get; set; }

        public TimeOnly? startTime { get; set; }

        public TimeOnly? endTime { get; set; }

        public int? instructorID { get; set; }

        public int roomNumber { get; set; }
    }
}