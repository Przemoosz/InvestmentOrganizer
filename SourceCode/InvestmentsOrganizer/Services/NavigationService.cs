namespace InvestmentsOrganizer.Services
{
	using Core;

	public class NavigationService: ObservableObject, INavigationService
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
		
		public NavigationService(Func<Type, ViewModel> viewModelFactory)
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