using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class AdminSignUpViewModel
    {   
        public int id { get; set; }      
        public string userName { get; set; }
        public int contactNumber { get; set; }
        public string password { get; set; }
    }
}
