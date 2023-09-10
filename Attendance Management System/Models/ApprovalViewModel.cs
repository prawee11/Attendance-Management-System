using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Management_System.Models
{
    public class ApprovalViewModel
    {
        public int id { get; set; }
        public string location { get; set; }
        public string company { get; set; }
        public int year { get; set; }
        public string month { get; set; }
        public int no1 { get; set; }
        public string empId1 { get; set; }
        public string approval1 { get; set; }
        public string remark1 { get; set; }
        public int no2 { get; set; }
        public string empId2 { get; set; }
        public string approval2 { get; set; }
        public string remark2 { get; set; }
        public List<SelectListItem> Locations { get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Months { get; set; }
      
        public string SId { get; set; }
        public string EmployeeName { get; set; }
        public int Count { get; set; }

        public List<ApprovalData> ApprovalDatas { get; set; }
    }

    public class ApprovalData
        {
            public int No { get; set; }
            public string EmployeeId { get; set; }
            public string Approval { get; set; }
            public string Remark { get; set; }
        } 
}
