using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class SignInViewModel
    {
        public int id { get; set; } 
        public string userName { get; set; }
        public string password { get; set; }
    }
}
