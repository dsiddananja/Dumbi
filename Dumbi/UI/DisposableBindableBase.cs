namespace Dumbi.UI
{
    using Prism.Mvvm;
    using System;

    /// <summary>
    /// Represents the base for all view models
    /// </summary>
    public abstract class DisposableBindableBase : BindableBase, IDisposable
    {
        private bool disposed;

        /////// <summary>
        /////// Saves the given value against the specified property
        /////// </summary>
        /////// <typeparam name="T">the type of the property</typeparam>
        /////// <param name="storage">The backing variable</param>
        /////// <param name="value">New value</param>
        /////// <param name="propertyExpression">Expression representing the property</param>
        /////// <returns></returns>
        ////protected virtual bool SetProperty<T>(ref T storage, T value, Expression<Func<T>> propertyExpression)
        ////{
        ////    ////if (!object.Equals(storage, value))
        ////    ////{
        ////    ////    storage = value;
        ////    ////    this.RaisePropertyChanged(MemberName.Get(propertyExpression));

        ////    ////    return true;
        ////    ////}

        ////    ////return false;

        ////    return this.SetProperty(ref storage, value, nameof(propertyExpression));
        ////}

        /// <summary>
        /// Cleans up this instance
        /// </summary>
        /// <param name="disposing">Indicates whether in dispose mode or not</param>
        protected virtual void Disposing(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Cleansup this instance
        /// </summary>
        public void Dispose()
        {
            this.Disposing(true);
            GC.SuppressFinalize(this);
        }
    }
}
