using Application.Commands;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class SettingsViewModel : CoreViewModel
    {
        private readonly IRepository<Settings, int> repository;
        private readonly Settings settingsEntity;
        private string seed;
        private int iterations;
        private string iterationMessage;
        private bool iterationMessageVisibility;

        public string Seed
        {
            get => seed;
            set
            {
                settingsEntity.Seed = value;
                repository.Update(settingsEntity);
                seed = value;
                OnPropertyChanged();
            }
        }

        public int Iterations
        {
            get => iterations;
            set
            {
                try
                {
                    settingsEntity.Iterations = value;
                    repository.Update(settingsEntity);
                    IterationMessageVisibility = false;
                }
                catch (ArgumentException e)
                {
                    IterationMessageVisibility = true;
                    IterationMessage = e.Message;
                }
                finally
                {
                    iterations = value;
                    OnPropertyChanged();
                }
            }
        }
        public string IterationMessage
        {
            get => iterationMessage;
            set
            {
                iterationMessage = value;
                OnPropertyChanged();
            }
        }
        public bool IterationMessageVisibility
        {
            get => iterationMessageVisibility;
            set
            {
                iterationMessageVisibility = value;
                OnPropertyChanged();
            }
        }

        public IAsyncRelayCommand ReturnToMenuCommand { get; }

        public SettingsViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext,
            IRepository<Settings, int> repository)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            ReturnToMenuCommand = new AsyncRelayCommand(ReturnToMenu);
            this.repository = repository;
            settingsEntity = repository.GetById(0);
            seed = settingsEntity.Seed;
            iterations = settingsEntity.Iterations;
        }

        private async Task ReturnToMenu()
        {
            await mediator.Send(new ReturnToMenuCommand());
        }
    }
}