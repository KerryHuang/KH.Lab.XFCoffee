using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using XFCoffee.Services;
using Plugin.ExternalMaps;
using Plugin.Messaging;
using Plugin.Share;
using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using Plugin.Connectivity;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace XFCoffee.ViewModels
{
	public class BusinessSpaceDetailPageViewModel : BindableBase, INavigationAware
	{
		private readonly INavigationService _navigationService;
		public readonly IPageDialogService _dialogService;


		public DelegateCommand GetInfoCommand { get; set; }
		public DelegateCommand GetOfferCommand { get; set; }
		public DelegateCommand GetMapCommand { get; set; }
		public DelegateCommand CallCommand { get; set; }
		public DelegateCommand SendMessageCommand { get; set; }
		public DelegateCommand SendMailCommand { get; set; }
		public DelegateCommand ShareContentCommand { get; set; }
		public DelegateCommand ShareLinkCommand { get; set; }
		public DelegateCommand GetUrlCommand { get; set; }
		public DelegateCommand GetMyMapCommand { get; set; }

		CoffeeDetailViewModel _CoffeeDetailViewModel;
		public CoffeeDetailViewModel CoffeeDetailViewModel
		{
			get { return _CoffeeDetailViewModel; }
			set { SetProperty(ref _CoffeeDetailViewModel, value); }
		}
		string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}
		bool IsConnected
		{
			get
			{
				var crossConnectivity = CrossConnectivity.Current;
				return crossConnectivity.IsConnected;
			}
		}

        Map _map;
        public Map map 
        {
            get { return _map; }
            set { SetProperty(ref _map, value); }
        }

		public BusinessSpaceDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
		{
			// 取得頁面導航的實作
			_navigationService = navigationService;
			_dialogService = dialogService;

			GetInfoCommand = new DelegateCommand(GetInfo);
			GetOfferCommand = new DelegateCommand(GetOffer);
			GetMapCommand = new DelegateCommand(GetMap);
			CallCommand = new DelegateCommand(Call);
			SendMessageCommand = new DelegateCommand(SendMessage);
			SendMailCommand = new DelegateCommand(SendMail);
			ShareContentCommand = new DelegateCommand(ShareContent);
			ShareLinkCommand = new DelegateCommand(ShareLink);
			GetUrlCommand = new DelegateCommand(GetUrl);
			GetMyMapCommand = new DelegateCommand(GetMyMap);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("CoffeeSelected"))
			{
				var coffeeSelected = parameters["CoffeeSelected"] as CoffeeNodeViewModel;
				Init(coffeeSelected);
			}
		}

		public void Init(CoffeeNodeViewModel CoffeeNodeViewModel)
		{
			var item = GlobalData.CoffeesRepository.Items.FirstOrDefault(x => x.Name == CoffeeNodeViewModel.Name);
			if (item != null)
			{
				CoffeeDetailViewModel = new CoffeeDetailViewModel()
				{
					City = item.CityName,
					Name = item.Name,
					Wifi = item.Wifi,
					Seat = item.Seat,
					Quiet = item.Quiet,
					Tasty = item.Tasty,
					Cheap = item.Cheap,
					Music = item.Music,
					Url = item.Url,
					Address = item.Address,
					Latitude = item.Latitude,
					Longitude = item.Longitude,
					Limited_Time = item.Limited_Time.ToUpper().Equals("YES") ? "是" : "否",
					Socket = item.Socket.ToUpper().Equals("YES") ? "是" : "否",
					Standing_Desk = item.Standing_Desk.ToUpper().Equals("YES") ? "是" : "否",
					MRT = item.MRT,
					Open_Time = item.Open_Time
				};

				map = new Map
				{
					IsShowingUser = true,
					HeightRequest = 100,
					WidthRequest = 960,
					VerticalOptions = LayoutOptions.FillAndExpand
				};
                //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(36.9628066, -122.0194722), Distance.FromMiles(3)));
			}
		}

		async void GetInfo()
		{
			var itemNavigationParameters = new NavigationParameters();
			var item = new WebNodeViewModel()
			{
				Name = "空間資訊",
				Content = CoffeeDetailViewModel.Open_Time
			};

			itemNavigationParameters.Add("WebInfoNodeViewModel", item);
			await _navigationService.NavigateAsync("WebViewInfoPage", itemNavigationParameters);
		}

		async void GetOffer()
		{
			var itemNavigationParameters = new NavigationParameters();
			var item = new WebNodeViewModel()
			{
				Name = "價格方案",
				Content = CoffeeDetailViewModel.Cheap.ToString(),
			};

			itemNavigationParameters.Add("WebInfoNodeViewModel", item);
			await _navigationService.NavigateAsync("WebViewInfoPage", itemNavigationParameters);
		}

		async void GetMap()
		{
			if (IsConnected)
			{
				if (string.IsNullOrEmpty(CoffeeDetailViewModel.Longitude) == false && string.IsNullOrEmpty(CoffeeDetailViewModel.Latitude) == false)
				{
					var lat = Convert.ToDouble(CoffeeDetailViewModel.Latitude);
					var lon = Convert.ToDouble(CoffeeDetailViewModel.Longitude);
					var success = await CrossExternalMaps.Current.NavigateTo(CoffeeDetailViewModel.Name, lat, lon, Plugin.ExternalMaps.Abstractions.NavigationType.Default);
				}
			}
            else
            {
                await _dialogService.DisplayAlertAsync("抱歉", $"目前無網路服務，請檢核網路是否開啟，謝謝", "確定");
            }
		}

		async void GetMyMap()
		{
			if (IsConnected)
			{
				var crossGeolocator = CrossGeolocator.Current;
				crossGeolocator.DesiredAccuracy = 50;
                Plugin.Geolocator.Abstractions.Position position = await crossGeolocator.GetPositionAsync(timeoutMilliseconds: 10000);

				var lat = position.Latitude;
				var lon = position.Longitude;
                var success = await CrossExternalMaps.Current.NavigateTo("目前位置", lat, lon, Plugin.ExternalMaps.Abstractions.NavigationType.Default);
				//await _dialogService.DisplayAlertAsync("你的位置", $"經度：{lon}，緯度：{lat}", "確定");
			}
            else
            {
                await _dialogService.DisplayAlertAsync("抱歉", $"目前無網路服務，請檢核網路是否開啟，謝謝", "確定");
            }
			//await _dialogService.DisplayAlertAsync("抱歉", $"此功能尚未建置", "確定");
		}

		void Call()
		{
			if (string.IsNullOrEmpty(CoffeeDetailViewModel.Tel) == false)
			{
				// Make Phone Call

				var phoneCallTask = CrossMessaging.Current.PhoneDialer; //MessagingPlugin.PhoneDialer;
				if (phoneCallTask.CanMakePhoneCall)
					phoneCallTask.MakePhoneCall(CoffeeDetailViewModel.Tel);
			}
		}

		async void ShareContent()
		{
			if (string.IsNullOrEmpty(CoffeeDetailViewModel.Url) == false)
			{
				//var title = "我找到一個好地方";
				//var message = 創業空間明細.創業空間名稱;

				Plugin.Share.Abstractions.ShareMessage msg = new Plugin.Share.Abstractions.ShareMessage();
				msg.Title = "我找到一個好地方";
				msg.Text = CoffeeDetailViewModel.Name;

				// Share message and an optional title.
				//await CrossShare.Current.Share(message, title);
				await CrossShare.Current.Share(msg);
			}
		}

		async void ShareLink()
		{
			if (string.IsNullOrEmpty(CoffeeDetailViewModel.Url) == false)
			{
				Plugin.Share.Abstractions.ShareMessage msg = new Plugin.Share.Abstractions.ShareMessage();
				msg.Title = "我找到一個好地方";
				msg.Text = CoffeeDetailViewModel.Name;
				msg.Url = CoffeeDetailViewModel.Url;

				// Share a link and an optional title and message.
				await CrossShare.Current.Share(msg);

			}
		}

		async void SendMail()
		{
			//await _dialogService.DisplayAlertAsync("抱歉", $"此功能尚未建置", "確定");
			var emailTask = CrossMessaging.Current.EmailMessenger; //MessagingPlugin.EmailMessenger;
			if (emailTask.CanSendEmail)
			{
			    // Send simple e-mail to single receiver without attachments, CC, or BCC.
			    emailTask.SendEmail("zihao317@gmail.com", "咖啡廳", "我找到一個好地方" + CoffeeDetailViewModel.Name);

			    // Send a more complex email with the EmailMessageBuilder fluent interface.
			    //var email = new EmailMessageBuilder()
			    //  .To("plugins@xamarin.com")
			    //  .Cc("plugins.cc@xamarin.com")
			    //  .Bcc(new[] { "plugins.bcc@xamarin.com", "plugins.bcc2@xamarin.com" })
			    //  .Subject("Xamarin Messaging Plugin")
			    //  .Body("Hello from your friends at Xamarin!")
			    //  .Build();

			    //emailTask.SendEmail(email);
			}
		}

		async void SendMessage()
		{
			//await _dialogService.DisplayAlertAsync("抱歉", $"此功能尚未建置", "確定");
			var smsMessenger = CrossMessaging.Current.SmsMessenger; //MessagingPlugin.SmsMessenger;
			if (smsMessenger.CanSendSms)
			    smsMessenger.SendSms("", "我找到一個好地方" + CoffeeDetailViewModel.Name);
		}

		async void GetUrl()
		{
			if (string.IsNullOrEmpty(CoffeeDetailViewModel.Url) == false)
			{
				await CrossShare.Current.OpenBrowser(CoffeeDetailViewModel.Url);
			}
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}
