using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class PlayerActionManager
	{
		private Player player;
		private Monster monster;
		private Combat combat;
		private Random random;

		public PlayerActionManager(Player player, Monster monster, Combat combat, Random random)
		{
			this.player = player;
			this.monster = monster;
			this.combat = combat;
			this.random = random;
		}

		public void ExecutePlayerTurn()
		{
			int choice = GetValidChoice();

			switch (choice)
			{
				case 1:
					PlayerAttack();
					break;
				case 2:
					PlayerHeal();
					break;
			}
		}

		private int GetValidChoice()
		{
			Console.WriteLine("");
			Console.WriteLine("What's your next choice?");
			Console.WriteLine("1. Attack");
			Console.WriteLine("2. Heal");

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
				{
					return choice;
				}
				Console.WriteLine("Invalid input. Please enter 1 or 2");
			}
		}

		private void PlayerAttack()
		{
			int damage = player.ChosenHero.HeroStats.Damage;
			bool isCrit = random.Next(0, 100) < player.ChosenHero.HeroStats.CritChance;
			bool isDodged = random.Next(0, 100) < monster.MonsterStats.DodgeChance;

			if (isCrit)
			{
				damage *= 2;
				Console.WriteLine("Critical Hit!");
			}

			if (!isDodged)
			{
				Console.WriteLine($"You attack the {monster.MonsterName} and deal {damage} damage!");
				combat.ApplyDamage(monster.MonsterStats, damage);
			}
			else
			{
				Console.WriteLine($"{monster.MonsterName} dodged your attack!");
			}

			DisplayRemainingHealth(monster.MonsterStats, monster.MonsterName);
		}

		private void PlayerHeal()
		{
			int heal = random.Next(5, player.ChosenHero.HeroStats.Heal);
			Console.WriteLine($"You heal for {heal} health!");
			player.ChosenHero.HeroStats.HealthPoints += heal;
			Console.WriteLine($"{player.ChosenHero.HeroName} has {player.ChosenHero.HeroStats.HealthPoints} HP left.");
		}

		private void DisplayRemainingHealth(Stats targetStats, string name)
		{
			Console.WriteLine($"{name} has {targetStats.HealthPoints} HP left.");
		}
	}
}
