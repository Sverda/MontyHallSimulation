using MediatR;

namespace Application.ViewModel
{
    public class MainViewModel : CoreViewModel
    {
        private readonly MenuViewModel menuViewModel;
        private readonly SettingsViewModel settingsViewModel;
        private readonly InProgressViewModel inProgressViewModel;
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
            IUIContext uiContext,
            MenuViewModel menuViewModel,
            SettingsViewModel settingsViewModel,
            InProgressViewModel inProgressViewModel)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            this.menuViewModel = menuViewModel;
            this.settingsViewModel = settingsViewModel;
            this.inProgressViewModel = inProgressViewModel;
            object? view = menuViewModel.GetView();
            currentView = view
                ?? throw new Exception($"View for main view model doesn't exist {menuViewModel.GetType().FullName}");
        }

        public void ChangeContentToSettings()
        {
            object? view = settingsViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }

        public void ChangeContentToMenu()
        {
            object? view = menuViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }

        public void ChangeContentToInProgress()
        {
            object? view = inProgressViewModel.GetView();
            if (view is null)
            {
                return;
            }

            uiContext.BeginInvoke(() => CurrentView = view);
        }
    }
}
