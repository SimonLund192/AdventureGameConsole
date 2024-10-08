﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGameConsoleApp.Interface;

namespace AdventureGameConsoleApp
{
	public class Monster : INamed
	{
		public string Name { get; set; }
		public Stats MonsterStats { get; set; }

		public Monster(string name, Stats monsterStats)
		{
			Name = name;
			MonsterStats = monsterStats;
		}

		// Optional: A method to print monster stats if needed elsewhere
		//public void DisplayMonsterStats()
		//{
		//	//Console.WriteLine($"A wild {MonsterName} appears!");
		//	//Console.WriteLine($"Damage: {MonsterStats.Damage}");
		//	//Console.WriteLine($"Health Points: {MonsterStats.HealthPoints}");
		//	//Console.WriteLine($"Dodge Chance: {MonsterStats.DodgeChance}%");
		//	//Console.WriteLine($"Crit Chance: {MonsterStats.CritChance}%");
		//}
	}
}
