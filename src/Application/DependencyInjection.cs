using Application.ViewModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this ServiceCollection services)
        {
            services.AddMediatR(typeof(CoreViewModel));

            services.AddTransient<MenuViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<InProgressViewModel>();
            services.AddTransient<SimulationResultViewModel>();
            services.AddSingleton<MainViewModel>();
        }
    }
}
