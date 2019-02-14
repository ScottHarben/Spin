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
            var tees = _context.TeeModels.Where(c => c.CourseModelId == courseId);
            var viewModel = new NewRoundViewModel
            {
                TeeModels = tees
            };
            
            return View(viewModel);
        }

        public ActionResult PlayingRound(int teeId)
        {
            var holes = _context.HoleModels.Where(c => c.TeeModelId == teeId);
            var tees = _context.TeeModels.FirstOrDefault(c => c.Id == teeId);
            var course = tees.CourseModelId;
            var roundModel = new RoundModel()
            {
                CourseModelId = course,
                TeeModelId = tees.Id,
            };
            var viewModel = new NewRoundViewModel
            {
                HoleModels = holes,
                RoundModel = roundModel,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Test(NewRoundViewModel viewModel)
        {
            List<string> roundList = new List<string>();
            roundList.Add(viewModel.RoundModel.CourseModelId.ToString());
            roundList.Add(viewModel.RoundModel.TeeModelId.ToString());
            roundList.Add(viewModel.RoundModel.DateTime.ToString("yyyy MMMM dd"));
            return Content(roundList[2]);
        }
    }
}