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

			// Monsters
			Monster goblin = new Monster("Goblin", new Stats(10, 30, 5, 5));
			Monster skeleton = new Monster("Skeleton", new Stats(10, 30, 5, 5));
			Monster orc = new Monster("Orc", new Stats(10, 30, 5, 5));
			Monster dragon = new Monster("Dragon", new Stats(10, 30, 5, 5));
			Monster shadow = new Monster("Shadow", new Stats(10, 30, 5, 5));

			// Define rooms
			Room room1 = new Room("The Cozy Hallway (Room 1)", "As you step into this narrow corridor, the flickering" +
				"torches cast dancing shadows on the stone walls. The air smells of old wood and distant" +
				"memories. Cobwebs cling to the corners, hinting at secrets waiting to be unraveled", goblin);
			Room room2 = new Room("The Forgotten Library (Room 2)", "Beyond the heavy oak door lies a room filled with" +
				"towering bookshelves. Dusty tomes line the shelves, their leather covers cracked and faded." +
				"Sunlight filters through stained glass windows, illuminating the swirling motes in the air." +
				"Perhaps hidden knowledge lies buried here.", skeleton);
			Room room3 = new Room("The Echoing Crypt (Room 3)", "Cold stone surrounds you as you descend into darkness." +
				"The air grows damp, and the sound of dripping water echoes off the walls. Sarcophagi stand sentinel," +
				"their inscriptions worn away by time. Beware -- the restless spirits of ancient warriors may still" +
				"guard their treasures.", orc);
			Room room4 = new Room("The Alchemical Workshop (Room 4)", "A cluttered room with bubbling flasks, arcane" +
				"symbols, and strange contraptions. The air crackles with energy, and shelves sag under the weight" +
				"of dusty potion ingredients. Cauldrons simmer, and forgotten experiments lie half-finished. What" +
				"secrets can you uncover amidst the alchemical chaos?", dragon);
			Room room5 = new Room("The Starlit Observatory (Room 5)", "Ascend a spiral staircase to a circular chamber" +
				"crowned by a domed glass ceiling. Constellations twinkle above, and telescopes point toward the heavens." +
				"Ancient star charts adorn the walls, revealing paths to distant realms. Here you can glimpse both the" +
				"mysteries of the cosmos, and the battles unfolding below.", shadow);

			// Add rooms to a list for navigation
			List<Room> rooms = new List<Room> { room1, room2, room3, room4, room5 };

			// Current room index
			int currentRoomIndex = 0;

			bool gameRunning = true;

			// Game loop for moving between rooms
			while (gameRunning)
			{
				// Display current room information after the move
				rooms[currentRoomIndex].DisplayRoomInfo();

				// Displays Hero stats
				Console.WriteLine("\nYour hero stats:");
				Console.WriteLine($"Damage: {player.ChosenHero.HeroStats.Damage}");
				Console.WriteLine($"Health Points: {player.ChosenHero.HeroStats.HealthPoints}");
				Console.WriteLine($"Dodge Chance: {player.ChosenHero.HeroStats.DodgeChance}");
				Console.WriteLine($"Crit Chance: {player.ChosenHero.HeroStats.CritChance}");

				

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