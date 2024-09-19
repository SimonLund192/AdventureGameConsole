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
		public int Currency { get; set; }
		public Item item { get; set; }
		public List <Item> items { get; set; }


		public Player(string name, int age, Hero hero)
		{
			Name = name;
			Age = age;
			ChosenHero = hero;
			Experience = 0;
			Level = 1;
			Currency = 0;
			items = new List<Item>();
		}

		public void GainCurrency(int currency)
		{
			Console.WriteLine($"You've gained {currency} gold!");
		}

		public void GainExperience(int exp)
		{
			Experience += exp;
			Console.WriteLine($"You've gained {exp} experience!");

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

		public void EquipItem()
		{
			if (item != null)
			{
				items.Add(item);
                Console.WriteLine($"{item.ItemName} equipped");
			}
			else
			{
                Console.WriteLine("No item to equip");
			}
		}
	}
}