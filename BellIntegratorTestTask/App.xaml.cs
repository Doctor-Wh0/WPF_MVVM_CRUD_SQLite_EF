using BellIntegratorTestTask.Core.Models;
using BellIntegratorTestTask.Core.Repositories;
using BellIntegratorTestTask.DAL;
using BellIntegratorTestTask.DAL.Interfaces;
using BellIntegratorTestTask.LogService;
using BellIntegratorTestTask.ViewModels;
using CommonServiceLocator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using Unity;
using Unity.ServiceLocation;

namespace BellIntegratorTestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Exit += this.OnApplicationExit;
            DispatcherUnhandledException += this.OnDispatcherUnhandledException;
            IUnityContainer container = new UnityContainer();

            
            container.RegisterSingleton<LoggerService>();
            container.RegisterSingleton<DbContext, EntitiesDBContext>();


            #region Register Repositories

            container.RegisterSingleton<IRepository<Employee>, Repository<Employee>>();
            container.RegisterSingleton<IRepository<Product>, Repository<Product>>();
            #endregion

            #region Register Business Services
            container.RegisterSingleton<IEmployeeService, EmployeeService>();
            container.RegisterSingleton<IProductService, ProductService>();
            #endregion


            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            container.Resolve<LoggerService>().Info("Application Start");
            app.Show();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
                ServiceLocator.Current.GetInstance<LoggerService>().Info("Application Closed");
                Exit -= this.OnApplicationExit;
                DispatcherUnhandledException -= OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, EventArgs e)
        {
                ServiceLocator.Current.GetInstance<LoggerService>().Error("Unhandled Error Catched in DispatcherUnhandledException "+ e.ToString());
                Exit -= this.OnApplicationExit;
        }
    }
}
