namespace InvestmentsOrganizer
{
	using System.Windows;
	using Core;
	using Microsoft.Extensions.DependencyInjection;
	using MVVM.ViewModels;
	using Services;

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceProvider _serviceProvider;

		public App()
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<MainWindow>((provider) => new MainWindow()
			{
				DataContext = provider.GetService<MainViewModel>()
			});
			serviceCollection.AddSingleton<MainViewModel>();
			serviceCollection.AddSingleton<SummaryViewModel>();
			serviceCollection.AddSingleton<DepositViewModel>();
			serviceCollection.AddSingleton<INavigationService, NavigationService>();
			
			serviceCollection.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel) provider.GetService(viewModelType));
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow mainWindow= _serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
			
			base.OnStartup(e);
		}
	}
}