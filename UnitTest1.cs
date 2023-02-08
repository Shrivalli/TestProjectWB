using NUnit.Framework;
using UnitTestingEg;
using Moq;
using System;

namespace TestProjectWB
{
    [TestFixture]
    public class UnitTest1
    {
        int a, b;
        Calculator c;
        Mock<ICalculator> mc;
        [SetUp]
        public void Initmethod()
        {
            c = new Calculator();
            mc = new Mock<ICalculator>();
        }
        [Test]
        public void AddMethodTest()
        {
            //Assign Act Assert
            
            int res = c.add(4, 5);
            Assert.AreEqual(9, res);

        }

        [Test]
        public void CalculateAmtTest()
        {
            float res = c.CalculateAmt(5, 6);
            Assert.AreEqual(30, res);
        }

        [Test]
        public void CheckAmtTestPass()
        {
           mc.Setup(p => p.CalculateAmt(4, 5)).Returns(20);
            bool b = c.checkamt(4, 5);
            Assert.AreEqual(true, b);
        }

        [Test]
        public void CheckAmtTestFail()
        {
            mc.Setup(x => x.CalculateAmt(2, 2)).Returns(4);
            bool actual = c.checkamt(2, 2);
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void CheckAgeTestPass()
        {
            bool res = c.checkAge(4);
            Assert.AreEqual(false, res);
        }

        [Test]
        public void CheckAgeTestFail()
        {
            bool res = c.checkAge(41);
            Assert.AreEqual(true, res);
        }

        [Test]
        public void MessageTest()
        {
            string res = c.message("Radha");
            string msg = "Hello Radha";
            Assert.AreEqual(msg, res);
        }

        [Test]
        public void CheckTempTestPass()
        {
            int k = c.CheckTemp(true);
            Assert.AreEqual(42, k);
            
        }

        [Test]
        public void CheckTempTestFail()
        {
            Assert.Throws<InvalidOperationException>(() => c.CheckTemp(false));
        }

        [TestCase("user_11","secret@user11")]
        [TestCase("user_22", "secret@user22")]
        public void LoginTestPass(string uname,string pwd)
        {
            string res = c.Login(uname, pwd);
            string msg1= "Welcome " + uname;
            Assert.That(msg1, Is.EqualTo(res));
        }

        [TestCase("user_11", "secret@user1")]
        [TestCase("user_22", "secret@user2")]
        public void LoginTestFail(string uname, string pwd)
        {
            string res = c.Login(uname, pwd);
            string msg1 = "Invalid User Id/Password";
            Assert.That(msg1, Is.EqualTo(res));
        }
    }
}

