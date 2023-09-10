using Attendance_Management_System.Data;
using Attendance_Management_System.Models;
using Attendance_Management_System.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Controllers
{
    public class SignUpController : Controller
    {
        private readonly MVCDemoDbContext MVCDemoDbContext;

        public SignUpController(MVCDemoDbContext MVCDemoDbContext)
        {
            this.MVCDemoDbContext = MVCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var SignUp = await MVCDemoDbContext.SignUp.ToListAsync();
            return View(SignUp);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel AddSignUp)
        {

            var SignUp = new SignUp()
            {
                companyName = AddSignUp.companyName,
                companyAddress = AddSignUp.companyAddress,
                contactPerson = AddSignUp.contactPerson,
                contactNumber = AddSignUp.contactNumber,
                userName=AddSignUp.userName,
                password = AddSignUp.password,
                status = AddSignUp.status,
            };
            await MVCDemoDbContext.AddAsync(SignUp);
            await MVCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("SignUp");
        }

        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var SignUp = await MVCDemoDbContext.SignUp.FirstOrDefaultAsync(x=>x.id==Id);
            if (SignUp != null)
            {
                var ViewModel = new UpdateSignUpViewModel()
                {
                    id = SignUp.id,
                    companyName = SignUp.companyName,
                    companyAddress = SignUp.companyAddress,
                    contactPerson = SignUp.contactPerson,
                    contactNumber = SignUp.contactNumber,
                    userName=SignUp.userName,
                    password = SignUp.password,
                    status=SignUp.status,
                    
                };
                return await Task.Run(() => View("View",ViewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async  Task<IActionResult> View(UpdateSignUpViewModel model)
        {
            var SignUp = await MVCDemoDbContext.SignUp.FindAsync(model.id);

            if (SignUp != null)
            {
                SignUp.id = model.id;
                SignUp.companyName = model.companyName;
                SignUp.companyAddress = model.companyAddress;
                SignUp.contactPerson = model.contactPerson;
                SignUp.contactNumber = model.contactNumber;
                SignUp.userName = model.userName;
                SignUp.password = model.password;
                SignUp.status = model.status;
                
                await MVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateSignUpViewModel model)
        {
            var SignUp = await MVCDemoDbContext.SignUp.FindAsync(model.id);
            if (SignUp != null)
            {
                MVCDemoDbContext.SignUp.Remove(SignUp);
                await MVCDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
