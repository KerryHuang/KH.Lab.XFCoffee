using System;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFCoffee.ViewModels
{
    public class MapPageViewModel : BindableBase, INavigationAware
    {
        //Map map;

        public MapPageViewModel()
        {
			
        }

		public void Init()
		{
			//map = new Map
			//{
			//	//IsShowingUser = true,
			//	HeightRequest = 100,
			//	WidthRequest = 960,
			//	VerticalOptions = LayoutOptions.FillAndExpand
			//};

			//map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));

			//Content = new StackLayout
			//{
			//	Spacing = 0,
			//	Children = {
			//		map
			//	}
			//};
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
            Init();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
