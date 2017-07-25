using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFCoffee.ViewModels
{
	public class CoffeeDetailViewModel : BindableBase
	{
		#region 店名
		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}
		#endregion

		#region 城市
		private string _City;
		public string City
		{
			get { return _City; }
			set { SetProperty(ref _City, value); }
		}
		#endregion

		#region Wifi穩定
		private float _Wifi;
		public float Wifi
		{
			get { return _Wifi; }
			set { SetProperty(ref _Wifi, value); }
		}
		public string WifiStar
		{
			get { return _Wifi.ToString() + " 星"; }
		}
		#endregion

		#region 通常有位
		private float _Seat;
		public float Seat
		{
			get { return _Seat; }
			set { SetProperty(ref _Seat, value); }
		}
		public string SeatStar
		{
			get { return _Seat.ToString() + " 星"; }
		}
		#endregion

		#region 安靜程度
		private float _Quiet;
		public float Quiet
		{
			get { return _Quiet; }
			set { SetProperty(ref _Quiet, value); }
		}
		public string QuietStar
		{
			get { return _Quiet.ToString() + " 星"; }
		}
		#endregion

		#region 咖啡好喝
		private float _Tasty;
		public float Tasty
		{
			get { return _Tasty; }
			set { SetProperty(ref _Tasty, value); }
		}
		public string TastyStar
		{
			get { return _Tasty.ToString() + " 星"; }
		}
		#endregion

		#region 價格便宜
		private float _Cheap;
		public float Cheap
		{
			get { return _Cheap; }
			set { SetProperty(ref _Cheap, value); }
		}
		public string CheapStar
		{
			get { return _Cheap.ToString() + " 星"; }
		}
		#endregion

		#region 裝潢音樂
		private float _Music;
		public float Music
		{
			get { return _Music; }
			set { SetProperty(ref _Music, value); }
		}
		public string MusicStar
		{
			get { return _Music.ToString() + " 星"; }
		}
		#endregion

		#region 官網
		private string _Url;
		public string Url
		{
			get { return _Url; }
			set { SetProperty(ref _Url, value); }
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

		#region 緯度
		private string _Latitude;
		public string Latitude
		{
			get { return _Latitude; }
			set { SetProperty(ref _Latitude, value); }
		}
		#endregion

		#region 經度
		private string _Longitude;
		public string Longitude
		{
			get { return _Longitude; }
			set { SetProperty(ref _Longitude, value); }
		}
		#endregion

		#region 有無限時
		private string _Limited_Time;
		public string Limited_Time
		{
			get { return _Limited_Time; }
			set { SetProperty(ref _Limited_Time, value); }
		}
		#endregion

		#region 插座多
		private string _Socket;
		public string Socket
		{
			get { return _Socket; }
			set { SetProperty(ref _Socket, value); }
		}
		#endregion

		#region 可站立可作
		private string _Standing_Desk;
		public string Standing_Desk
		{
			get { return _Standing_Desk; }
			set { SetProperty(ref _Standing_Desk, value); }
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
		private string _Open_Time;
		public string Open_Time
		{
			get { return _Open_Time; }
			set { SetProperty(ref _Open_Time, value); }
		}
		#endregion

		#region 連絡電話
		private string _Tel;
		public string Tel
		{
			get { return _Tel; }
			set { SetProperty(ref _Tel, value); }
		}
		#endregion
	}
}
