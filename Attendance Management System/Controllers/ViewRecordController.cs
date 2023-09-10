using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Attendance_Management_System.Controllers
{
    public class ViewRecordController : Controller
    {
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        [HttpGet]
        public IActionResult ViewRecord()
        {
            SqlConnection connection = null;
            var configuation = GetConfiguration();
            connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);          
            
            List<string> locationNames = new List<string>();
            List<string> yearNames = new List<string>();
            List<string> monthNames = new List<string>();
            List<string> dayNames = new List<string>();
            List<string> companyNames = new List<string>();

            string query1 = "SELECT DISTINCT location FROM Attendance";
            string query2 = "SELECT DISTINCT year FROM Attendance";
            string query3 = "SELECT DISTINCT month FROM Attendance";
            string query4 = "SELECT DISTINCT day FROM Attendance";
            string query5 = "SELECT DISTINCT company FROM Attendance";

            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            using (SqlCommand command3 = new SqlCommand(query3, connection))
            using (SqlCommand command4 = new SqlCommand(query4, connection))
            using (SqlCommand command5 = new SqlCommand(query5, connection))
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
                        dayNames.Add(reader4["day"].ToString());
                    }
                }
                using (SqlDataReader reader5 = command5.ExecuteReader())
                {
                    while (reader5.Read())
                    {
                        companyNames.Add(reader5["company"].ToString());
                    }
                }
                connection.Close();
            }
            ViewBag.YearNames = yearNames;
            ViewBag.LocationNames = locationNames;
            ViewBag.MonthNames = monthNames;
            ViewBag.DayNames = dayNames;
            ViewBag.CompanyNames = companyNames;

            return View();
        }
  

    }

}