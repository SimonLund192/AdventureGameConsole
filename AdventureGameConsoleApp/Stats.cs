using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Stats
	{
		//public int MinDamage { get; set; }
		public int Damage { get; set; }
		public int Heal { get; set; }
		public int HealthPoints { get; set; }
		public int DodgeChance { get; set; }
		public int CritChance { get; set; }


		private Random random = new Random();

		public Stats(/*int minDamage, */int damage, int heal, int healthPoints, int dodgeChance, int critChance)
		{
			//MinDamage = minDamage;
			Damage = damage;
			Heal = heal;
			HealthPoints = healthPoints;
			DodgeChance = dodgeChance;
			CritChance = critChance;
		}

		// Generate random damage based on the min/max range
		//public int GetRandomDamage()
		//{
		//	return random.Next(MinDamage, MaxDamage + 1); // +1 because upper bound is exclusive
		//}
	}
}
