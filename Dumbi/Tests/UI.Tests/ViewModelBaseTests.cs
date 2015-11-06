using Dumbi.UI;
using NUnit.Framework;
using System.Threading;

namespace UI.Tests
{
    [TestFixture]
    public class ViewModelBaseTests
    {
        [Test]
        public void SetPropertyShouldSetNewValueAndNotifyChange()
        {
            // Arrange
            var handle = new ManualResetEvent(false);

            var sut = new TestViewModel();
            sut.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(sut.TestProperty))
                {
                    handle.Set();
                }
            };

            // Act
            sut.TestProperty = "New Value";

            // Assert
            Assert.AreEqual(sut.TestProperty, "New Value");

            bool changeNotified = handle.WaitOne(2000);
            Assert.IsTrue(changeNotified);
        }
    }

    internal class TestViewModel : DisposableBindableBase
    {
        private string testProperty;

        public string TestProperty
        {
            get { return this.testProperty; }
            set { this.SetProperty(ref this.testProperty, value); }
        }
    }
}
