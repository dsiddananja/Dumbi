namespace Dumbi.Core.Processing
{
    /// <summary>
    /// Represents an object that processes the specified command
    /// </summary>
    public interface IProcessorBase
    {
        /// <summary>
        /// Processes the command and returns output, synchronously
        /// </summary>
        void Process();

        /// <summary>
        /// Processes the command and returns output, asynchronously
        /// </summary>
        void ProcessAsync();
    }

    /// <summary>
    /// Represents an object that processes the specified command that returns an output
    /// </summary>
    public interface IProcessorBase<TOut>
    {
        /// <summary>
        /// Processes the command and returns output, synchronously
        /// </summary>
        /// <returns>The output</returns>
        TOut Process();

        /// <summary>
        /// Processes the command and returns output, asynchronously
        /// </summary>
        void ProcessAsync();
    }

    /// <summary>
    /// Represents an object that processes the specified command that takes an input and returns an output
    /// </summary>
    public interface IProcessorBase<TIn, TOut>
    {
        /// <summary>
        /// Processes the command and returns output, synchronously
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>The output</returns>
        TOut Process(TIn input);

        /// <summary>
        /// Processes the command and returns output, asynchronously
        /// </summary>
        /// <param name="input">The input</param>
        void ProcessAsync(TIn input);
    }
}
