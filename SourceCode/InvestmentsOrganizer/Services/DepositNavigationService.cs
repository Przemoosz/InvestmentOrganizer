namespace InvestmentsOrganizer.Services
{
	using InvestmentsOrganizer.Core;

	internal class DepositNavigationService :ObservableObject, IDepositNavigationService
	{
		private readonly Func<Type, ViewModel> _viewModelFactory;
		private ViewModel _currentView;

		public DepositNavigationService(Func<Type, ViewModel> viewModelFactory)
		{
			_viewModelFactory = viewModelFactory;
		}

		public ViewModel CurrentView
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}

		public void NavigateTo<TViewModel>() where TViewModel: ViewModel
		{
			CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
		}
	}
}
