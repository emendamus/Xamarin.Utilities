using ReactiveUI;
using Xamarin.Utilities.Core.Services;

namespace Xamarin.Utilities.Core.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public IReactiveCommand DismissCommand { get; private set; }

        public IViewFor View { get; set; }

        protected BaseViewModel()
        {
            DismissCommand = new ReactiveCommand();
        }

        public TViewModel CreateViewModel<TViewModel>() where TViewModel : class
        {
            return GetService<TViewModel>();
        }

        public void ShowViewModel<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var view = GetService<IViewModelViewService>().GetViewFor(viewModel);
            viewModel.View = view;
            view.ViewModel = viewModel;
            GetService<ITransitionOrchestrationService>().Transition(View, view);
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of the service.</returns>
        protected TService GetService<TService>() where TService : class
        {
            return IoC.Resolve<TService>();
        }
    }
}