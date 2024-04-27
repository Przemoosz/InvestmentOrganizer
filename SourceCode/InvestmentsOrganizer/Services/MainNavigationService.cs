namespace InvestmentsOrganizer.Services
{
	using Core;

	public class MainNavigationService: ObservableObject, IMainNavigationService
	{
		private readonly Func<Type, ViewModel> _viewModelFactory;
		private ViewModel _currentView;

		public ViewModel CurrentView
		{
			get => _currentView;
			private set
			{
				_currentView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}
		
		public MainNavigationService(Func<Type, ViewModel> viewModelFactory)
		{
			_viewModelFactory = viewModelFactory;
		}
		
		public void NavigateTo<TViewModel>() where TViewModel : ViewModel
		{
			var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
			CurrentView = viewModel;
		}
	}
}