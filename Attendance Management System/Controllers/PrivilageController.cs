using Attendance_Management_System.Data;
using Attendance_Management_System.Models.Domain;
using Attendance_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class PrivilageController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public PrivilageController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Privilage()
        {
            return View();
        }

        //Create database insert data
        [HttpPost]
        public async Task<IActionResult> Privilage(PrivilageViewModel AddPrivilage)
        {
            var Privilage = new Privilage()
            {           
                name = AddPrivilage.name,          

            };
            await MVCDemoDbContext.AddAsync(Privilage);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Privilage");
        }
    }
}
