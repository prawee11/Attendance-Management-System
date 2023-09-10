using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class MonthlyReportController : Controller
    {
        private readonly MVCDemoDbContext _context;

        public MonthlyReportController(MVCDemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MonthlyReport(string location, string company, int year, string month)
        {
            var monthlyReportData = _context.Attendance
                .Where(a => a.location == location || a.company == company && a.year == year && a.month == month)
                .GroupBy(a => new { a.sId, a.employeeName })
                .Select(g => new MonthlyReportViewModel
                {
                    SId = g.Key.sId,
                    EmployeeName = g.Key.employeeName,
                    Count = g.Count()
                })
                .ToList();              

            return View("MonthlyReport", monthlyReportData);
        }
    }
}
