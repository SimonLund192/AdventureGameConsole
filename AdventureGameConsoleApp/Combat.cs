using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Combat
	{
		private Player player;
		private Monster monster;
		private Random random;

		public Combat(Player player, Monster monster)
		{
			this.player = player;
			this.monster = monster;
			this.random = new Random();
		}

		public void StartFight()
		{
			bool playerTurn = true;

			while (!IsDefeated(player.ChosenHero) && !IsDefeated(monster))
			{
				if (playerTurn)
				{
					ExecutePlayerTurn();
				}
				else
				{
					MonsterAttack();
				}

				playerTurn = !playerTurn;
			}

			DisplayFightResult();
		}

		private void ExecutePlayerTurn()
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
				Console.WriteLine("Invalid input. Please enter 1 or 2.");
			}
		}

		private void PlayerAttack()
		{
			int damage = player.ChosenHero.HeroStats.Damage;
			Console.WriteLine($"You attack the {monster.MonsterName} and deal {damage} damage!");

			ApplyDamage(monster.MonsterStats, damage);

			DisplayRemainingHealth(monster.MonsterStats, monster.MonsterName);
		}

		private void PlayerHeal()
		{
			int heal = random.Next(5, player.ChosenHero.HeroStats.Heal);
			Console.WriteLine($"You heal for {heal} health!");

			player.ChosenHero.HeroStats.HealthPoints += heal;

			Console.WriteLine($"{player.ChosenHero.HeroName} has {player.ChosenHero.HeroStats.HealthPoints} HP left.");
		}

		private void MonsterAttack()
		{
			int damage = monster.MonsterStats.Damage;
			Console.WriteLine($"{monster.MonsterName} attacks you and deals {damage} damage!");

			ApplyDamage(player.ChosenHero.HeroStats, damage);

			DisplayRemainingHealth(player.ChosenHero.HeroStats, player.ChosenHero.HeroName);
		}

		private void ApplyDamage(Stats target, int damage)
		{
			target.HealthPoints -= damage;
			if (target.HealthPoints < 0)
				target.HealthPoints = 0;
		}

		private void DisplayRemainingHealth(Stats targetStats, string name)
		{
			Console.WriteLine($"{name} has {targetStats.HealthPoints} HP left.");
		}

		private bool IsDefeated(Hero hero) => hero.HeroStats.HealthPoints <= 0;

		private bool IsDefeated(Monster monster) => monster.MonsterStats.HealthPoints <= 0;

		private void DisplayFightResult()
		{
			if (IsDefeated(monster))
			{
				Console.WriteLine("You have defeated the monster!");
				player.GainExperience(1000); // Gain 1000 experience on win

				Item droppedItem = GetMonsterDrop(monster);
				Console.WriteLine($"The {monster.MonsterName} dropped {droppedItem.ItemName}!");

				droppedItem.Equip(player.ChosenHero);
			}
			else
			{
				Console.WriteLine("You have been defeated...");
			}
		}

		private Item GetMonsterDrop(Monster monster)
		{
			return monster.MonsterName switch
			{
				"Goblin" => new Item("Sword", new Stats(10, 0, 0, 0, 0)),
				"Skeleton" => new Item("Hat", new Stats(0, 0, 20, 5, 0)),
				"Ghost" => new Item("Chest", new Stats(0, 0, 30, 0, 10)),
				"Dragon" => new Item("Gloves", new Stats(15, 0, 0, 10, 0)),
				"Demon" => new Item("Boots", new Stats(0, 0, 10, 20, 5)),
				_ => null,
			};
		}
	}
}