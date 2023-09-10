using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Security
    {
        [Key] 
        public int id { get; set; }
        [MaxLength(100)]
        public string location { get; set; }
        [MaxLength(100)]
        public string companyName { get; set; }
        public int tCount { get; set; }
        [MaxLength(100)]
        public string available { get; set; }
        [MaxLength(100)]
        public string sId { get; set; }
    }
}
