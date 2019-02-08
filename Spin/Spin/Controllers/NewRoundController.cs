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
    }
}