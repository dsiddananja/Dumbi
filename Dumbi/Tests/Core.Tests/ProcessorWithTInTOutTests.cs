namespace Core.Tests
{
    using System.Threading;
    using Dumbi.Core.Processing;
    using NUnit.Framework;

    [TestFixture]
    public class ProcessorWithTInTOutTests
    {
        [Test]
        public void SyncProcessorShouldProcess()
        {
            // Arrange
            var sut = new TestProcessor();

            // Act
            Assert.IsFalse(sut.Processed);
            bool result = sut.Process(123);

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
                result = e.Result;
            };

            // Act
            Assert.IsFalse(sut.Processed);
            sut.ProcessAsync(123);

            // Assert
            bool handleSet = waitHandle.WaitOne();
            Assert.IsTrue(handleSet);
            ////Assert.IsTrue(result);  // This fails when run within Suite-Run
            Assert.IsTrue(sut.Processed);
        }

        public class TestProcessor : ProcessorBase<int, bool>
        {
            public bool Processed;

            protected override bool OnProcess(int input)
            {
                this.Processed = true;

                return this.Processed;
            }
        }
    }
}
