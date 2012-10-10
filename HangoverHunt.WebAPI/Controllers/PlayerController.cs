using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangoverHunt.WebAPI.Models;

namespace HangoverHunt.WebAPI.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult Index(bool? result = null)
        {
            var currentRiddle = GameState.CurrentHunt.CurrentRiddle;
            if (currentRiddle == null)
                return View();

            dynamic model = new ExpandoObject();
            model.Question = currentRiddle.Question;
            model.LastResult = result;
            return View(currentRiddle.GetType().Name, model);
        }

        [HttpGet]
        public ActionResult GetQuestion()
        {
            var currentRiddle = GameState.CurrentHunt.CurrentRiddle;
            if (currentRiddle == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            return Json(new { Question = currentRiddle.Question, Type = currentRiddle.GetType().Name }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckResult(string answer)
        {
            var result = GameState.CurrentHunt.CheckAnswer(new TextAnswer(answer));

            if (Request.IsAjaxRequest())
                return Json(result);
            else
                return RedirectToAction("Index", new {result = result});
        }

        public ActionResult CheckResultLocation(double longitude, double latitude)
        {
            var result = GameState.CurrentHunt.CheckAnswer(new LocationAnswer(latitude, longitude));

            if (Request.IsAjaxRequest())
                return Json(result);
            else
                return RedirectToAction("Index", new { result = result });
        }
    }
}
