using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class Hunt
    {
        private readonly List<IRiddle> riddles = new List<IRiddle>();
        private int currentRiddle = 0;

        public void AddRiddle(IRiddle riddle)
        {
            riddles.Add(riddle);
        }

        public IRiddle GetCurrentRiddle()
        {
            if (currentRiddle < riddles.Count)
                return riddles[currentRiddle];
            else
                return null;
        }

        public bool CheckAnswer(IAnswer answer)
        {
            var result = GetCurrentRiddle().CheckAnswer(answer);
            if (result == true)
                ++currentRiddle;
            return result;
        }
    }
}
