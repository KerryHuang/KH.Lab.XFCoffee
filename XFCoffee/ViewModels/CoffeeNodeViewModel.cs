using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using XFCoffee.Services;
using Plugin.Share;
using Plugin.ExternalMaps;

namespace XFCoffee.ViewModels
{
	public class CoffeeNodeViewModel : BindableBase
	{
		public DelegateCommand<CoffeeNodeViewModel> GetMapommand { get; set; }
		public DelegateCommand<CoffeeNodeViewModel> GetUrlCommand { get; set; }

		#region 縣市區域
		private string _City;
		public string City
		{
			get { return _City; }
			set { SetProperty(ref _City, value); }
		}
		#endregion

		#region 創業空間名稱
		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}
		#endregion

		#region 捷運站
		private string _MRT;

		public string MRT
		{
			get { return _MRT; }
			set { SetProperty(ref _MRT, value); }
		}
		#endregion

		#region 營業時間
		private string _OpenTime;

		public string OpenTime
		{
			get { return _OpenTime; }
			set { SetProperty(ref _OpenTime, value); }
		}
		#endregion

		#region 地址
		private string _Address;

		public string Address
		{
			get { return _Address; }
			set { SetProperty(ref _Address, value); }
		}

		#endregion

		public CoffeeNodeViewModel()
		{
			GetMapommand = new DelegateCommand<CoffeeNodeViewModel>(GetMap);
			GetUrlCommand = new DelegateCommand<CoffeeNodeViewModel>(GetUrl);
		}


		private async void GetUrl(CoffeeNodeViewModel obj)
		{
			var item = GlobalData.CoffeesRepository.Items.FirstOrDefault(x => x.Name == obj.Name);
			if (item != null)
			{
				if (string.IsNullOrEmpty(item.Url) == false)
				{
					await CrossShare.Current.OpenBrowser(item.Url);
				}
			}
		}

		private async void GetMap(CoffeeNodeViewModel obj)
		{
			var item = GlobalData.CoffeesRepository.Items.FirstOrDefault(x => x.Name == obj.Name);
			if (item != null)
			{
				if (string.IsNullOrEmpty(item.Longitude) == false && string.IsNullOrEmpty(item.Latitude) == false)
				{
					var lat = Convert.ToDouble(item.Latitude);
					var lon = Convert.ToDouble(item.Longitude);
					var success = await CrossExternalMaps.Current.NavigateTo(item.Name, lat, lon, Plugin.ExternalMaps.Abstractions.NavigationType.Default);
				}
			}
		}
	}
}
