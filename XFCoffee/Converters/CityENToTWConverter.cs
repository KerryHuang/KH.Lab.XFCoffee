using System;
namespace XFCoffee.Converters
{
	public static class CityENToTWConverter
	{
		public static string Convert(string city)
		{
			switch (city)
			{
				case "yunlin":
					return "雲林";
				case "yilan":
					return "宜蘭";
				case "taoyuan":
					return "桃園";
				case "taitung":
					return "台東";
				case "taipei":
					return "台北";
				case "tainan":
					return "台南";
				case "taichung":
					return "台中";
				case "pingtung":
					return "屏東";
				case "penghu":
					return "澎湖";
				case "nantou":
					return "南投";
				case "miaoli":
					return "苗栗";
				case "keelung":
					return "基隆";
				case "kaohsiung":
					return "高雄";
				case "hualien":
					return "花蓮";
				case "hsinchu":
					return "新竹";
				case "chiayi":
					return "嘉義";
				case "changhua":
					return "彰化";
				default:
					return city;
			}
		}
	}
}