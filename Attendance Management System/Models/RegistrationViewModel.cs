using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class RegistrationViewModel
    {
        public int id { get; set; }
        public string serviceId { get; set; }
        public string designation { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string company { get; set; }
       
    }
}
