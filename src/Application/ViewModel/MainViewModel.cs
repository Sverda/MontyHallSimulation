using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ViewModel
{
    public class MainViewModel : CoreViewModel
    {
        private object currentView;

        public object CurrentView
        {
            get => currentView;
            private set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            ChangeContentToMenu();
        }

        public void ChangeContentToSettings()
        {
            var settingsViewModel = serviceProvider.GetRequiredService<SettingsViewModel>();
            object? view = settingsViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }

        public void ChangeContentToMenu()
        {
            var menuViewModel = serviceProvider.GetRequiredService<MenuViewModel>();
            object? view = menuViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }

        public void ChangeContentToInProgress()
        {
            var inProgressViewModel = serviceProvider.GetRequiredService<InProgressViewModel>();
            object? view = inProgressViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }

        public void ChangeContentToSimulationResult(SimulationResultViewModel viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            object? view = viewModel?.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.SetViewContext(view, viewModel);
            uiContext.BeginInvoke(() => CurrentView = view);
        }
    }
}
