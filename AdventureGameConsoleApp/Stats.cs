using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Stats
	{
		public int Damage { get; set; }
		public int HealthPoints { get; set; }
		public int DodgeChance { get; set; }
		public int CritChance { get; set; }

		public Stats(int damage, int healthPoints, int dodgeChance, int critChance)
		{
			Damage = damage;
			HealthPoints = healthPoints;
			DodgeChance = dodgeChance;
			CritChance = critChance;
		}

	}
}
