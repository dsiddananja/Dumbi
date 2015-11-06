namespace Core.Tests
{
    using Dumbi.Core;
    using NUnit.Framework;

    [TestFixture]
    public class MemberNameTests
    {
        private int testVariable = 0;

        public string TestProperty
        {
            get;
            set;
        }

        [Test]
        public void GetShouldReturnNameOfVariable()
        {
            Assert.AreEqual("testVariable", MemberName.Get(() => this.testVariable));
        }

        [Test]
        public void GetShouldReturnNameOfProperty()
        {
            Assert.AreEqual("TestProperty", MemberName.Get(() => this.TestProperty));
        }
    }
}
