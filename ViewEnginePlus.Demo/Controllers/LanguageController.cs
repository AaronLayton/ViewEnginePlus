﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewEnginePlus.Demo.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Set( string language )
        {
            Session["language"] = language;

            return RedirectToAction("index", "language");
        }
    }
}
