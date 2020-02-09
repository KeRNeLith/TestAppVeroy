using NUnit.Framework;
using Tests;

namespace Tests2
{
    [TestFixture]
    internal class TUTests2 : TUBase
    {
        [Test]
        public void TestLib2()
        {
            TestClass testObj = new TestClass();
            Assert.AreEqual(528, testObj.TestMethod());
        }
    }
}