using Application.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using UI.View;

namespace UI
{
    public static class DependencyInjection
    {
        public static void AddViews(this ServiceCollection services)
        {
            services.AddSingleton<IViewLocator, ViewLocator>();
            services.AddSingleton<IUIContext, WPFContext>();

            services.AddTransient<MenuView>();
            services.AddTransient<SettingsView>();
            services.AddTransient<InProgressView>();
            services.AddTransient<SimulationResultView>();
            services.AddTransient<MainView>();
            services.AddTransient<MainWindow>();
        }
    }
}
