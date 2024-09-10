using System;

namespace AdventureGameConsoleApp
{
	internal class Game
	{
		static void Main(string[] args)
		{
			// Setup the game
			GameSetup setup = new GameSetup();
			Player player = setup.SetupPlayer();

			// Define rooms
			Room room1 = new Room("Entrance Hall", "A grand hall with tall ceilings and portraits of past adventurers.");
			Room room2 = new Room("Armory", "Weapons and armor are scattered across the room, relics of past battles.");
			Room room3 = new Room("Throne Room", "A magnificent room with a golden throne at its center, but something feels eerie.");

			// Add rooms to a list for navigation
			List<Room> rooms = new List<Room> { room1, room2, room3 };

			// Current room index
			int currentRoomIndex = 0;

			bool gameRunning = true;

			// Game loop for moving between rooms
			while (gameRunning)
			{
				// Display current room information
				rooms[currentRoomIndex].DisplayRoomInfo();

				// Display options to move between rooms
				Console.WriteLine("\nWhat do you want to do?");
				if (currentRoomIndex > 0) Console.WriteLine("1. Move to the previous room");
				if (currentRoomIndex < rooms.Count - 1) Console.WriteLine("2. Move to the next room");
				Console.WriteLine("3. Exit the game");

				// Get player's choice
				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						if (currentRoomIndex > 0)
						{
							currentRoomIndex--;
						}
						else
						{
							Console.WriteLine("You are already in the first room.");
						}
						break;

					case "2":
						if (currentRoomIndex < rooms.Count - 1)
						{
							currentRoomIndex++;
						}
						else
						{
							Console.WriteLine("You are already in the last room.");
						}
						break;

					case "3":
						gameRunning = false;
						Console.WriteLine("Exiting the game. Goodbye!");
						break;

					default:
						Console.WriteLine("Invalid option. Please choose again.");
						break;
				}

				Console.Clear();  // Clear the console to keep things tidy
			}
		}
	}
}