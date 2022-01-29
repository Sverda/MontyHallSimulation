using MediatR;

namespace Application.ViewModel
{
    public class CoreViewModel
    {
        protected readonly IMediator mediator;

        public CoreViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
