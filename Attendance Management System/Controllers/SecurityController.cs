using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Attendance_Management_System.Controllers
{
    public class SecurityController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public SecurityController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Security()
        {
            SqlConnection connection = null;
            var configuation = GetConfiguration();
            connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);
            List<string> locationNames = new List<string>();

            string query = "SELECT location FROM Location";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        locationNames.Add(reader["location"].ToString());
                    }
                }
                connection.Close();
            }
            ViewBag.LocationNames = locationNames;
            return View();
        }

        //Create database insert data
        [HttpPost]
        public async Task<IActionResult>Security(SecurityViewModel AddSecurity)
        {
            var Security = new Security()
            {
                location=AddSecurity.location,
                companyName=AddSecurity.companyName,
                tCount=AddSecurity.tCount,
                available=AddSecurity.available,
                sId=AddSecurity.sId,
            };
            await MVCDemoDbContext.AddAsync(Security);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Security");
        }
    }
}
