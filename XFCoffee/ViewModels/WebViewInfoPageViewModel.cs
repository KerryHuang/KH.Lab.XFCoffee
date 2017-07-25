using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace XFCoffee.ViewModels
{
	public class WebViewInfoPageViewModel : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;

		private WebInfoNodeViewModel _WebInfoNodeViewModel;
		public WebInfoNodeViewModel WebInfoNodeViewModel
		{
			get { return _WebInfoNodeViewModel; }
			set { SetProperty(ref _WebInfoNodeViewModel, value); }
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public WebViewInfoPageViewModel(INavigationService navigationService)
		{
			// 取得頁面導航的實作
			_navigationService = navigationService;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("WebInfoNodeViewModel"))
			{
				WebInfoNodeViewModel = parameters["WebInfoNodeViewModel"] as WebInfoNodeViewModel;
			}
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}
