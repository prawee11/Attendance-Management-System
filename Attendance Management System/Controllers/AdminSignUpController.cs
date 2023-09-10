using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Controllers
{
    public class AdminSignUpController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;
        public AdminSignUpController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var AdminSignUp = await MVCDemoDbContext.AdminSignUp.ToListAsync();
            return View(AdminSignUp);
        }

        [HttpGet]
        public IActionResult AdminSignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminSignUp(AdminSignUpViewModel AddAdminSignUp)
        {
            var AdminSignUp = new AdminSignUp()
            {
                userName=AddAdminSignUp.userName,
                contactNumber=AddAdminSignUp.contactNumber,
                password=AddAdminSignUp.password,
            };
            await MVCDemoDbContext.AddAsync(AdminSignUp);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("AdminSignUp");
        }
    }
}
