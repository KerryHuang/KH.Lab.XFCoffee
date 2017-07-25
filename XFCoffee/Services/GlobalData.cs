using System;
using XFCoffee.Repositories;

namespace XFCoffee.Services
{
	public class GlobalData
	{
		public static string Filter = "Filter";
		public static string DBName = "CoffeeDB.db3";

		public static CoffeesRepository CoffeesRepository = new CoffeesRepository();
		public static SystemRecordsRepository SystemRecordsRepository = new SystemRecordsRepository();

	}
}
