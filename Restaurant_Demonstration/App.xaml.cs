using Microsoft.Extensions.DependencyInjection;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.ViewModel;
using System.Windows;

namespace Restaurant_Demonstration
{

    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfiguerServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfiguerServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<LayoutViewModel>();
            services.AddTransient<ManagerViewModel>();
            services.AddTransient<ProductsViewModel>();

            services.AddTransient<ILayoutDataProvider.LayoutDataProvider>();
            services.AddTransient<ICustomersDataProvider, CustomersDataProvider>();
            services.AddTransient<IProductsDataProvider, ProductsDataProvider>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
