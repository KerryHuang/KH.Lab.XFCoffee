using System;
using SQLite;

namespace XFCoffee.Models
{
	public class SystemRecords
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string City { get; set; }
	}
}
