using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class AdminSignUp
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string userName { get; set; }
        [MaxLength(10)]
        public int contactNumber { get; set; }
        [MaxLength(10)]
        public string password { get; set; }
       
    }
}
