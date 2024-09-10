using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	internal class Room
	{
		public string RoomName { get; set; }
		public string Description { get; set; }
		//public Monster RoomMonster { get; set; }

		public Room(string roomName, string description /*Monster monster*/)
		{
			RoomName = roomName;
			Description = description;
			//RoomMonster = monster;
		}

		public void DisplayRoomInfo()
		{
			Console.WriteLine($"You are in a {RoomName}.");
			Console.WriteLine($"{Description}");

			//if (RoomMonster != null)
			//{
			//	Console.WriteLine("");
			//	Console.WriteLine("----A monster lurks here!----");
			//	RoomMonster.DisplayMonsterStats();
				
			//}
			//else
			//{
			//	Console.WriteLine("No monsters here");
			//}
		}
	}
}
