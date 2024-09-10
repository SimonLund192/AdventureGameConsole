using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Player
	{
		public string Name;
		public int id;
		public Hero ChosenHero { get; set; }

		public Player(string name, int id, Hero chosenHero)
		{
			Name = name;
			this.id = id;
			ChosenHero = chosenHero;
		}
	}
}
