namespace Dumbi.Logging
{
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;

    /// <summary>
    /// Check interface documentation
    /// </summary>
    [Export(typeof(ILogger))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EnterpriseLibraryLogger : ILogger
    {
        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        public void LogInfo(string message, string category = null)
        {
            this.LogEntry(message, TraceEventType.Information, category);
        }

        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        public void LogDebug(string message, string category = null)
        {
            this.LogEntry(message, TraceEventType.Verbose, category);
        }

        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        public void LogError(string message, string category = null)
        {
            this.LogEntry(message, TraceEventType.Error, category);
        }

        /// <summary>
        /// Logs the given message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="category"></param>
        private void LogEntry(string message, TraceEventType severity, string category = null)
        {
            var entry = new LogEntry
            {
                Message = message,
                Categories = new List<string>
                {
                    category
                },
                Severity = severity
            };

            Logger.Write(entry);
        }
    }
}
