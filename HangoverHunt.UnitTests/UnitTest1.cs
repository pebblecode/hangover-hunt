using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangoverHunt.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRiddle riddle = new ExactAnswerRiddle("What is the answer?", "42");

            Assert.AreEqual("What is the answer?", riddle.Question);
            var result = riddle.CheckAnswer(new TextAnswer("42"));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            IRiddle riddle = new ExactAnswerRiddle("What is the answer?", "42");

            var result = riddle.CheckAnswer(new TextAnswer("10"));
            Assert.IsFalse(result);
        }
    }
}
