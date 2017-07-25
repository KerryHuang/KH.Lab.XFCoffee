using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Events;
using System.Collections.ObjectModel;
using XFCoffee.Services;
using System.Threading.Tasks;

namespace XFCoffee.ViewModels
{
	public class BusinessSpacePageViewModel : BindableBase, INavigationAware
	{
		readonly INavigationService _navigationService;
		readonly IEventAggregator _eventAggregator;
		public DelegateCommand RefreshDataCommand { get; set; }
		public DelegateCommand QueryCommand { get; set; }
		public DelegateCommand CoffeeItemSelectedCommand { get; set; }

		#region CoffeeNodeViewModel 清單
		ObservableCollection<CoffeeNodeViewModel> _CoffeeNodes = new ObservableCollection<CoffeeNodeViewModel>();
		public ObservableCollection<CoffeeNodeViewModel> CoffeeNodes
		{
			get { return this._CoffeeNodes; }
			set { this.SetProperty(ref this._CoffeeNodes, value); }
		}
		#endregion

		#region CoffeeSelected
		public CoffeeNodeViewModel CoffeeSelected { get; set; }
		#endregion

		public Action BackToListView;

		string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public BusinessSpacePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
		{
			// 取得頁面導航的實作
			_navigationService = navigationService;
			_eventAggregator = eventAggregator;

			RefreshDataCommand = new DelegateCommand(RefreshData);
			QueryCommand = new DelegateCommand(Query);

			CoffeeItemSelectedCommand = new DelegateCommand(CoffeeItemSelected);

			_eventAggregator.GetEvent<FilterEvent>().Subscribe(FilterHandleEvent);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("title"))
				Title = (string)parameters["title"] + " ...";

			if (parameters.ContainsKey("City"))
			{
				var foo = (string)parameters["City"];
				if (foo == "All")
				{
					await Init();
				}
			}
		}

		public async Task Init()
		{
			CoffeeNodes.Clear();
			var items = await GlobalData.SystemRecordsRepository.Tables.GetAllAsync();
			var it = items.FirstOrDefault();

			var coffees = GlobalData.CoffeesRepository.Items.Where(x => x.CityName == it.City).ToList();

			foreach (var item in coffees)
			{
				var model = new CoffeeNodeViewModel()
				{
					City = item.CityName,
					MRT = item.MRT,
					Name = item.Name,
					Address = item.Address,
					OpenTime = item.Open_Time
				};

				CoffeeNodes.Add(model);
			}
		}

		async void RefreshData()
		{
			var navPara = new NavigationParameters();
			navPara.Add("title", "使用者要求重新整理");
			navPara.Add("city", "All");
			await _navigationService.NavigateAsync("/MainPage", navPara);
		}

		async void Query()
		{
			//await _navigationService.NavigateAsync("SelectCityPage");
			await _navigationService.NavigateAsync("MapPage");
		}

		async void CoffeeItemSelected()
		{
			var CoffeeSelectedSelected = new NavigationParameters();
			CoffeeSelectedSelected.Add("CoffeeSelected", CoffeeSelected);
			await _navigationService.NavigateAsync("BusinessSpaceDetailPage", CoffeeSelectedSelected);
		}

		async void FilterHandleEvent(string obj)
		{
			var items = await GlobalData.SystemRecordsRepository.Tables.GetAllAsync();
			var it = items.FirstOrDefault();
			it.City = obj;
			await GlobalData.SystemRecordsRepository.Tables.UpdateAsync(it);

			CoffeeNodes = new ObservableCollection<CoffeeNodeViewModel>();
			var fooItems = GlobalData.CoffeesRepository.Items.Where(x => x.CityName == obj);
			foreach (var item in fooItems)
			{
				var note = new CoffeeNodeViewModel()
				{
					City = item.CityName,
					MRT = item.MRT,
					Name = item.Name,
					Address = item.Address,
					OpenTime = item.Open_Time
				};

				CoffeeNodes.Add(note);
			}

			BackToListView?.Invoke();

			//if (BackToListView != null)
			//{
			//    BackToListView();
			//}

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}
