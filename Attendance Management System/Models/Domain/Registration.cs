using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Registration
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string serviceId { get; set; }
        [MaxLength(100)]
        public string designation { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(100)]
        public string location  { get; set; }
        [MaxLength(100)]
        public string company { get; set; }
    }
}
