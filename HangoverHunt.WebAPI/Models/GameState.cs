using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangoverHunt.WebAPI.Models
{
    public static class GameState
    {
        private static Hunt currentHunt = new Hunt();

        public static Hunt CurrentHunt
        {
            get { return currentHunt; }
        }

        public static void RestartHunt()
        {
            currentHunt = new Hunt();
        }
    }
}