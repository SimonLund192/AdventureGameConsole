using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Item
	{
		public string ItemName { get; set; }
		public Stats ItemStats { get; set; }
		//public Enchants ItemEnchant {  get; set; }
		//public string Effect {  get; set; } //#TODO
		//public string Value { get; set; } //#TODO
		public bool IsEquipped { get; private set; }

		public Item(string itemName, Stats itemStats/*, Enchants ItemEnchant*/)
		{
			ItemName = itemName;
			ItemStats = itemStats;
			//ItemEnchant = ItemEnchant;
			IsEquipped = false;
		}

		public void Equip(Hero hero)
		{
			if (!IsEquipped)
			{
				hero.HeroStats.HealthPoints += ItemStats.HealthPoints;
				hero.HeroStats.Damage += ItemStats.Damage;
				hero.HeroStats.DodgeChance += ItemStats.DodgeChance;
				hero.HeroStats.CritChance += ItemStats.CritChance;
				//hero.HeroStats.LifeSteal += ItemEnchants.LifeSteal;
				IsEquipped = true;
				Console.WriteLine($"{ItemName} equipped!");
			}
		}
	}
}
