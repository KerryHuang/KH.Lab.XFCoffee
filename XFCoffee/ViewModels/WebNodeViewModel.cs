using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFCoffee.ViewModels
{
	public class WebNodeViewModel : BindableBase
	{
		#region 標題名稱
		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}
		#endregion

		#region 網頁內容
		private string _Content;

		public string Content
		{
			get { return _Content; }
			set { SetProperty(ref _Content, value); }
		}
		#endregion
	}
}
