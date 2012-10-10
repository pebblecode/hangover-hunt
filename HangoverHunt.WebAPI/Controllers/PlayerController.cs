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
        public ActionResult GetQuestion()
        {
            return Json(new { Question = GameState.CurrentHunt.CurrentRiddle.Question }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckResult(string answer)
        {
            var result = GameState.CurrentHunt.CheckAnswer(new TextAnswer(answer));
            return Json(result);
        }
    }
}
