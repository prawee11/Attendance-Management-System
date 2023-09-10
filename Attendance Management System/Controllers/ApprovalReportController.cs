using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using OfficeOpenXml;
using static System.Net.Mime.MediaTypeNames;

namespace Attendance_Management_System.Controllers
{
    public class ApprovalReportController : Controller
    {
        private readonly MVCDemoDbContext _context;

        public ApprovalReportController(MVCDemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ApprovalReport(string location, int year, string month)
        {
            var approvalReportData = _context.Attendance
                .Where(a => a.location == location && a.year == year && a.month == month)
                .GroupBy(a => new { a.sId, a.employeeName })
                .Select(g => new ApprovalReportViewModel
                {
                    SId=g.Key.sId,
                    EmployeeName = g.Key.employeeName,
                    Count = g.Count()
                })
                .ToList();

            return View("ApprovalReport", approvalReportData);
        }

        public ActionResult DownloadExcel(List<string> SIds, List<string> EmployeeNames, List<string> Counts, List<string> SpecialDetails)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new YourMainForm());

            // Create a DataTable to hold the data
            DataTable table = new DataTable();
            table.Columns.Add("SId");
            table.Columns.Add("Employee Name");
            table.Columns.Add("Total Attendance");
            table.Columns.Add("Special Details");

            // Add the rows to the DataTable
            for (int i = 0; i < EmployeeNames.Count; i++)
            {
                DataRow row = table.NewRow();
                row["SId"] = SIds[i];
                row["Employee Name"] = EmployeeNames[i];
                row["Total Attendance"] = Counts[i];
                row["Special Details"] = SpecialDetails[i];
                table.Rows.Add(row);
            }

            // Generate the Excel file using a library like EPPlus
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Approval Report");
                worksheet.Cells["A1"].LoadFromDataTable(table, true);

                // Convert the Excel package to a byte array
                byte[] fileBytes = package.GetAsByteArray();

                // Download the file
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "approvalTable.xlsx");
            }
        }
    }
}
