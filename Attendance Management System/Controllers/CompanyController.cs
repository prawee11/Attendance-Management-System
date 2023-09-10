using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using static Azure.Core.HttpHeader;
using static System.Collections.Specialized.BitVector32;

namespace Attendance_Management_System.Controllers
{
    public class CompanyController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public CompanyController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        [HttpGet]
        public IActionResult Company()
        {
            SqlConnection connection = null;
            var configuation = GetConfiguration();
            connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);

            List<string> companyNames = new List<string>();
            List<string> company = new List<string>();

            string query = "SELECT DISTINCT companyName FROM SignUp WHERE status='1'";
            string query1 = "SELECT DISTINCT companyName FROM SignUp WHERE status='0'";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        companyNames.Add(reader["companyName"].ToString());
                    }
                }
                using (SqlDataReader reader1 = command1.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        company.Add(reader1["companyName"].ToString());
                    }
                }
                connection.Close();
            }
            ViewBag.CompanyNames = companyNames;
            ViewBag.Company = company;
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Company(CompanyViewModel AddCompany)
        //{
        //    var existingCompany = await MVCDemoDbContext.SignUp.FirstOrDefaultAsync(c => c.companyName == AddCompany.name);
        //    if (existingCompany != null)
        //    {
        //        ModelState.AddModelError("name", "Company name already exists.");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var Company = new Company()
        //        {
        //            name = AddCompany.name,
        //            status = AddCompany.status,
        //        };
        //        await MVCDemoDbContext.AddAsync(Company);
        //        await MVCDemoDbContext.SaveChangesAsync();
        //        return RedirectToAction("Company");
        //    }

        //    // If the model state is not valid, re-populate the ViewBag and return the view
        //    SqlConnection connection = null;
        //    var configuation = GetConfiguration();
        //    connection = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("MVCDemoConnectionString").Value);

        //    List<string> companyNames = new List<string>();
        //    List<string> company = new List<string>();

        //    string query = "SELECT DISTINCT name FROM Company WHERE status='1'";
        //    string query1 = "SELECT DISTINCT name FROM Company WHERE status='0'";

        //    using (SqlCommand command = new SqlCommand(query, connection))
        //    using (SqlCommand command1 = new SqlCommand(query1, connection))
        //    {
        //        connection.Open();

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                companyNames.Add(reader["name"].ToString());
        //            }
        //        }
        //        using (SqlDataReader reader1 = command1.ExecuteReader())
        //        {
        //            while (reader1.Read())
        //            {
        //                company.Add(reader1["name"].ToString());
        //            }
        //        }
        //        connection.Close();
        //    }

        //    ViewBag.CompanyNames = companyNames;
        //    ViewBag.Company = company;
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> DisableCompany(string company)
        {
            if (!string.IsNullOrEmpty(company))
            {
                var companyToUpdate = await MVCDemoDbContext.SignUp.FirstOrDefaultAsync(c => c.companyName == company);
                if (companyToUpdate != null)
                {
                    companyToUpdate.status = 0;
                    await MVCDemoDbContext.SaveChangesAsync();
                }
            }

            return RedirectToAction("Company");
        }

        [HttpPost]
        public async Task<IActionResult> EnableCompany(string company1)
        {
            if (!string.IsNullOrEmpty(company1))
            {
                var companyToUpdate = await MVCDemoDbContext.SignUp.FirstOrDefaultAsync(c => c.companyName == company1);
                if (companyToUpdate != null)
                {
                    companyToUpdate.status = 1;
                    await MVCDemoDbContext.SaveChangesAsync();
                }
            }

            return RedirectToAction("Company");
        }
    }       
}


