using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class GameSetup
	{
		public Player SetupPlayer()
		{
			// Define different heroes with specific stats
			Hero warrior = new Hero("Warrior", new Stats(20, 5, 100, 5, 15));
			Hero mage = new Hero("Mage", new Stats(30, 5, 40, 25, 10));
			Hero rogue = new Hero("Rogue", new Stats(10, 5, 90, 20, 20));

			// Display options to the player
			Console.WriteLine("Choose your class:");
			Console.WriteLine("1. Warrior");
			Console.WriteLine("2. Mage");
			Console.WriteLine("3. Rogue");

			// Read player choice
			int choice = GetValidChoice();

			Hero chosenHero = choice switch
			{
				1 => warrior,
				2 => mage,
				3 => rogue,
				_ => warrior,  // Default to Warrior in case of invalid input
			};

			return new Player("Player", 30, chosenHero);
		}

		// Method to ensure valid input from player
		private int GetValidChoice()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 1 && choice <= 3))
				{
					return choice;
				}
				Console.WriteLine("Invalid input. Please choose 1, 2, or 3.");
			}
		}
	}
}
