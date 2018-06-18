using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class Chips : Item
	{
		//constructor
		public Chips(string name, double price) : base(name, price)
		{

		}

		//methods
		public override string Consume()
		{
			string result = "Crunch Crunch, Yum!";

			return result;
		}
	}
}
