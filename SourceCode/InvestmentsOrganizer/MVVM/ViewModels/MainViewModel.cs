﻿namespace InvestmentsOrganizer.MVVM.ViewModels
{
	using Core;
	using Services;

	public sealed class MainViewModel: ViewModel
	{
		private readonly IMainNavigationService _navigationService;

		public RelayCommand NavigateDepositCommand { get; init; }
		public RelayCommand NavigateSummaryCommand { get; init; }
		public RelayCommand CloseAppCommand { get; init; }


		public IMainNavigationService Navigation
		{
			get => _navigationService;
			init
			{
				_navigationService = value;
				OnPropertyChanged(nameof(Navigation));
			}
		}

		public MainViewModel(IMainNavigationService navigationService)
		{
			Navigation = navigationService;
			NavigateSummaryCommand = new RelayCommand(OnNavigateSummary, o => true);
			NavigateDepositCommand = new RelayCommand(OnNavigateDeposit, o => true);
			CloseAppCommand = new RelayCommand(OnAppClose, o => true);
		}

		private void OnAppClose(object obj)
		{
			Environment.Exit(0);
		}



		private void OnNavigateDeposit(object obj)
		{
			_navigationService.NavigateTo<DepositViewModel>();
		}
		private void OnNavigateSummary(object obj)
		{
			_navigationService.NavigateTo<SummaryViewModel>();
		}
		
	}
}