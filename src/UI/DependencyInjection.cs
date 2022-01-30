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

            services.AddSingleton<MenuView>();
            services.AddSingleton<SettingsView>();
            services.AddSingleton<InProgressView>();
            services.AddSingleton<MainView>();
            services.AddSingleton<MainWindow>();
        }
    }
}
