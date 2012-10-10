using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangoverHunt.WebAPI.Models;
using System.Globalization;

namespace HangoverHunt.WebAPI.Controllers
{
    public class HostController : Controller
    {
        public ActionResult Index()
        {
            return View(GameState.CurrentHunt);
        }

        public ActionResult AddExactRiddle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExactRiddle(string question, string answer)
        {
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle(question, answer));

            return RedirectToAction("Index");
        }

        public ActionResult AddLocationRiddle()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult AddLocationRiddle(string question, string longitude, string latitude)
        {
            GameState.CurrentHunt.AddRiddle(new LocationRiddle(question, 
                                            double.Parse(longitude, CultureInfo.InstalledUICulture),
                                            double.Parse(latitude, CultureInfo.InstalledUICulture), 0.05));

            return RedirectToAction("Index");
        }
    }
}
