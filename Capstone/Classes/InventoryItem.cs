using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class InventoryItem
	{
		//properties
		public int Quantity { get; set; } = 5;
		public Item Item { get; }

		//constructor
		public InventoryItem(Item item)
		{
			Item = item;
		}
	}
}
