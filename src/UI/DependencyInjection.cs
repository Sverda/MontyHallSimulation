using Application.ViewModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UI.View;

namespace UI
{
    public static class DependencyInjection
    {
        public static void AddViews(this ServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IViewLocator, ViewLocator>();

            services.AddTransient<MenuView>();
            services.AddTransient<SettingsView>();
            services.AddTransient<MainView>();
            services.AddSingleton<MainWindow>();
        }
    }
}
