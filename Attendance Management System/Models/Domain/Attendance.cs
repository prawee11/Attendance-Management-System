using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Attendance
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string location { get; set; }
        [MaxLength(100)]
        public string company { get; set; }
        public int year { get; set; }
        [MaxLength(100)]
        public string month { get; set; }
        public int day { get; set; }
        [MaxLength(100)]
        public string sId { get; set; }
        [MaxLength(100)]
        public string designation { get; set; }
        [MaxLength(100)]
        public string employeeName { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime departureDate { get; set; }
        [MaxLength(100)]
        public string shiftType { get; set; }
        public TimeSpan arrivalTime { get; set; }
        public TimeSpan departureTime { get; set; }
        [MaxLength(100)]
        public string duration { get; set; }
        [MaxLength(100)]
        public string penalty { get; set; }
        [MaxLength(100)]
        public string remarks { get; set; }
    }
}
