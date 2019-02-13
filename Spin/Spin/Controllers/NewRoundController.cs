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
                CourseModels = courses
            };

            return View(viewModel);
        }
        
        public ActionResult ChooseTees(int courseId)
        {
            var tees = _context.TeeModels.Where(c => c.CourseModelId == courseId).ToList();
            var viewModel = new NewRoundViewModel
            {
                TeeModels = tees
            };
            
            return View(viewModel);
        }

        public ActionResult SetupRound(int teeId)
        {
            var holes = _context.HoleModels.Where(c => c.TeeModelId == teeId).ToList();
            var tees = _context.TeeModels.FirstOrDefault(c => c.Id == teeId);
            var tee = tees.Id;
            var course = tees.CourseModelId;
            var roundModel = new RoundModel
            {
                CourseModelId = course,
                TeeModelId = tee,
            };
            var viewModel = new NewRoundViewModel
            {
                HoleModels = holes,
                RoundModel = roundModel,
            };

            return RedirectToAction("PlayingRound", "NewRound");
        }

        public ActionResult PlayingRound(RoundModel roundModel, NewRoundViewModel viewModel)
        {
            return View();
        }
    }
}