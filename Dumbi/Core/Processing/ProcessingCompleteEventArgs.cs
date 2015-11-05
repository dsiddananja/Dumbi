namespace Dumbi.Core.Processing
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Represents the result of a processing
    /// </summary>
    public class ProcessingCompleteEventArgs : AsyncCompletedEventArgs
    {
        /// <summary>
        /// Initializes this instance
        /// </summary>
        /// <param name="error"></param>
        /// <param name="cancelled"></param>
        public ProcessingCompleteEventArgs(Exception error, bool cancelled)
            : base(error, cancelled, null)
        {
        }
    }

    /// <summary>
    /// Represents the result of a processing
    /// </summary>
    /// <typeparam name="TOut"></typeparam>
    public class ProcessingCompleteEventArgs<TOut> : ProcessingCompleteEventArgs
    {
        /// <summary>
        /// Initializes this instance
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <param name="cancelled"></param>
        public ProcessingCompleteEventArgs(object result, Exception error, bool cancelled)
            : base(error, cancelled)
        {
            Result = (TOut)result;
        }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <param name="cancelled"></param>
        public ProcessingCompleteEventArgs(TOut result, Exception error, bool cancelled)
            : base(error, cancelled)
        {
            Result = result;
        }

        /// <summary>
        /// The result of processing
        /// </summary>
        public TOut Result { get; private set; }
    }
}
