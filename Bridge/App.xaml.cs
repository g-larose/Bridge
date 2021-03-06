using Bridge.Interfaces;
using Bridge.Navigation;
using Bridge.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bridge
{
    
    public partial class App : Application
    {
        private readonly IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddTransient<INavigator, Navigator>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            
            _host.Start();
            MainWindow = _host?.Services.GetRequiredService<MainWindow>();
            MainWindow?.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host?.Dispose();
            base.OnExit(e);
        }
    }
}
