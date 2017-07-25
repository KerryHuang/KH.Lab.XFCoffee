using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFCoffee.ViewModels
{
	public class CityNoteViewModel : BindableBase
	{
		#region 縣市
		private string _City;
		public string City
		{
			get { return _City; }
			set { SetProperty(ref _City, value); }
		}
		#endregion
	}
}
