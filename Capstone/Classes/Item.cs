using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public abstract class Item
	{
		//create constants for type
		public const string Candy = "Candy";
		public const string Chips = "Chip";
		public const string Beverage = "Drink";
		public const string Gum = "Gum";

		//properties
		public string Name { get; set; }
		public double Price { get; set; }

		//constructor
		public Item(string name, double price)
		{
			Name = name;
			Price = price;
		}

		//methods
		public abstract string Consume();

	}
}
