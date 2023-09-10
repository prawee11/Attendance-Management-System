using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Attendance_Management_System.Controllers
{
    public class YearlyReportController : Controller
    {
        private readonly MVCDemoDbContext _context;

        public YearlyReportController(MVCDemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult YearlyReport(string location, string company, int year)
        {
            var yearlyReportData = _context.Attendance
                .Where(a => a.location == location || a.company == company && a.year == year)
                .GroupBy(a => new { a.sId, a.employeeName })
                .Select(g => new YearlyReportViewModel
                {
                    SId = g.Key.sId,
                    EmployeeName = g.Key.employeeName,
                    Count = g.Count()
                })
                .ToList();

            return View("YearlyReport", yearlyReportData);
        }
    }
}
