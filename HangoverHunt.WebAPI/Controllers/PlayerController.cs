using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangoverHunt.WebAPI.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult GetQuestion()
        {
            return Json(new { Question = "What is the answer?" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckResult(string answer)
        {
            return Json(false);
        }
    }
}
