using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class AttendanceViewModel
    {
        public int id { get; set; }        
        public string location { get; set; }
        public string company { get; set; }
        public int year { get; set; }
        public string month { get; set; }
        public int day { get; set; }
        public string sId { get; set; }       
        public string designation { get; set; }        
        public string employeeName { get; set; }       
        public DateTime arrivalDate { get; set; }        
        public DateTime departureDate { get; set; }       
        public string shiftType { get; set; }       
        public TimeSpan arrivalTime { get; set; }        
        public TimeSpan departureTime { get; set; }       
        public string duration { get; set; }        
        public string penalty { get; set; }       
        public string remarks { get; set; }
    }
}
