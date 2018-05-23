using NUnit.Framework;

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
    }
}