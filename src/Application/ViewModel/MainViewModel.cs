using MediatR;

namespace Application.ViewModel
{
    public class MainViewModel : CoreViewModel
    {
        private readonly MenuViewModel menuViewModel;
        private readonly SettingsViewModel settingsViewModel;
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
            SettingsViewModel settingsViewModel)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            this.menuViewModel = menuViewModel;
            this.settingsViewModel = settingsViewModel;

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
    }
}
