﻿using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class TUTests
    {
        [Test]
        public void TestMethod()
        {
			int a = 2;
			int b = 2;
            Assert.AreEqual(a, b);
        }

        [Test]
        public void TestFailMethod()
        {
            int a = 3;
            int b = 4;
            Assert.AreEqual(a, b);
        }

        [Test]
        public void TestLib()
        {
            TestClass testObj = new TestClass { Test = "str" };
            Assert.AreEqual("str", testObj.Test);
        }

    }
}