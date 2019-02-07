using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Models;
using Spin.ViewModels;

namespace Spin.Controllers
{
    public class HomeController : Controller
    {
        //***********Boilerplate****************
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //*************************************

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewRound()
        {
            var courses = _context.CourseModels.ToList();
            var viewModel = new NewRoundViewModel
            {
                CourseModels = courses
            };
            return View(viewModel);
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Groups()
        {
            return View();
        }
    }
}