﻿using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class MenuViewModel : CoreViewModel
    {
        public IAsyncRelayCommand SettingsCommand { get; }

        public MenuViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider)
            : base(mediator, viewLocator, serviceProvider)
        {
            SettingsCommand = new AsyncRelayCommand(ShowSettings);
        }

        private async Task ShowSettings()
        {
            await mediator.Send(new ShowSettingsCommand());
        }
    }
}
