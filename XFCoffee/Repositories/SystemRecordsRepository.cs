using System;
using XFCoffee.Models;

namespace XFCoffee.Repositories
{
	public class SystemRecordsRepository
	{
		public SQLRepository<SystemRecords> Tables { get; set; } = new SQLRepository<SystemRecords>();
	}
}
