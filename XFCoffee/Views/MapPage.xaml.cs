using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFCoffee.Views
{
	public partial class MapPage : ContentPage
	{
		Map map;

		public MapPage()
		{
			InitializeComponent();

			map = new Map
			{
				//IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.9628066, -122.0194722), Distance.FromMiles(3))); // Santa Cruz golf course 36.9628066, -122.0194722

			var position = new Position(36.9628066, -122.0194722); // Latitude, Longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Santa Cruz",
				Address = "custom detail info"
			};
			map.Pins.Add(pin);

			var reLocate = new Button { Text = "重新定位" };
			var buttons = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = {
					 reLocate
				}
			};

			Content = new StackLayout
			{
				Spacing = 0,
				Children = {
					map,
					buttons
				}
			};
		}
	}
}

