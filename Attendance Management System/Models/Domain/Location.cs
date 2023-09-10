using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Location
    {
        [Key] 
        public int id { get; set; }
        [MaxLength(100)]
        public string location { get; set; }
        [MaxLength (100)]
        public string status { get; set; }

    }
}
