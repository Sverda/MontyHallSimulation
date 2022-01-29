using Application.Commands;
using Application.ViewModel;
using MediatR;

namespace Application.Handlers
{
    public class ShowSettingsCommandHandler : IRequestHandler<ShowSettingsCommand, Unit>
    {
        private readonly MainViewModel mainViewModel;

        public ShowSettingsCommandHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public Task<Unit> Handle(ShowSettingsCommand request, CancellationToken cancellationToken)
        {
            mainViewModel.ChangeContentToSettings();
            return Task.FromResult(Unit.Task.Result);
        }
    }
}
