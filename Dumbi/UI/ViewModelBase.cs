namespace Dumbi.UI
{
    /// <summary>
    /// Standard base for all view models
    /// </summary>
    public class ViewModelBase : NavigableViewModelBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance has any pending changes
        /// </summary>
        public bool HasChanges { get; protected set; }
    }
}
