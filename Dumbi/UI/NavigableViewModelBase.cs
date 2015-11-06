namespace Dumbi.UI
{
    using Prism.Regions;
    using System.ComponentModel.Composition;

    public class NavigableViewModelBase : DisposableBindableBase, INavigationAware
    {
        [Import]
        protected IRegionManager regionManager;

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
