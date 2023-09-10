using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class SignUp
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string companyName { get; set; }
        [MaxLength (100)]
        public string companyAddress { get; set; }
        [MaxLength (100)]   
        public string contactPerson { get; set; }
        [MaxLength (10)]
        public int contactNumber { get; set; }
        [MaxLength(100)]
        public string userName { get; set; }
        [MaxLength (10)]
        public string password { get; set; }
        public int status { get; set; }
    }
}
