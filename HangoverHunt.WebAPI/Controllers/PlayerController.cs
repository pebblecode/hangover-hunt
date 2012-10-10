using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangoverHunt.WebAPI.Models;

namespace HangoverHunt.WebAPI.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuestion()
        {
            var currentRiddle = GameState.CurrentHunt.CurrentRiddle;
            if (currentRiddle == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            return Json(new { Question = currentRiddle.Question, Type = currentRiddle.GetType().Name }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckResult(string answer)
        {
            var result = GameState.CurrentHunt.CheckAnswer(new TextAnswer(answer));
            return Json(result);
        }
    }
}
