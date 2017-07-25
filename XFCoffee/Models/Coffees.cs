using System;
using SQLite;
using XFCoffee.Converters;

namespace XFCoffee.Models
{
	public class Coffees
	{
		/// <summary>
		/// UUID
		/// </summary>
		/// <value>The identifier.</value>
		[PrimaryKey]
		public Guid ID { get; set; }
		/// <summary>
		/// 店名
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		private string _City { get; set; }
		/// <summary>
		/// 城市
		/// </summary>
		/// <value>The city.</value>
		public string City 
		{
			get { return _City; } 
			set { _City = value; } 
		}
		public string CityName 
		{ 
			get { return CityENToTWConverter.Convert(_City); }
		}
		/// <summary>
		/// Wifi穩定
		/// </summary>
		/// <value>The wifi.</value>
		public float Wifi { get; set; }
		/// <summary>
		/// 通常有位
		/// </summary>
		/// <value>The seat.</value>
		public float Seat { get; set; }
		/// <summary>
		/// 安靜程度
		/// </summary>
		/// <value>The quiet.</value>
		public float Quiet { get; set; }
		/// <summary>
		/// 咖啡好喝
		/// </summary>
		/// <value>The tasty.</value>
		public float Tasty { get; set; }
		/// <summary>
		/// 價格便宜
		/// </summary>
		/// <value>The cheap.</value>
		public float Cheap { get; set; }
		/// <summary>
		/// 裝潢音樂
		/// </summary>
		/// <value>The music.</value>
		public float Music { get; set; }
		/// <summary>
		/// 官網
		/// </summary>
		/// <value>The URL.</value>
		public string Url { get; set; }
		/// <summary>
		/// 地址
		/// </summary>
		/// <value>The address.</value>
		public string Address { get; set; }
		/// <summary>
		/// 緯度
		/// </summary>
		/// <value>The latitude.</value>
		public string Latitude { get; set; }
		/// <summary>
		/// 經度
		/// </summary>
		/// <value>The longitude.</value>
		public string Longitude { get; set; }
		/// <summary>
		/// 有無限時
		/// </summary>
		/// <value>The limited time.</value>
		public string Limited_Time { get; set; }
		/// <summary>
		/// 插座多
		/// </summary>
		/// <value>The socket.</value>
		public string Socket { get; set; }
		/// <summary>
		/// 可站立可作
		/// </summary>
		/// <value>The standing desk.</value>
		public string Standing_Desk { get; set; }
		/// <summary>
		/// 捷運站
		/// </summary>
		/// <value>The MRT.</value>
		public string MRT { get; set; }
		/// <summary>
		/// 營業時間
		/// </summary>
		/// <value>The open time.</value>
		public string Open_Time { get; set; }
	}
}
