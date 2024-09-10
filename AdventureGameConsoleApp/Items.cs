using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Items
	{
		public string ItemName {  get; set; }
		public Stats ItemStats { get; set; }
		public Items(string itemName, Stats itemStats)
		{
			ItemName = itemName;
			ItemStats = itemStats;
		}

		public void DisplayItemStats()
		{
			Console.WriteLine($"{ItemName}");
			Console.WriteLine(ItemStats.ToString());
		}

	}
}
