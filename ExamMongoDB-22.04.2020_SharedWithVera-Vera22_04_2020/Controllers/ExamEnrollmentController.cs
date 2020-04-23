using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ExamMongoDB.Extensions;
using ExamMongoDB.Identity;
using ExamMongoDB.Identity.ManageViewModels;
using ExamMongoDB.Mailing;
using ExamMongoDB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamMongoDB.Models.Repositories;
using ExamMongoDB.Models;
using MongoDB.Bson;

namespace ExamMongoDB.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ExamEnrollmentController : Controller
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IExamRepository _enrollmentRepository;
        private readonly IExamEnrollmentRepository _examEnrollmentRepository;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public ExamEnrollmentController(
          UserManager<Student> userManager,
          SignInManager<Student> signInManager,
          IEmailSender emailSender,
        IExamRepository examRepository,
        IExamEnrollmentRepository examEnrollmentRepository,
          ILogger<ExamEnrollmentController> logger,
          UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
            _enrollmentRepository = examRepository;
            _examEnrollmentRepository = examEnrollmentRepository;
        }

        [TempData]
        public string StatusMessage { get; set; }


        [HttpGet]
        public async Task<IActionResult> Index(ExamEnrollmentViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            model = new ExamEnrollmentViewModel();

            //model.UserName = user.UserName;
            //model.ProgrammeId = user.Programmes.ProgrammeCode;
            //model.ProgrammeName = user.Programmes.ProgrammeName;

            foreach (var examEnrollment in user.ExamEnrollment)
                {
                for (int i = 0; i < 3; i++)
                {
                model.SubjectCode = examEnrollment.SubjectCode;
                model.SubjectName= examEnrollment.SubjectName;
                model.ExamDate = examEnrollment.ExamDate;
                model.RoomId = examEnrollment.RoomId;
                model.Enrolled = examEnrollment.Enrolled;
                }

               
              
                }
                
             

            return View(model);


        }
        ////

        [HttpGet]
        public async Task<IActionResult> Index2(ListExamEnrollmentViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


           
         
          
            var listExam = new ListExamEnrollmentViewModel();
         
            listExam.ExamEnrollmentViewModels = _examEnrollmentRepository.GetAllEnrollment();
          

            return View(listExam);


          

        }



        ////


        public async Task<IActionResult> Index1()
        {
             var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //Edited by Tareq
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(i);
            }

            var model = new ExamEnrollment
            {
                Username = user.UserName,
                SubjectCode = user.ExamEnrollment[0].SubjectCode,
                RoomId = user.ExamEnrollment[0].RoomId,
                Mark = user.ExamEnrollment[0].Mark,
                Enrolled = user.ExamEnrollment[0].Enrolled,
                ExamDate = user.ExamEnrollment[0].ExamDate

            };

            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(ExamEnrollmentViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

          
        //    //////////////////

           
        //    ////////////////////////////

        //    StatusMessage = "Your Exam Enrollment has been updated";
        //    return RedirectToAction(nameof(Index));
        //}

      

    }
}
