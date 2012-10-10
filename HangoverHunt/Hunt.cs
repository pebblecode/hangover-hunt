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

        public IRiddle CurrentRiddle
        {
            get
            {
                if (State != HuntState.InProgress)
                    return null;

                return riddles[currentRiddle];
            }
        }

        public bool CheckAnswer(IAnswer answer)
        {
            if (State != HuntState.InProgress)
                throw new InvalidOperationException("Game not in progress.");

            var result = CurrentRiddle.CheckAnswer(answer);
            if (result == true)
                ++currentRiddle;
            return result;
        }

        public IList<RiddleState> RiddleStates
        {
            get
            {
                return riddles.Select(r => new RiddleState(r.Question, riddles.IndexOf(r) < currentRiddle)).ToList();
            }
        }

        public class RiddleState
        {
            public RiddleState(string question, bool answered)
            {
                Question = question;
                Answered = answered;
            }

            public string Question { get; private set; }
            public bool Answered { get; private set; }
        }

        public HuntState State
        {
            get
            {
                if (currentRiddle == riddles.Count)
                    return HuntState.Completed;
                return HuntState.InProgress;
            }
        }
    }
}
