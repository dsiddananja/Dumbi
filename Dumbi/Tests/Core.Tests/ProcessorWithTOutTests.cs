namespace Core.Tests
{
    using System.Threading;
    using Dumbi.Core.Processing;
    using NUnit.Framework;

    [TestFixture]
    public class ProcessorWithTOutTests
    {
        [Test]
        public void SyncProcessorShouldProcess()
        {
            // Arrange
            var sut = new TestProcessor();

            // Act
            Assert.IsFalse(sut.Processed);
            bool result = sut.Process();

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(sut.Processed);
        }

        [Test]
        public void AsyncProcessorShouldProcess()
        {
            // Arrange
            var waitHandle = new ManualResetEvent(false);
            bool result = false;

            var sut = new TestProcessor();
            sut.Complete += (o, e) =>
            {
                waitHandle.Set();
                result = (bool)e.Result;
            };

            // Act
            Assert.IsFalse(sut.Processed);
            sut.ProcessAsync();

            // Assert
            bool handleSet = waitHandle.WaitOne();
            Assert.IsTrue(handleSet);
            Assert.IsTrue(result);
            Assert.IsTrue(sut.Processed);
        }

        public class TestProcessor : ProcessorBase<bool>
        {
            public bool Processed;

            protected override bool OnProcess()
            {
                return this.Processed = true;
            }
        }
    }
}
