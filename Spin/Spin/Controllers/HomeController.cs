﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewRound()
        {
            return View();
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