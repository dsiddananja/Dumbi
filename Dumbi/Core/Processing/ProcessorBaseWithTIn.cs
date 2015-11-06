namespace Dumbi.Core.Processing
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Delegate that handles completion of processing
    /// </summary>
    /// <typeparam name="TOut"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProcessingCompleteEventHandler<TOut>(object sender, ProcessingCompleteEventArgs<TOut> e);

    /// <summary>
    /// Base Processor that can be extended to create custom processor
    /// </summary>
    /// <typeparam name="TOut"></typeparam>
    public abstract class ProcessorBase<TOut> : IProcessorBase<TOut>, IDisposable
    {
        /// <summary>
        /// The background worker
        /// </summary>
        private readonly BackgroundWorker worker = new BackgroundWorker();

        /// <summary>
        /// Indicate whetehr this instance is disposed or not
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Handler for receiving notification when the processing is complete
        /// </summary>
        public event ProcessingCompleteEventHandler<TOut> Complete;

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public ProcessorBase()
        {
            worker.DoWork += this.WorkerSetup;
            worker.RunWorkerCompleted += this.WorkerRunComplete;
        }

        /// <summary>
        /// Processes in a synchronous manner
        /// </summary>
        /// <returns></returns>
        public TOut Process()
        {
            return this.OnProcess();
        }

        /// <summary>
        /// Processes in an asynchronous manner
        /// </summary>
        public void ProcessAsync()
        {
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Cancels processing
        /// </summary>
        public void CancelProcessing()
        {
            this.worker.CancelAsync();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region protected members

        /// <summary>
        /// Custom method that contains the processing logic
        /// </summary>
        /// <returns>Output result after processing</returns>
        protected abstract TOut OnProcess();

        /// <summary>
        /// Disposes this instance
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.worker.IsBusy)
                    {
                        this.worker.CancelAsync();
                    }

                    this.worker.DoWork -= this.WorkerSetup;
                    this.worker.RunWorkerCompleted -= this.WorkerRunComplete;

                    this.worker.Dispose();
                }

                this.disposed = true;
            }
        }

        #endregion

        #region private members

        private void WorkerSetup(object sender, DoWorkEventArgs args)
        {
            TOut result = this.OnProcess();
            args.Result = result;
        }

        private void WorkerRunComplete(object sender, RunWorkerCompletedEventArgs args)
        {
            this.OnProcessComplete(sender, new ProcessingCompleteEventArgs<TOut>(args.Result, args.Error, args.Cancelled));
        }

        /// <summary>
        /// Method that notifies the subscribers when the processing is complete
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The process complete event args</param>
        private void OnProcessComplete(object sender, ProcessingCompleteEventArgs<TOut> e)
        {
            if (!e.Cancelled)
            {
                var handlers = this.Complete;

                if (handlers != null)
                {
                    handlers(this, e);
                }
            }
        }

        #endregion
    }
}
