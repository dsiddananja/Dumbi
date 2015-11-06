namespace Dumbi.Logging
{
    /// <summary>
    /// Represents an object that allows message logging
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the given message at debug level
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        void LogDebug(string message, string category = null);

        /// <summary>
        /// Logs the given message at error level
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        void LogError(string message, string category = null);

        /// <summary>
        /// Logs the given message at information level
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        void LogInfo(string message, string category = null);
    }
}
