using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsoleApp
{
	public class Player
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public Hero ChosenHero { get; set; }

		public Player(string name, int age, Hero hero)
		{
			Name = name;
			Age = age;
			ChosenHero = hero;
		}
	}
}