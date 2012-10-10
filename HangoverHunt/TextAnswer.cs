using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class TextAnswer : IAnswer
    {
        public TextAnswer(string answer)
        {
            AnswerText = answer;
        }

        public string AnswerText { get; private set; }
    }
}
