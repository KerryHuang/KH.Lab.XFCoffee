using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Threading.Tasks;

namespace XFCoffee.ViewModels
{
	public class HomePageViewModel : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public HomePageViewModel(INavigationService navigationService)
		{
			// 取得頁面導航的實作
			_navigationService = navigationService;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("title"))
				Title = (string)parameters["title"] + " ...";

			await Init();
		}

		public async Task Init()
		{
            await Task.Delay(100);
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}