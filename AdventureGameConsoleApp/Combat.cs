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
			//Console.WriteLine($"A wild {monster.MonsterName} appears!");
			//Console.WriteLine($"Prepare to fight...");

			bool playerTurn = true;

			while (player.ChosenHero.HeroStats.HealthPoints > 0 && monster.MonsterStats.HealthPoints > 0)
			{
				if (playerTurn)
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
						default:
							Console.WriteLine("Invalid choice");
							break;
					}
				}
				else
				{
					MonsterAttack();
				}

				playerTurn = !playerTurn;
			}

			if (player.ChosenHero.HeroStats.HealthPoints > 0)
			{
				Console.WriteLine("You have defeated the monster!");
			}
			else
			{
				Console.WriteLine("You have been defeated...");
			}
		}

		private int GetValidChoice()
		{
			int choice;
			while (true)
			{
				Console.WriteLine("What's your next move?");
				Console.WriteLine("Press [1] to Attack");
				Console.WriteLine("Press [2] to Heal");
				string input = Console.ReadLine();
				if (int.TryParse(input, out choice))
				{
					if (choice == 1 || choice == 2)
					{
						return choice;
					}
				}
				Console.WriteLine("Invalid input. Please enter 1 or 2.");
			}
		}

		private void PlayerAttack()
		{
			//int damage = random.Next(5,player.ChosenHero.HeroStats.Damage);
			int damage = (player.ChosenHero.HeroStats.Damage);
			Console.WriteLine("");
			Console.WriteLine($"You attack the {monster.MonsterName} and deal {damage} damage!");

			monster.MonsterStats.HealthPoints -= damage;

			if (monster.MonsterStats.HealthPoints <= 0)
			{
				monster.MonsterStats.HealthPoints = 0;
				Console.WriteLine($"{monster.MonsterName} has been defeated.");
			}
			else
			{
				Console.WriteLine($"{monster.MonsterName} has {monster.MonsterStats.HealthPoints} HP left.");
			}
		}

		private void PlayerHeal()
		{
			int heal = random.Next(5,player.ChosenHero.HeroStats.Heal);
			Console.WriteLine("");
			Console.WriteLine($"You heal for {heal} health");

			player.ChosenHero.HeroStats.HealthPoints += heal;

			Console.WriteLine($"{player.ChosenHero.HeroName} has {player.ChosenHero.HeroStats.HealthPoints} HP left.");
		}

		private void MonsterAttack()
		{
			//int damage = random.Next(5, monster.MonsterStats.Damage);
			int damage = (monster.MonsterStats.Damage);
			Console.WriteLine("");
			Console.WriteLine($"{monster.MonsterName} attacks you and deals {damage} damage!");

			player.ChosenHero.HeroStats.HealthPoints -= damage;

			if (player.ChosenHero.HeroStats.HealthPoints <= 0)
			{
				player.ChosenHero.HeroStats.HealthPoints = 0;
				Console.WriteLine("You have been slain.");
			}
			else
			{
				Console.WriteLine($"You have {player.ChosenHero.HeroStats.HealthPoints} HP left.");
				Console.WriteLine("");
			}
		}
	}
}


