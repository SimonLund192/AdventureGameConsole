using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Monster
	{
		public string MonsterName { get; set; }
		public Stats MonsterStats { get; set; }

		public Monster(string monsterName, Stats monsterStats)
		{
			MonsterName = monsterName;
			MonsterStats = monsterStats;
		}

		public void DisplayMonsterStats()
		{
			Console.WriteLine($"{MonsterName}");
			Console.WriteLine(MonsterStats.ToString());
		}
	}
}
