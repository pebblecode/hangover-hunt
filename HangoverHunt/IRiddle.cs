using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class Riddle
    {
        public Riddle(string question, string answer)
        {
            this.Question = question;
            _answer = answer;
        }


       public string Question { get; private set; }
        private string _answer;
        public bool CheckAnswer(string answer)
        {
            return answer.Equals(_answer, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
