using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class ExactAnswerRiddle : IRiddle
    {
        private readonly string _answer;

        public ExactAnswerRiddle(string question, string answer)
        {
            _answer = answer;
            this.Question = question;
        }

        public string Question { get; private set; }

        public bool CheckAnswer(IAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer", "answer is null.");
            if (answer.GetType() != typeof(TextAnswer))
                throw new InvalidOperationException("Exact text answer required.");

            return CheckAnswer((TextAnswer)answer);
        }

        public bool CheckAnswer(TextAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer", "answer is null.");

            return _answer.Equals(answer.AnswerText, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
