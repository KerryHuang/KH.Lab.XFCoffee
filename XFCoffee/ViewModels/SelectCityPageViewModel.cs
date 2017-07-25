using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Events;
using System.Collections.ObjectModel;
using XFCoffee.Services;

namespace XFCoffee.ViewModels
{
	public class SelectCityPageViewModel : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;
		private readonly IEventAggregator _eventAggregator;

		#region 所有縣市 清單
		private ObservableCollection<CityNoteViewModel> _AllCity = new ObservableCollection<CityNoteViewModel>();
		public ObservableCollection<CityNoteViewModel> AllCity
		{
			get { return this._AllCity; }
			set { this.SetProperty(ref this._AllCity, value); }
		}
		#endregion

		public DelegateCommand AllCityItemSelectedCommand { get; set; }
		public CityNoteViewModel AllCitySelected { get; set; }

		public SelectCityPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
		{
			// 取得頁面導航的實作
			_navigationService = navigationService;
			_eventAggregator = eventAggregator;

			AllCityItemSelectedCommand = new DelegateCommand(AllCityItemSelected);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			await Init();
		}

		public async Task Init()
		{
			AllCity.Clear();
			var items = GlobalData.CoffeesRepository.Items.Where(x => x.CityName.Length == 2).Select(x => x.CityName).Distinct().OrderByDescending(x => x);
			foreach (var item in items)
			{
				var fooItem = new CityNoteViewModel
				{
					City = item,
				};
				AllCity.Add(fooItem);
			}
		}

		private void AllCityItemSelected()
		{
			_eventAggregator.GetEvent<FilterEvent>().Publish(AllCitySelected.City);

			//var fooPara = new NavigationParameters();
			//fooPara.Add("City", "AllXXX");
			//_navigationService.GoBack(fooPara);
			_navigationService.GoBackAsync();
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}
