namespace InvestmentsOrganizer.MVVM.ViewModels
{
	using Core;
	using Deposit;
	using Services;

	public class DepositViewModel: ViewModel
	{
		private IDepositNavigationService _navigationService;
		private bool _isAddSelected;
		private bool _isManageSelected;

		public RelayCommand NavigateAddCommand { get; init; }
		public RelayCommand NavigateManageCommand { get; init; }
		
		public bool IsAddSelected
		{
			get => _isAddSelected;
			set
			{
				_isAddSelected = value;
				OnPropertyChanged(nameof(IsAddSelected));
			}
		}

		public bool IsManageSelected
		{
			get => _isManageSelected;
			set
			{
				_isManageSelected = value;
				OnPropertyChanged(nameof(IsManageSelected));
			}
		}

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
			NavigateAddCommand = new RelayCommand(OnNavigateAdd, _ => true);
			NavigateManageCommand = new RelayCommand(OnNavigateManage, _ => true);
			IsAddSelected = true;
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