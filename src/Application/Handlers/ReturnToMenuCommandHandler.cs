using Application.Commands;
using Application.ViewModel;
using MediatR;

namespace Application.Handlers
{
    public class ReturnToMenuCommandHandler : IRequestHandler<ReturnToMenuCommand, Unit>
    {
        private readonly MainViewModel mainViewModel;

        public ReturnToMenuCommandHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public Task<Unit> Handle(ReturnToMenuCommand request, CancellationToken cancellationToken)
        {
            mainViewModel.ChangeContentToMenu();
            return Task.FromResult(Unit.Task.Result);
        }
    }
}
