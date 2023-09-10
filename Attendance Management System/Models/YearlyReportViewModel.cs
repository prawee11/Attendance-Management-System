using Microsoft.AspNetCore.Mvc.Rendering;

namespace Attendance_Management_System.Models
{
    public class YearlyReportViewModel
    {
        public string SId { get; set; }
        public string EmployeeName { get; set; }
        public int Count { get; set; }
    }
}
