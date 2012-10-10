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

        [HttpPost]
        public ActionResult AddExactRiddle(string question, string answer)
        {
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle(question, answer));

            return RedirectToAction("Index");
        }


    }
}
