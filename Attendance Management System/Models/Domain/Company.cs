using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Company
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(100)]
        public string status { get; set; }

    }
}
