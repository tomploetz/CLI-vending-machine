using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class Candy : Item
	{
		//constructor
		public Candy(string name, double price) : base(name, price)
		{

		}

		//methods
		public override string Consume()
		{
			string result = "Munch Munch, Yum!";

			return result;
		}
	}
}
