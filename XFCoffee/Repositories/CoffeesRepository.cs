using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using XFCoffee.Models;

namespace XFCoffee.Repositories
{
	public class CoffeesRepository
	{
		public List<Coffees> Items = new List<Coffees>();

		public SQLRepository<Coffees> db { get; set; } = new SQLRepository<Coffees>();

		public async Task GetAll()
		{
			var coffees = await db.GetAllAsync();
			if (coffees.Count == 0)
			{
				await GetInit();
			}
			Items = coffees;
		}

		public async Task GetByCity(string city)
		{
			var coffees = await db.GetAllAsync();
			var dels = coffees.Where(x => x.City == city).ToList();
			if (dels.Any())
			{
				await db.DeleteAsync(dels);
			}
			if (IsConnected)
			{
				using (var client = new HttpClient())
				{
					var result = await client.GetStringAsync($"https://cafenomad.tw/api/v1.2/cafes/{city}");
					Items = JsonConvert.DeserializeObject<List<Coffees>>(result);
					await db.InsertAsync(Items);
				}
			}
		}

		public async Task GetInit()
		{
			if (IsConnected)
			{
				var coffees = await db.GetAllAsync();
				if (coffees.Any())
				{
					await db.DeleteAsync(coffees);
				}

				using (var client = new HttpClient())
				{
					var result = await client.GetStringAsync("https://cafenomad.tw/api/v1.2/cafes/");
					Items = JsonConvert.DeserializeObject<List<Coffees>>(result);
					await db.InsertAsync(Items);
				}
			}
		}

		bool IsConnected
		{
			get
			{
                var crossConnectivity = CrossConnectivity.Current;
                return crossConnectivity.IsConnected;
			}
		}
	}
}
