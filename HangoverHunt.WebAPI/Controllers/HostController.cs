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

        [HttpPost]
        public ActionResult AddDefaultRiddles()
        {
            GameState.CurrentHunt.AddRiddle(new LocationRiddle("Where are you now?", -0.0782561302, 51.485505247960916, 0.05));
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What's in the fridge?", "Beeer"));
            GameState.CurrentHunt.AddRiddle(new LocationRiddle("This my home I'm black and yellow!", -0.11840343475341797, 51.4847703340828, 0.05));
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What is the food special for tonight in Bee Hive?", "Buffalo Burgers"));
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What is the name of the waitress serving tonight in Bee Hive?", ""));
            GameState.CurrentHunt.AddRiddle(new LocationRiddle("I'm wearing black fur a coat and I lap up my drink.", -0.1209497, 51.488652, 0.05)); //Black Dog
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What is the guest ale swims?", "Wild Swan"));
            GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What is the telephone nubmer of the waitress serving tonight in Black Dog?", ""));
            //
            
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("Which are the 5 most closest pubs near Bee Hive?", ""));
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("Which is the most expensive beer that you can buy at Bee Hive?", ""));
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("How many chairs are at Bee Hive?", ""));
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("How many tables are at Bee Hive?", ""));
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What is the age of the barman at Bee Hive?", ""));
            //GameState.CurrentHunt.AddRiddle(new ExactAnswerRiddle("What brand are the TVs in Bee Hive?", ""));

            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);
            //GameState.CurrentHunt.AddRiddle(new LocationRiddle("", 0.0, 0.0, 0.05);

            return RedirectToAction("Index");
        }
    }
}
