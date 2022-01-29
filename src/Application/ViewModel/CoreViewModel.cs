using MediatR;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Application.ViewModel
{
    public class CoreViewModel : ObservableObject
    {
        protected readonly IMediator mediator;
        private readonly IViewLocator viewLocator;
        private readonly IServiceProvider serviceProvider;

        public CoreViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider)
        {
            this.mediator = mediator;
            this.viewLocator = viewLocator;
            this.serviceProvider = serviceProvider;
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
