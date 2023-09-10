using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class UserPrivilege
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string userId { get; set; }
        [MaxLength(100)]
        public string level { get; set; }             
    }
}
