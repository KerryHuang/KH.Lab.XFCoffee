using Prism.Navigation;
using Prism.Unity;
using XFCoffee.Views;

namespace XFCoffee
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			var navPara = new NavigationParameters();
			navPara.Add("title", "請稍後，正在更新資料");
			NavigationService.NavigateAsync("/MainPage", navPara);
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<HomePage>();
			Container.RegisterTypeForNavigation<BusinessSpacePage>();
			Container.RegisterTypeForNavigation<BusinessSpaceDetailPage>();
			Container.RegisterTypeForNavigation<WebViewInfoPage>();
			Container.RegisterTypeForNavigation<SelectCityPage>();
			Container.RegisterTypeForNavigation<MapPage>();
		}
	}
}

