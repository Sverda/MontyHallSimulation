using Application.Commands;
using MediatR;

namespace Application.ViewModel
{
    public class MainViewModel
        : CoreViewModel,
        IRequestHandler<ShowSettingsCommand, Unit>,
        IRequestHandler<ReturnToMenuCommand, Unit>
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
            MenuViewModel menuViewModel,
            SettingsViewModel settingsViewModel)
            : base(mediator, viewLocator, serviceProvider)
        {
            this.menuViewModel = menuViewModel;
            this.settingsViewModel = settingsViewModel;

            object? view = menuViewModel.GetView();
            currentView = view
                ?? throw new Exception($"View for main view model doesn't exist {menuViewModel.GetType().FullName}");
        }

        public Task<Unit> Handle(ShowSettingsCommand request, CancellationToken cancellationToken)
        {
            object? view = settingsViewModel.GetView();
            if (view is null)
            {
                return Task.FromResult(Unit.Task.Result);
            }

            CurrentView = view;
            return Task.FromResult(Unit.Task.Result);
        }

        public Task<Unit> Handle(ReturnToMenuCommand request, CancellationToken cancellationToken)
        {
            object? view = menuViewModel.GetView();
            if (view is null)
            {
                return Task.FromResult(Unit.Task.Result);
            }

            CurrentView = view;
            return Task.FromResult(Unit.Task.Result);
        }
    }
}
