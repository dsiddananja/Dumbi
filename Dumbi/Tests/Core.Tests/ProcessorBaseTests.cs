namespace Core.Tests
{
    using System.Threading;
    using Dumbi.Core.Processing;
    using NUnit.Framework;

    [TestFixture]
    public class ProcessorBaseTests
    {
        [Test]
        public void SyncProcessorShouldProcess()
        {
            // Arrange
            var sut = new TestProcessor();

            // Act
            Assert.IsFalse(sut.Processed);
            sut.Process();

            // Assert
            Assert.IsTrue(sut.Processed);
        }

        [Test]
        public void AsyncProcessorShouldProcess()
        {
            // Arrange
            var waitHandle = new ManualResetEvent(false);

            var sut = new TestProcessor();
            sut.Complete += delegate
            {
                waitHandle.Set();
            };

            // Act
            Assert.IsFalse(sut.Processed);
            sut.ProcessAsync();

            // Assert
            bool handleSet = waitHandle.WaitOne();
            Assert.IsTrue(handleSet);
            Assert.IsTrue(sut.Processed);
        }

        public class TestProcessor : ProcessorBase
        {
            public bool Processed;

            protected override void OnProcess()
            {
                this.Processed = true;
            }
        }
    }
}
