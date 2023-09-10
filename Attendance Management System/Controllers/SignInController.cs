using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class SignInController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public SignInController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SignIn(SignInViewModel AddSignIn)
        //{
        //    var SignIn = new SignIn()
        //    {
        //        userName = AddSignIn.userName,
        //        password = AddSignIn.password,
        //    };
        //    await MVCDemoDbContext.AddAsync(SignIn);
        //    await MVCDemoDbContext.SaveChangesAsync();
        //    return RedirectToAction("SignIn");
        //}

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {

            var status = MVCDemoDbContext.SignUp.Where(m => m.companyName == model.userName && m.password == model.password).FirstOrDefault();
            if (status != null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.LoginStatus = 0;
            }
            return View();
        }
        
    }
}
