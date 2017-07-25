using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFCoffee.Services;
using XFCoffee.Models;
using Plugin.Connectivity;

namespace XFCoffee.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private string _City;
		public string City
		{
			get { return _City; }
			set { SetProperty(ref _City, value); }
		}

		public MainPageViewModel(INavigationService navigationService)
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
			if (parameters.ContainsKey("city"))
				City = (string)parameters["city"];

			await Init();

			var para = new NavigationParameters();
			para.Add("City", "All");
			await _navigationService.NavigateAsync("/HomePage/BusinessSpacePage", para);

		}

		public async Task Init()
		{
			var items = await GlobalData.SystemRecordsRepository.Tables.GetAllAsync();
			if (items.Count == 1 && City != "All")
			{
				await GlobalData.CoffeesRepository.GetAll();
			}
			else
			{
				foreach (var item in items)
				{
					await GlobalData.SystemRecordsRepository.Tables.DeleteAsync(item);
				}

				await GlobalData.SystemRecordsRepository.Tables.InsertAsync(new SystemRecords
				{
					City = "台北"
				});

				await GlobalData.CoffeesRepository.GetInit();
			}

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}

	}
}

