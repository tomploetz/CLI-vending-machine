using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class Beverage : Item
	{
		//constructor
		public Beverage(string name, double price) : base(name, price)
		{

		}

		//methods
		public override string Consume()
		{
			string result = "Glug Glug, Yum!";

			return result;
		}
	}
}
