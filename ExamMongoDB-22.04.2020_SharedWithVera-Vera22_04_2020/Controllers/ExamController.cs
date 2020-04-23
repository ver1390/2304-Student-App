using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamMongoDB.Models;
using ExamMongoDB.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamMongoDB.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using AspNetCore.Identity.Mongo.Model;
using ExamMongoDB.Identity;

namespace ExamMongoDB.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProgrammeRepository _programmeRepository;
        private readonly IExamRepository _examRepository;
        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<MongoRole> _roleManager;
        readonly IMongoCollection<Student> _userUserCollection;

        public ExamController(ILogger<HomeController> logger,
            IProgrammeRepository programmeRepository,
            IExamRepository examRepository,
             UserManager<Student> userManager,
            RoleManager<MongoRole> roleManager,
            IMongoCollection<Student> userCollection)
        {
            _logger = logger;
            _programmeRepository = programmeRepository;
            _examRepository = examRepository;
            _roleManager = roleManager;
            _userManager = userManager;
            _userUserCollection = userCollection;
        }



        // GET: Exam
        public ActionResult Index()
        { 
          
            //Console.ReadLine();
            var student = new Student();
            var programmeCode = student.Programmes.ProgrammeCode;
            var listExam = new ExamViewModel();
         //   listExam.Exams = _examRepository.GetAllExams();
            listExam.Exams = _examRepository.GetMyExams();
            //var listProgrammes = _programmeRepository.GetAllProgrammes().Select(c => new { c.ProgrammeCode, c.ProgrammeName }).ToList();
            //listExam.ProgrammesList = new SelectList(listProgrammes, "ProgrammeCode", "ProgrammeName");

            //var student = new Student();
            //if (programmeCode == "ITIS")
            //{
               
            //    foreach (var item in programmeCode)
            //    {
            //        listExam.Exams.ToList();
            //    }
            //}

            return View(listExam);
        }

         public ActionResult IndexProgramme()
        { 
          
            //Console.ReadLine();
            var student = new Student();
            var programmeCode = student.Programmes.ProgrammeCode;
            var listExam = new ExamViewModel();
            var progcode = listExam.ProgrammeCode;

            if (programmeCode== progcode)
            {
                listExam.Exams = _examRepository.GetMyExams();
            }
         //   listExam.Exams = _examRepository.GetAllExams();
           
            //var listProgrammes = _programmeRepository.GetAllProgrammes().Select(c => new { c.ProgrammeCode, c.ProgrammeName }).ToList();
            //listExam.ProgrammesList = new SelectList(listProgrammes, "ProgrammeCode", "ProgrammeName");

            //var student = new Student();
            //if (programmeCode == "ITIS")
            //{
               
            //    foreach (var item in programmeCode)
            //    {
            //        listExam.Exams.ToList();
            //    }
            //}

            return View(listExam);
        }





        /////// <summary>
        //List<Programme> FillSelectList()
        //{
        //    var programmes = _programmeRepository.GetAllProgrammes().ToList();
        //    programmes.Insert(0, new Programme { ProgrammeCode = "-1", ProgrammeName = "--- Please select an author ---" });

        //    return programmes;
        //}

        //ExamProgrammeViewModel GetAllProgrammes()
        //{
        //    var vmodel = new ExamProgrammeViewModel
        //    {
        //        Programmes = FillSelectList()
        //    };

        //    return vmodel;
        //}



        //
        public IActionResult SelectProgramme(string category)
        {
            var examsListViewModel = new ExamViewModel();
            var listExam = category != "-1" ? _examRepository.GetExamsByProgrammeCode(category) : _examRepository.GetMyExams();
            if (listExam == null)
            {
                return NotFound();
            }
            examsListViewModel.Exams = listExam;
            var programmesList = _programmeRepository.GetAllProgrammes().Select(r => new { r.ProgrammeCode, r.ProgrammeName }).ToList();
            //examsListViewModel.ProgrammesList = new SelectList(programmesList, "ProgrammeCode", "ProgrammeName");
            examsListViewModel.ProgrammeCode = category;
            return View("Index", examsListViewModel);

        }
        //
        // GET: Exam/Details/5
        public IActionResult Detail(string id)
        {
            var exam = _examRepository.GetExamById(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exam/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}