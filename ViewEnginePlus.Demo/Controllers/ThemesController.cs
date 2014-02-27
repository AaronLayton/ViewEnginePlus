using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewEnginePlus.Demo.Controllers
{
    public class ThemesController : Controller
    {
        //
        // GET: /Themes/

        public ActionResult Index()
        {
            // This is trying to default to the /Themes folder?
            return View();
        }

    }
}
