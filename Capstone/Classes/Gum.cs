using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class Gum : Item
	{
		//properties
		public Gum(string name, double price) : base(name, price)
		{

		}

		//methods
		public override string Consume()
		{
			string result = "Chew Chew, Yum!";

			return result;
		}
	}
}
