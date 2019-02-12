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
            newRoundViewModel.CourseModels = courses;

            return View(newRoundViewModel);
        }
        
        public ActionResult ChooseTees(int courseId)
        {
            roundModel.CourseModelId = courseId;
            var tees = _context.TeeModels.Where(c => c.CourseModelId == courseId);
            newRoundViewModel.TeeModels = tees;
            newRoundViewModel.CourseModels = Enumerable.Empty<CourseModel>();
            
            return View(newRoundViewModel);
        }

        public ActionResult SetupRound(int teeId)
        {
            roundModel.TeeModelId = teeId;
            var holes = _context.HoleModels.Where(c => c.TeeModelId == teeId);
            newRoundViewModel.HoleModels = holes;
            newRoundViewModel.TeeModels = Enumerable.Empty<TeeModel>();

            return View(newRoundViewModel);
        }
    }
}