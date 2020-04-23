using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamMongoDB.Models;
using ExamMongoDB.Models.Repositories;
using ExamMongoDB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ExamMongoDB.Controllers
{
    public class ProgrammeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProgrammeRepository _programmeRepository;
        private readonly IExamRepository _examRepository;
        readonly IMongoCollection<Programme> _userUserCollection;

        public ProgrammeController(ILogger<HomeController> logger,
                                    IProgrammeRepository programmeRepository,
                                    IExamRepository examRepository,
                                    IMongoCollection<Programme> userCollection)
        {
            _logger = logger;
            _programmeRepository = programmeRepository;
            _examRepository = examRepository;
            _userUserCollection = userCollection;
        }




        // GET: Programme
        public ActionResult Index()
        {

            var listProgramme = new ListProgrammeViewModel();
            listProgramme.Programmes = _programmeRepository.GetAllProgrammes();
            var listProgrammes = _programmeRepository.GetAllProgrammes().Select(c => new { c.ProgrammeCode, c.ProgrammeName }).ToList();
            //listProgramme.ProgrammesList = new SelectList(listProgrammes, "ProgrammeCode", "ProgrammeName");


            return View(listProgramme);
        }

        // GET: Programme/Details/5
        public IActionResult Detail(string id)
        {
            var programme = _programmeRepository.GetProgrammeById(id);
            if (programme == null)
            {
                return NotFound();
            }
            return View(programme);
        }

        // GET: Programme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programme/Create
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

        // GET: Programme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Programme/Edit/5
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

        // GET: Programme/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Programme/Delete/5
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