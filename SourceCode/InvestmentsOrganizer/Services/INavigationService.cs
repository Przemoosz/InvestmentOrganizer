﻿namespace InvestmentsOrganizer.Services
{
	using Core;

	public interface INavigationService
	{
		ViewModel CurrentView { get; }
		void NavigateTo<T>() where T : ViewModel;
	}
}