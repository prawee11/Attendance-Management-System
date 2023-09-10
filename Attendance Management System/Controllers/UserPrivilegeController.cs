using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Attendance_Management_System.Controllers
{
    public class UserPrivilegeController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public UserPrivilegeController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult UserPrivilege()
        {
            SqlConnection connection = null;
            var configuation = GetConfiguration();
            connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);
            List<string> privilegeNames = new List<string>();

           // using (SqlConnection connection = new SqlConnection("MVCDemoConnectionString")) /*----error-----*/
           // {
                string query = "SELECT name FROM Privilage";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            privilegeNames.Add(reader["name"].ToString());
                        }
                    }
                    connection.Close();
                }
           // }
            ViewBag.PrivilegeNames = privilegeNames;
            return View();
        }
        //Create database insert data
        [HttpPost]
        public async Task<IActionResult> UserPrivilege(UserPrivilegeViewModel AddUserPrivilege)
        {
            var UserPrivilege = new UserPrivilege()
            {
                userId = AddUserPrivilege.userId,
                level = AddUserPrivilege.level,

            };
            await MVCDemoDbContext.AddAsync(UserPrivilege);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("UserPrivilege");
        }
    }
}
