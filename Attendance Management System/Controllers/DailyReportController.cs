using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class DailyReportController : Controller
    {
        private readonly MVCDemoDbContext _context;

        public DailyReportController(MVCDemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DailyReport(string location, string company, int year, string month, int day)
        {
            var daillyReportData = _context.Attendance
                .Where(a => a.location == location || a.company == company && a.year == year && a.month == month && a.day == day)
                .GroupBy(a => new { a.sId, a.employeeName })
                .Select(g => new DailyReportViewModel
                {
                    SId = g.Key.sId,
                    EmployeeName = g.Key.employeeName,
                    //Count = g.Count()
                })
                .ToList();

            return View("DailyReport", daillyReportData);
        }
    }
}
