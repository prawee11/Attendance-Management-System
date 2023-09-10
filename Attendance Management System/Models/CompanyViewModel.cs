using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class CompanyViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public List<SelectListItem> names1 { get; set; }
        public List<SelectListItem> names2 { get; set; }
    }
}
