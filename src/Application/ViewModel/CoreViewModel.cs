using MediatR;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Application.ViewModel
{
    public class CoreViewModel : ObservableObject
    {
        protected readonly IMediator mediator;
        protected readonly IUIContext uiContext;
        private readonly IViewLocator viewLocator;
        private readonly IServiceProvider serviceProvider;

        public CoreViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext)
        {
            this.mediator = mediator;
            this.viewLocator = viewLocator;
            this.serviceProvider = serviceProvider;
            this.uiContext = uiContext;
        }

        public object? GetView()
        {
            var viewType = viewLocator.GetViewForViewModel(GetType());
            if (viewType is null)
            {
                return null;
            }

            return serviceProvider.GetService(viewType);
        }
    }
}
