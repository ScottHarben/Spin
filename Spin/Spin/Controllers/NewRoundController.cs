using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Models;
using Spin.ViewModels;
using WebGrease.Css.ImageAssemblyAnalysis.LogModel;

namespace Spin.Controllers
{
    public class NewRoundController : Controller
    {
        // GET: NewRound

        //***********************************************************
        //*                      BOILER PLATE                       *
        //***********************************************************
        private ApplicationDbContext _context;

        public NewRoundController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //***********************************************************
        //*                     SETUP                               *
        //***********************************************************

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
            var holePar = _context.HoleModels.FirstOrDefault(c => c.Id == holeId).HolePar;

            var roundModel = new RoundModel
            {
                CourseModelId = course,
                TeeModelId = teeId,
                HoleModelId = holeId,
            };

            var viewModel = new NewRoundViewModel
            {
                HoleModels = _context.HoleModels.Where(c => c.TeeModelId == teeId),
                RoundModel = roundModel,
            };

            TempData["courseId"] = course;
            TempData["teeId"] = teeId;
            TempData["holeId"] = holeId;
            TempData["holeCount"] = 1;

            if (holePar == 3)
                return RedirectToAction("Green", "NewRound");

            return RedirectToAction("Fairway", "NewRound");
        }


        //***********************************************************
        //*                     FAIRWAY                             *
        //***********************************************************

        public ActionResult Fairway()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;
        
            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;
        
            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var roundModel = new RoundModel
            {
                CourseModelId = courseId,
                TeeModelId = teeId,
                HoleModelId = holeId,
            };

            var viewModel = new NewRoundViewModel
            {
                HoleModels = _context.HoleModels.Where(c => c.Id == roundModel.HoleModelId),
                RoundModel = roundModel,
            };

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult FairwayHit()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            TempData["fairway"] = 1;

            return RedirectToAction("Green","NewRound");
        }

        [HttpPost]
        public ActionResult FairwayMissed()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            TempData["fairway"] = 0;

            return RedirectToAction("Green", "NewRound");
        }


        //***********************************************************
        //*                     GREEN                               *
        //***********************************************************

        public ActionResult Green()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var roundModel = new RoundModel
            {
                CourseModelId = courseId,
                TeeModelId = teeId,
                HoleModelId = holeId,
            };
            
            var viewModel = new NewRoundViewModel
            {
                HoleModels = _context.HoleModels.Where(c => c.Id == roundModel.HoleModelId),
                RoundModel = roundModel,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GreenHit()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            TempData["green"] = 1;

            return RedirectToAction("Putts", "NewRound");
        }

        [HttpPost]
        public ActionResult GreenMissed()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            TempData["green"] = 0;

            return RedirectToAction("Putts", "NewRound");
        }


        //***********************************************************
        //*                     PUTTS                               *
        //***********************************************************

        public ActionResult Putts()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var roundModel = new RoundModel
            {
                CourseModelId = courseId,
                TeeModelId = teeId,
                HoleModelId = holeId,
            };

            var viewModel = new NewRoundViewModel
            {
                HoleModels = _context.HoleModels.Where(c => c.Id == roundModel.HoleModelId),
                RoundModel = roundModel,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ZeroPutt()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            TempData["putts"] = 0;

            return RedirectToAction("Score", "NewRound");
        }

        [HttpPost]
        public ActionResult OnePutt()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            TempData["putts"] = 1;

            return RedirectToAction("Score", "NewRound");
        }

        [HttpPost]
        public ActionResult TwoPutt()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            TempData["putts"] = 2;

            return RedirectToAction("Score", "NewRound");
        }

        [HttpPost]
        public ActionResult ThreePutt()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            TempData["putts"] = 3;

            return RedirectToAction("Score", "NewRound");
        }


        //***********************************************************
        //*                     SCORE                               *
        //***********************************************************

        public ActionResult Score()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            var roundModel = new RoundModel
            {
                CourseModelId = courseId,
                TeeModelId = teeId,
                HoleModelId = holeId,
            };

            var viewModel = new NewRoundViewModel
            {
                HoleModels = _context.HoleModels.Where(c => c.Id == roundModel.HoleModelId),
                RoundModel = roundModel,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Albatross()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = -3;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Eagle()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = -2;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Birdie()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = -1;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Par()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = 0;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Bogie()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = 1;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Double()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = 2;

            return RedirectToAction("NextHole", "NewRound");
        }

        [HttpPost]
        public ActionResult Triple()
        {
            var holeCount = Convert.ToInt32(TempData["holeCount"]);
            TempData["holeCount"] = holeCount;

            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;

            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;

            var holeId = Convert.ToInt32(TempData["holeId"]);
            TempData["holeId"] = holeId;

            var fairway = Convert.ToInt32(TempData["fairway"]);
            TempData["fairway"] = fairway;

            var green = Convert.ToInt32(TempData["green"]);
            TempData["green"] = green;

            var putts = Convert.ToInt32(TempData["putts"]);
            TempData["putts"] = putts;

            TempData["score"] = 3;

            return RedirectToAction("NextHole", "NewRound");
        }


        //***********************************************************
        //*                     NEXT                                *
        //***********************************************************

        public ActionResult NextHole()
        {
            byte holePar;
            var holeCount = Convert.ToByte(TempData["holeCount"]);
            holeCount++;
            TempData["holeCount"] = holeCount;

            if (holeCount == 19)
                return Content("Round Over");
            
            var courseId = Convert.ToInt32(TempData["courseId"]);
            TempData["courseId"] = courseId;
        
            var teeId = Convert.ToInt32(TempData["teeId"]);
            TempData["teeId"] = teeId;
        
            var holeId = Convert.ToInt32(TempData["holeId"]);
            var holeNum = _context.HoleModels.FirstOrDefault(c => c.Id == holeId).HoleNumber;
            if (holeNum == 18)
            {
                TempData["holeId"] = _context.HoleModels.FirstOrDefault(c => c.TeeModelId == teeId && c.HoleNumber == 1).Id;
                holePar = _context.HoleModels.FirstOrDefault(c => c.TeeModelId == teeId && c.HoleNumber == 1).HolePar;
            }
            else
            {
                holeId++;
                TempData["holeId"] = holeId;
                holePar = _context.HoleModels.FirstOrDefault(c => c.Id == holeId).HolePar;
            }

            if (holePar == 3)
                return RedirectToAction("Green", "NewRound");

            return RedirectToAction("Fairway", "NewRound");
        }
    }
}