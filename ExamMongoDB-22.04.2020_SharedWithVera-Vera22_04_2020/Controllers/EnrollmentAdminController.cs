using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo.Model;
using ExamMongoDB.Identity;
using ExamMongoDB.Models;
using ExamMongoDB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExamMongoDB.Controllers
{
    //[Authorize(Roles = "user")]
    //[Authorize]
    //[Route("[controller]/[action]")]
    public class EnrollmentAdminController : Controller
    {
        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<MongoRole> _roleManager;
        readonly IMongoCollection<Student> _userUserCollection;

        public EnrollmentAdminController(
            UserManager<Student> userManager,
            RoleManager<MongoRole> roleManager,
            IMongoCollection<Student> userCollection)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userUserCollection = userCollection;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index(string id) => View(_userManager.Users);


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByNameAsync(id);

            if (user == null) return NotFound();
            ////////////
            var model = new StudentViewModel
            {
                Id = user.Id.ToString(),
                AccessFailedCount = user.AccessFailedCount,
                AuthenticatorKey = user.AuthenticatorKey,
                ConcurrencyStamp = user.ConcurrencyStamp,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                NormalizedEmail = user.NormalizedEmail,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SecurityStamp = user.SecurityStamp,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName,
                Fname = user.Fname,
                Lname = user.Lname,
                //ProgrammeCode = user.Programmes.ProgrammeCode,
                //ProgrammeName = user.Programmes.ProgrammeName,
                //Programmes = user.Programmes,
                ExamEnrollment = user.ExamEnrollment
            };
            return View(model);
            ////////////          
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null) return NotFound();
            var examEnrollmentViewModel = new ExamEnrollmentViewModel();

            user.AccessFailedCount = model.AccessFailedCount;
            user.ConcurrencyStamp = model.ConcurrencyStamp;
            user.Email = model.Email;
            user.EmailConfirmed = model.EmailConfirmed;
            user.LockoutEnabled = model.LockoutEnabled;
            user.LockoutEnd = model.LockoutEnd;
            user.PhoneNumber = model.PhoneNumber;
            user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            user.SecurityStamp = model.SecurityStamp;
            user.TwoFactorEnabled = model.TwoFactorEnabled;
            user.UserName = model.UserName;
            user.Fname = model.Fname;
            user.Lname = model.Lname;
            //user.Programmes.ProgrammeCode = model.ProgrammeCode;
            //user.Programmes.ProgrammeName = model.ProgrammeName;
            //examEnrollmentViewModel.ProgrammeId = user.Programmes.Id;
            //examEnrollmentViewModel.ProgrammeName = user.Programmes.ProgrammeName;
            user.ExamEnrollment = model.ExamEnrollment;

            await _userManager.UpdateAsync(user);

            // await _userUserCollection.ReplaceOneAsync(x=>x.Id == user.Id, user);
            return Redirect("/EnrollmentAdmin");
        }
        ////////////////////////////

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
           // var user = await _userUserCollection.DeleteOneAsync(x=>x.Id == id);
            var user = await _userUserCollection.DeleteOneAsync(x => x.Id ==ObjectId.Parse (id));
            return Redirect("/EnrollmentAdmin");
        }


       
    }
}