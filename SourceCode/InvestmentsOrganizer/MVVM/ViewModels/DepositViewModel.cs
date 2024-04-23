namespace InvestmentsOrganizer.MVVM.ViewModels
{
	using Core;
	using InvestmentsOrganizer.MVVM.ViewModels.Deposit;
	using InvestmentsOrganizer.Services;

	public class DepositViewModel: ViewModel
	{
		private IDepositNavigationService _navigationService;

		public RelayCommand NavigateAddCommand { get; init; }
		public RelayCommand NavigateManageCommand { get; init; }


		public IDepositNavigationService Navigation
		{
			get
			{
				return _navigationService;
			}
			init
			{
				_navigationService = value;
				OnPropertyChanged(nameof(Navigation));
			}
		}

		public DepositViewModel(IDepositNavigationService navigationService)
		{
			Navigation = navigationService;
			NavigateAddCommand = new RelayCommand(OnNavigateAdd, o => true);
			NavigateManageCommand = new RelayCommand(OnNavigateManage, o => true);
		}

		private void OnNavigateAdd(object obj)
		{
			_navigationService.NavigateTo<AddDepositViewModel>();
		}
		private void OnNavigateManage(object obj)
		{
			_navigationService.NavigateTo<ManageDepositViewModel>();
		}


	}
}