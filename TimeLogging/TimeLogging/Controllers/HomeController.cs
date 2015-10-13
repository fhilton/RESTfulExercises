using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeLogging.Models;
using TimeLogging.DataAccess;

namespace TimeLogging.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TimeLogViewModel> entries = TimeLogService.GetFiveLatestEntries();

            return View(entries);
        }

        // POST: /SubmitTimeLog
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubmitTimeLog(TimeLogViewModel log)
        {
            TimeLogService.SubmitTimeLog(log);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}