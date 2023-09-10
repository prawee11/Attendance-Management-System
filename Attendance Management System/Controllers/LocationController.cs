using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class LocationController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public LocationController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Location()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Location(LocationViewModel AddLocation)
        {
            var Location = new Location()
            {
                location = AddLocation.location,
                status=AddLocation.status,

            };
            await MVCDemoDbContext.AddAsync(Location);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Location");
        }
    }
}
