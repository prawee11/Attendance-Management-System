using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Attendance_Management_System.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public RegistrationController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }     

        [HttpGet]
        public IActionResult Registration()
        {
            SqlConnection connection = null;
            var configuration=GetConfiguration();
            connection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);

            List<string> locationNames = new List<string>();
            List<string> companyNames = new List<string>();

            string query1 = "SELECT DISTINCT location FROM Location";
            string query2 = "SELECT DISTINCT companyName FROM SignUp";

            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
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
                        companyNames.Add(reader2["companyName"].ToString());
                    }
                }
                connection.Close();
            }
            ViewBag.LocationNames = locationNames;
            ViewBag.CompanyNames = companyNames;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel AddRegistration)
        {
            var Registration = new Registration()
            {
                serviceId=AddRegistration.serviceId,
                designation=AddRegistration.designation,
                name=AddRegistration.name,
                location=AddRegistration.location,
                company=AddRegistration.company,      
            };
            await MVCDemoDbContext.AddAsync(Registration);
            await MVCDemoDbContext.SaveChangesAsync();  
            return RedirectToAction("Registration");
        }
    }
}
