using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Player
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Hero ChosenHero { get; set; }
		public int Experience { get; private set; }
		public int Level { get; private set; }

		public Player(string name, int age, Hero hero)
		{
			Name = name;
			Age = age;
			ChosenHero = hero;
			Experience = 0;
			Level = 1;
		}

		public void GainExperience(int exp)
		{
			Experience += exp;
			Console.WriteLine($"You gained {exp} experience!");

			if (Experience >= 1000)
			{
				LevelUp();
				Experience = 0;
			}
		}

		private void LevelUp()
		{
			Level++;
			ChosenHero.HeroStats.Damage = (int)(ChosenHero.HeroStats.Damage * 1.5);
			ChosenHero.HeroStats.HealthPoints = (int)(ChosenHero.HeroStats.HealthPoints * 1.5);
			ChosenHero.HeroStats.DodgeChance = (int)(ChosenHero.HeroStats.DodgeChance * 1.5);
			ChosenHero.HeroStats.CritChance = (int)(ChosenHero.HeroStats.CritChance * 1.5);
			Console.WriteLine($"Level up! You are now level {Level}. Your stats have increased by 50%.");
		}
	}
}