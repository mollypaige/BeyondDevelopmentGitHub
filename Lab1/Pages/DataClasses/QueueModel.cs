using System.Collections.Generic;
using System.Linq;

namespace Lab1.Pages.DataClasses
{
    public class QueueModel
    {
        public QueueModel(IEnumerable<Meeting> meetings, int studentId)
        {
            StudentId = studentId;
            var studentMeetings = meetings.Where(m => m.studentID == studentId).OrderBy(m => m.meetingDate).ThenBy(m => m.meetingStart);
            PlaceInLine = studentMeetings.Count(m => m.studentID == studentId && m.meetingDate == studentMeetings.First().meetingDate && m.meetingStart <= studentMeetings.First().meetingStart);
        }

        public int StudentId { get; }

        public int PlaceInLine { get; }
    }
}
