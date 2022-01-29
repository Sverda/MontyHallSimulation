using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public new static App Current => (App)System.Windows.Application.Current;

        public IServiceProvider Services { get; }

        public App()
        {
            ServiceCollection services = new();
            services.AddApplication();
            services.AddViews();
            Services = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
