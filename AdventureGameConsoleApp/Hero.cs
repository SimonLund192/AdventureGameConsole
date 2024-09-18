using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Hero
	{
		public string HeroName { get; set; }
		public Stats HeroStats { get; set; }


		public Hero(string heroName, Stats heroStats)
		{
			HeroName = heroName;
			HeroStats = heroStats;
		}

		public void DisplayHeroStats()
		{
			Console.WriteLine($"{HeroName}");
			Console.WriteLine(HeroStats.ToString());

		}
	}
}