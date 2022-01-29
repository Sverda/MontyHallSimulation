using MediatR;

namespace Application.ViewModel
{
    public class MainViewModel : CoreViewModel
    {
        public MainViewModel(IMediator mediator) : base(mediator)
        {
        }
    }
}
