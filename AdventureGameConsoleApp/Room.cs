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

		public Room(string roomName, string description)
		{
			RoomName = roomName;
			Description = description;
		}

		public void DisplayRoomInfo()
		{
			Console.WriteLine($"You are in the {RoomName}.");
			Console.WriteLine($"{Description}");
		}
	}
}
