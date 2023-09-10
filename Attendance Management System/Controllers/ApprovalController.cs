using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using OfficeOpenXml;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using static Attendance_Management_System.Models.ApprovalViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Attendance_Management_System.Controllers
{
    public class ApprovalController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public ApprovalController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }        

        [HttpGet]
        public IActionResult Approval(string location, string company, int year, string month)
        {
            SqlConnection connection = null;
            var configuation = GetConfiguration();
            connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);

            List<string> locationNames = new List<string>();
            List<string> yearNames = new List<string>();
            List<string> monthNames = new List<string>();
            List<string> companyNames = new List<string>();

            string query1 = "SELECT DISTINCT location FROM Attendance";
            string query2 = "SELECT DISTINCT year FROM Attendance";
            string query3 = "SELECT DISTINCT month FROM Attendance";
            string query4 = "SELECT DISTINCT company FROM Attendance";

            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            using (SqlCommand command3 = new SqlCommand(query3, connection))
            using (SqlCommand command4 = new SqlCommand(query4, connection))
            {
                connection.Open();

                using (SqlDataReader reader1 = command1.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        locationNames.Add(reader1["location"].ToString());
                    }
                }
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        yearNames.Add(reader2["year"].ToString());
                    }
                }
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        monthNames.Add(reader3["month"].ToString());
                    }
                }
                using (SqlDataReader reader4 = command4.ExecuteReader())
                {
                    while (reader4.Read())
                    {
                        companyNames.Add(reader4["company"].ToString());
                    }
                }
                connection.Close();
            }
            ViewBag.YearNames = yearNames;
            ViewBag.LocationNames = locationNames;
            ViewBag.MonthNames = monthNames;
            ViewBag.CompanyNames = companyNames;

            var approvalReportData = MVCDemoDbContext.Attendance
                .Where(a => a.location == location || a.company == company && a.year == year && a.month == month)
                .GroupBy(a => new { a.sId, a.employeeName })
                .Select(g => new ApprovalViewModel
                {
                    SId = g.Key.sId,
                    EmployeeName = g.Key.employeeName,
                    Count = g.Count()
                })
                .ToList();
            ViewBag.ApprovalReportData = approvalReportData;


            var viewModel = new ApprovalViewModel
            {
                location = location,
                company = company,
                year = year,
                month = month,
            };



            var approvalData = MVCDemoDbContext.Approval
            .Where(a => (string.IsNullOrEmpty(location) || a.location == location) &&
                    (string.IsNullOrEmpty(company) || a.company == company) &&
                    (year == 0 || a.year == year) &&
                    (string.IsNullOrEmpty(month) || a.month == month))
            .Select(a => new ApprovalData
            {
                No = a.no1,
                EmployeeId = a.empId1,
                Approval = a.approval1,
                Remark = a.remark1
            })
            .ToList();
            ViewBag.ApprovalData = approvalData;
            
            return View("Approval", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Approval(ApprovalViewModel AddApproval)
        {
            var Approval = new Approval()
            {
                location = AddApproval.location,
                company = AddApproval.company,
                year = AddApproval.year,
                month = AddApproval.month,
                no1 = AddApproval.no1,
                empId1 = AddApproval.empId1,
                approval1 = AddApproval.approval1,
                remark1 = AddApproval.remark1,
                no2 = AddApproval.no2,
                empId2 = AddApproval.empId2,
                approval2 = AddApproval.approval2,
                remark2 = AddApproval.remark2,
            };
            await MVCDemoDbContext.AddAsync(Approval);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Approval");
        }
    }

}












//[HttpPost]
//public ActionResult DownloadExcel(List<string> SIds, List<string> EmployeeNames, List<string> Counts, List<string> SpecialDetails)
//{
//    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//    Application.EnableVisualStyles();
//    Application.SetCompatibleTextRenderingDefault(false);
//    Application.Run(new YourMainForm());

//    Create a DataTable to hold the data
//   DataTable table = new DataTable();
//    table.Columns.Add("SId");
//    table.Columns.Add("Employee Name");
//    table.Columns.Add("Total Attendance");
//    table.Columns.Add("Special Details");

//    Add the rows to the DataTable
//    for (int i = 0; i < EmployeeNames.Count; i++)
//    {
//        DataRow row = table.NewRow();
//        row["SId"] = SIds[i];
//        row["Employee Name"] = EmployeeNames[i];
//        row["Total Attendance"] = Counts[i];
//        row["Special Details"] = SpecialDetails[i];
//        table.Rows.Add(row);
//    }

//    Generate the Excel file using a library like EPPlus
//    using (var package = new ExcelPackage())
//    {
//        var worksheet = package.Workbook.Worksheets.Add("Approval");
//        worksheet.Cells["A1"].LoadFromDataTable(table, true);

//        Convert the Excel package to a byte array
//        byte[] fileBytes = package.GetAsByteArray();

//        Download the file
//        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "approvalTable.xlsx");
//    }
//}












//public class ApprovalController : Controller
//{
//    public IConfigurationRoot GetConfiguration()
//    {
//        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//        return builder.Build();
//    }

//    [HttpGet]
//    public IActionResult Approval()
//    {
//        SqlConnection connection = null;
//        var configuation = GetConfiguration();
//        connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);

//        List<string> locationNames = new List<string>();
//        List<string> yearNames = new List<string>();
//        List<string> monthNames = new List<string>();

//        string query1 = "SELECT DISTINCT location FROM Attendance";
//        string query2 = "SELECT DISTINCT year FROM Attendance";
//        string query3 = "SELECT DISTINCT month FROM Attendance";

//        using (SqlCommand command1 = new SqlCommand(query1, connection))
//        using (SqlCommand command2 = new SqlCommand(query2, connection))
//        using (SqlCommand command3 = new SqlCommand(query3, connection))
//        {
//            connection.Open();

//            using (SqlDataReader reader1 = command1.ExecuteReader())
//            {
//                while (reader1.Read())
//                {
//                    locationNames.Add(reader1["location"].ToString());
//                }
//            }
//            using (SqlDataReader reader2 = command2.ExecuteReader())
//            {
//                while (reader2.Read())
//                {
//                    yearNames.Add(reader2["year"].ToString());
//                }
//            }
//            using (SqlDataReader reader3 = command3.ExecuteReader())
//            {
//                while (reader3.Read())
//                {
//                    monthNames.Add(reader3["month"].ToString());
//                }
//            }
//            connection.Close();
//        }
//        ViewBag.YearNames = yearNames;
//        ViewBag.LocationNames = locationNames;
//        ViewBag.MonthNames = monthNames;
//        return View();
//    }
//}