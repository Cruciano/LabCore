using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
//using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using LabCore.DALayer.Interfaces;
using LabCore.DALayer;
using LabCore.BusinessLayer.Interfaces;
using LabCore.BusinessLayer;
using LabCore.MVVMPresentation;

namespace LabCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private IServiceProvider serviceProvider;

        public App()
        {
         /*   var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider(validateScopes: true);*/
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

    /*    private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(opt =>
                opt.UseSqlServer(ConfigurationManager.ConnectionStrings["labDataBase"].ConnectionString), ServiceLifetime.Singleton);

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IWorkshopService, WorkshopService>();
        }*/

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new ViewModel(new WorkshopService(new UnitOfWork(new AppDBContext())));
            MainWindow = new MyMainWindow() { DataContext = viewModel };
            MainWindow.Show();
        }

    }
}
