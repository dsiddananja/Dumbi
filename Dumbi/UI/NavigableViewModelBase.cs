namespace Dumbi.UI
{
    using Prism.Regions;
    using System.ComponentModel.Composition;

    /// <summary>
    /// View Model base that has Prism navigation enabled
    /// </summary>
    public class NavigableViewModelBase : DisposableBindableBase, INavigationAware
    {
        /// <summary>
        /// The region manager
        /// </summary>
        [Import]
        protected IRegionManager regionManager;

        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Check interface documentation
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
