using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UI.View;

namespace UI
{
    public static class DependencyInjection
    {
        public static void AddUI(this ServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Views
            services.AddSingleton<MainView>();
            services.AddSingleton<SettingsView>();
            services.AddSingleton<MainWindow>();
        }
    }
}
