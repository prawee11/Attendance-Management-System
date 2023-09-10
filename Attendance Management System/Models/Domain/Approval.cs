using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models.Domain
{
    public class Approval
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string location { get; set; }
        [MaxLength(50)]
        public string company { get; set; }
        public int year { get; set; }
        [MaxLength(20)]
        public string month { get; set; }
        public int no1 { get; set; }
        [MaxLength(10)]
        public string empId1 { get; set; }
        [MaxLength(10)]
        public string approval1 { get; set; }
        [MaxLength(50)]
        public string remark1 { get; set; }
        public int no2 { get; set; }
        [MaxLength(10)]
        public string empId2 { get; set; }
        [MaxLength(10)]
        public string approval2 { get; set; }
        [MaxLength(50)]
        public string remark2 { get; set; }
    }
}
