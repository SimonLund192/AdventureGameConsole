using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	internal class MonsterActionManager
	{
		private Monster monster;
		private Player player;
		private Combat combat;
		private Random random;

		public MonsterActionManager(Monster monster, Player player, Combat combat, Random random)
		{
			this.monster = monster;
			this.player = player;
			this.combat = combat;
			this.random = random;
		}

		public void MonsterAttack()
		{
			int damage = monster.MonsterStats.Damage;
			Console.WriteLine($"{monster.Name} attacks you and deals {damage} damage!");

			combat.ApplyDamage(player.ChosenHero.HeroStats, damage);

			DisplayRemainingHealth(player.ChosenHero.HeroStats, player.ChosenHero.HeroName);
		}

		private void DisplayRemainingHealth(Stats targetStats, string name)
		{
			Console.WriteLine($"{name} has {targetStats.HealthPoints} HP left.");
		}
	}
}
