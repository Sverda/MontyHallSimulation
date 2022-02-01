using Application.Repositories;
using Application.ViewModel;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this ServiceCollection services)
        {
            services.AddMediatR(typeof(CoreViewModel));
            services.AddSingleton(typeof(Random));

            services.AddSingleton<IRepository<Settings, int>, SettingsRepository>();

            services.AddTransient<MenuViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<InProgressViewModel>();
            services.AddTransient<SimulationResultViewModel>();
            services.AddSingleton<MainViewModel>();
        }
    }
}
