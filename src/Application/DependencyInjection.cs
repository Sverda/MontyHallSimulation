using Application.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this ServiceCollection services)
        {
            services.AddTransient<MenuViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<MainViewModel>();
        }
    }
}
