using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;

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
			Room room1 = new Room("The Cozy Hallway (Room 1)", "As you step into this narrow corridor, the flickering" +
				"torches cast dancing shadows on the stone walls. The air smells of old wood and distant" +
				"memories. Cobwebs cling to the corners, hinting at secrets waiting to be unraveled");
			Room room2 = new Room("The Forgotten Library (Room 2)", "Beyond the heavy oak door lies a room filled with" +
				"towering bookshelves. Dusty tomes line the shelves, their leather covers cracked and faded." +
				"Sunlight filters through stained glass windows, illuminating the swirling motes in the air." +
				"Perhaps hidden knowledge lies buried here.");
			Room room3 = new Room("The Echoing Crypt (Room 3)", "Cold stone surrounds you as you descend into darkness." +
				"The air grows damp, and the sound of dripping water echoes off the walls. Sarcophagi stand sentinel," +
				"their inscriptions worn away by time. Beware -- the restless spirits of ancient warriors may still" +
				"guard their treasures.");
			Room room4 = new Room("The Alchemical Workshop (Room 4)", "A cluttered room with bubbling flasks, arcane" +
				"symbols, and strange contraptions. The air crackles with energy, and shelves sag under the weight" +
				"of dusty potion ingredients. Cauldrons simmer, and forgotten experiments lie half-finished. What" +
				"secrets can you uncover amidst the alchemical chaos?");
			Room room5 = new Room("The Starlit Observatory (Room 5)", "Ascend a spiral staircase to a circular chamber" +
				"crowned by a domed glass ceiling. Constellations twinkle above, and telescopes point toward the heavens." +
				"Ancient star charts adorn the walls, revealing paths to distant realms. Here you can glimpse both the" +
				"mysteries of the cosmos, and the battles unfolding below.");
			// Create monsters
			Monster monster1 = new Monster("Goblin", new Stats(15, 0, 50, 10, 5));
			Monster monster2 = new Monster("Skeleton", new Stats(20, 0, 40, 5, 10));
			Monster monster3 = new Monster("Ghost", new Stats(25, 0, 60, 15, 15));
			Monster monster4 = new Monster("Dragon", new Stats(50, 0, 200, 5, 20));
			Monster monster5 = new Monster("Demon", new Stats(30, 0, 100, 10, 25));

			// Pair monsters with rooms
			List<(Room, Monster)> roomsWithMonsters = new List<(Room, Monster)>
			{
				(room1, monster1),
				(room2, monster2),
				(room3, monster3),
				(room4, monster4),
				(room5, monster5)
			};

			// Current room index
			int currentRoomIndex = 0;
			bool gameRunning = true;

			while (gameRunning)
			{
				// Display room and monster information
				var (currentRoom, currentMonster) = roomsWithMonsters[currentRoomIndex];
				currentRoom.DisplayRoomInfo();

				// Display hero stats
				Console.WriteLine("\nYour hero stats:");
				Console.WriteLine($"Damage: {player.ChosenHero.HeroStats.Damage}");
				Console.WriteLine($"Health Points: {player.ChosenHero.HeroStats.HealthPoints}");
				Console.WriteLine($"Dodge Chance: {player.ChosenHero.HeroStats.DodgeChance}");
				Console.WriteLine($"Crit Chance: {player.ChosenHero.HeroStats.CritChance}");

				// Display monster stats
				Console.WriteLine("");
				Console.WriteLine($"A wild {currentMonster.MonsterName} appears!");

				Console.WriteLine($"\n{currentMonster.MonsterName} stats:");
				Console.WriteLine($"Damage: {currentMonster.MonsterStats.Damage}");
				Console.WriteLine($"Health Points: {currentMonster.MonsterStats.HealthPoints}");
				Console.WriteLine($"Dodge Chance: {currentMonster.MonsterStats.DodgeChance}");
				Console.WriteLine($"Crit Chance: {currentMonster.MonsterStats.CritChance}");
				Console.WriteLine($"Prepare to fight...");
				Console.WriteLine("");

				// Initiate combat
				Combat combat = new Combat(player, currentMonster);
				combat.StartFight();

				if (player.ChosenHero.HeroStats.HealthPoints <= 0)
				{
					gameRunning = false;
					Console.WriteLine("Game Over.");
					break;
				}

				// Display options to move between rooms
				Console.WriteLine("\nWhat do you want to do?");
				if (currentRoomIndex > 0) Console.WriteLine("1. Move to the previous room");
				if (currentRoomIndex < roomsWithMonsters.Count - 1) Console.WriteLine("2. Move to the next room");
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
						if (currentRoomIndex < roomsWithMonsters.Count - 1)
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

				Console.Clear();
			}
		}
	}
}