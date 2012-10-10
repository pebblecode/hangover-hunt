using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangoverHunt.WebAPI.Models;

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
        public ActionResult AddLocationRiddle(string question, double longitude, double latitude)
        {
            throw new NotImplementedException();
        }
    }
}
