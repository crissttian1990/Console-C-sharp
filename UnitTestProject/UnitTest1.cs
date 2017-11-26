using System;
using LiquidThinkingTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void Main(string[] args)
        {
            string[] args1 = { "-l", "Maybe the force be with you" };
            MainClass.Main(args1);
        }


        [TestMethod]
        public void MethodW()
        {
            MainClass.methodW("Maybe the force be with you");
        }

        [TestMethod]
        public void MethodL()
        {
            MainClass.methodL("Maybe the force be with you");
        }

        [TestMethod]
        public void MethodV()
        {
            MainClass.methodV("Maybe the force be with you", DateTime.Now);
        }

        [TestMethod]
        public void HelpMethod()
        {
            MainClass.helpMethod();
        }
    }
}
