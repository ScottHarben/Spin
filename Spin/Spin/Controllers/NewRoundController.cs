using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Models;
using Spin.ViewModels;

namespace Spin.Controllers
{
    public class NewRoundController : Controller
    {
        // GET: NewRound

        //***********Boilerplate****************
        private ApplicationDbContext _context;

        public NewRoundController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //*************************************
        
        public ActionResult ChooseCourse()
        {
            var courses = _context.CourseModels.ToList();
            var viewModel = new NewRoundViewModel
            {
                CourseModels = courses,
            };

            return View(viewModel);
        }
        
        public ActionResult ChooseTees(int courseId)
        {
            var tees = _context.TeeModels.Where(c => c.CourseModelId == courseId);
            var viewModel = new NewRoundViewModel
            {
                TeeModels = tees,
            };
            
            return View(viewModel);
        }

        public ActionResult ChooseStartingHole(int teeId)
        {
            var holes = _context.HoleModels.Where(c => c.TeeModelId == teeId);
            var viewModel = new NewRoundViewModel
            {
                HoleModels = holes,
            };

            TempData["teeId"] = teeId;

            return View(viewModel);
        }

        public ActionResult SetupRound(int holeId)
        {
            var teeId = Convert.ToInt32(TempData["teeId"]);
            var tees = _context.TeeModels.FirstOrDefault(c => c.Id == teeId);
            var course = tees.CourseModelId;

            TempData["courseId"] = course;
            TempData["teeId"] = tees.Id;
            TempData["startingHoleId"] = holeId;

            return RedirectToAction("FirstHole","NewRound");
        }

        public ActionResult FirstHole()
        {
            var roundModel = new RoundModel();

            if (TempData["courseId"] != null)
            {
                var courseId = Convert.ToInt32(TempData["courseId"]);
                roundModel.CourseModelId = courseId;
                TempData["courseId"] = courseId;
            }

            if (TempData["teeId"] != null)
            {
                var teeId = Convert.ToInt32(TempData["teeId"]);
                roundModel.TeeModelId = teeId;
                TempData["teeId"] = teeId;
            }

            if (TempData["StartingHoleId"] != null)
            {
                var StartingHoleId = Convert.ToInt32(TempData["StartingHoleId"]);
                roundModel.HoleModelId = StartingHoleId;
                TempData["holeId"] = StartingHoleId;
            }
            
            return View();
        }
    }
}