using Attendance_Management_System.Data;
using Attendance_Management_System.Models.Domain;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Resources;

namespace Attendance_Management_System.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public AttendanceController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }
        
        [HttpGet]
        public IActionResult Attendance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Attendance(AttendanceViewModel AddAttendance)
        {
            var Attendance = new Attendance()
            {
                location = AddAttendance.location,
                company=AddAttendance.company,
                year = AddAttendance.year,
                month = AddAttendance.month,
                day = AddAttendance.day,
                sId = AddAttendance.sId,
                designation = AddAttendance.designation,
                employeeName = AddAttendance.employeeName,
                arrivalDate = AddAttendance.arrivalDate,
                departureDate = AddAttendance.departureDate,
                shiftType = AddAttendance.shiftType,
                arrivalTime = AddAttendance.arrivalTime,
                departureTime = AddAttendance.departureTime,
                duration = AddAttendance.duration,
                penalty = AddAttendance.penalty,
                remarks = AddAttendance.remarks,

            };
            await MVCDemoDbContext.AddAsync(Attendance);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Attendance");
        }
    }
}




//public class AttendanceController : Controller
//{
//    private readonly MVCDemoDbContext MVCDemoDbContext;

//    public AttendanceController(MVCDemoDbContext MVCDemoDbContext)
//    {
//        this.MVCDemoDbContext = MVCDemoDbContext;
//    }

//    public IConfigurationRoot GetConfiguration()
//    {
//        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//        return builder.Build();
//    }

//    [HttpGet]
//    public IActionResult Attendance(string serviceId)
//    {
//        SqlConnection connection = null;
//        var configuation = GetConfiguration();
//        connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);
//        List<string> locationNames = new List<string>();

//        string query = "SELECT location FROM Location";
//        using (SqlCommand command = new SqlCommand(query, connection))
//        {
//            connection.Open();
//            using (SqlDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    locationNames.Add(reader["location"].ToString());
//                }
//            }
//            connection.Close();
//        }
//        ViewBag.LocationNames = locationNames;

//        return View();
//    }

//    [HttpPost]
//    public async Task<IActionResult> Attendance(AttendanceViewModel AddAttendance)
//    {
//        var Attendance = new Attendance()
//        {
//            location = AddAttendance.location,
//            year = AddAttendance.year,
//            month = AddAttendance.month,
//            day = AddAttendance.day,
//            sId = AddAttendance.sId,
//            designation = AddAttendance.designation,
//            employeeName = AddAttendance.employeeName,
//            arrivalDate = AddAttendance.arrivalDate,
//            departureDate = AddAttendance.departureDate,
//            shiftType = AddAttendance.shiftType,
//            arrivalTime = AddAttendance.arrivalTime,
//            departureTime = AddAttendance.departureTime,
//            duration = AddAttendance.duration,
//            penalty = AddAttendance.penalty,
//            remarks = AddAttendance.remarks,

//        };
//        await MVCDemoDbContext.AddAsync(Attendance);
//        await MVCDemoDbContext.SaveChangesAsync();
//        return RedirectToAction("Attendance");
//    }

//    [HttpGet]
//    public JsonResult GetRegistrationData(string serviceId)
//    {
//        var GetRegistrationData = MVCDemoDbContext.Registration
//    .Where(r => r.serviceId == serviceId)
//             .Select(r => new { Designation = r.designation, Name = r.name })
//             .FirstOrDefault();

//        return Json(GetRegistrationData);
//    }

//}