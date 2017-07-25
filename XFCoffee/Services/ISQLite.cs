using System;
using SQLite;

namespace XFCoffee.Services
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
		SQLiteAsyncConnection GetConnectionAsync();
	}
}
