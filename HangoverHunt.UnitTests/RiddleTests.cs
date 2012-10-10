using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangoverHunt.UnitTests
{
    [TestClass]
    public class RiddleTests
    {
        [TestMethod]
        public void CheckAnswer_42_Correct()
        {
            IRiddle riddle = new ExactAnswerRiddle("What is the answer?", "42");

            Assert.AreEqual("What is the answer?", riddle.Question);
            var result = riddle.CheckAnswer(new TextAnswer("42"));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckAnswer_10_Incorrect()
        {
            IRiddle riddle = new ExactAnswerRiddle("What is the answer?", "42");

            var result = riddle.CheckAnswer(new TextAnswer("10"));
            Assert.IsFalse(result);
        }
    }
}
