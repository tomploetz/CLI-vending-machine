using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
	public class VendingMachine
	{
		#region Properties
		private Dictionary<string, InventoryItem> _inventory { get; set; } = new Dictionary<string, InventoryItem>();
		public double Balance { get; private set; }
		public List<InventoryItem> Items
		{
			get
			{
				return _items;
			}
		}
		#endregion

		#region Member Variables
		private List<InventoryItem> _items = new List<InventoryItem>();
		private SalesReport _salesReport = new SalesReport();
		#endregion

		#region Constructor
		public VendingMachine()
		{
			LoadInventory();
		}
		#endregion

		#region Methods
		public void LoadInventory()
		{
			string sourceFilePath = "vendingmachine.csv";
			if (!Path.IsPathRooted(sourceFilePath))
			{
				sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);
			}

			try
			{
				using (StreamReader sr = new StreamReader(sourceFilePath))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						char[] splitChar = { '|' };

						string[] itemLoc = line.Split(splitChar);

						if (itemLoc[3] == Item.Candy)
						{
							Candy candy = new Candy(itemLoc[1], double.Parse(itemLoc[2]));
							InventoryItem item = new InventoryItem(candy);
							_inventory.Add(itemLoc[0], item);
						}
						if (itemLoc[3] == Item.Chips)
						{
							Chips chip = new Chips(itemLoc[1], double.Parse(itemLoc[2]));
							InventoryItem item = new InventoryItem(chip);
							_inventory.Add(itemLoc[0], item);
						}
						if (itemLoc[3] == Item.Beverage)
						{
							Beverage drink = new Beverage(itemLoc[1], double.Parse(itemLoc[2]));
							InventoryItem item = new InventoryItem(drink);
							_inventory.Add(itemLoc[0], item);
						}
						if (itemLoc[3] == Item.Gum)
						{
							Gum gum = new Gum(itemLoc[1], double.Parse(itemLoc[2]));
							InventoryItem item = new InventoryItem(gum);
							_inventory.Add(itemLoc[0], item);
						}
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public void Display()
		{
			foreach (KeyValuePair<string, InventoryItem> i in _inventory)
			{
				if (i.Value.Quantity == 0)
				{
					Console.WriteLine($"{i.Key.PadRight(12, ' ')} {i.Value.Item.Name.PadRight(12, ' ')} {i.Value.Item.Price.ToString("c").PadRight(12, ' ')} SOLD OUT");
				}
				else
				{
					Console.WriteLine($"{i.Key.PadRight(12, ' ')} {i.Value.Item.Name.PadRight(12, ' ')} {i.Value.Item.Price.ToString("c").PadRight(12, ' ')} {i.Value.Quantity}");
				}
			}
		}

		public void Deposit(double number)
		{
			Balance += number;
			AuditLog.FeedMoney(number, Balance);
		}

		public void Deduction(double number)
		{
			Balance -= number;
		}

		public void AddItem(string selection)
		{
			if (_inventory.ContainsKey(selection) == false)
			{
				throw new Exception("Invalid product selection...");
			}
			else if (Balance < _inventory[selection].Item.Price)
			{
				throw new Exception("Insufficient funds for selection...");
			}
			else if (_inventory[selection].Quantity <= 0)
			{
				throw new Exception("Item is sold out...");
			}
			else
			{
				_inventory[selection].Quantity--;
				AuditLog.PurchaseItem(_inventory[selection].Item, selection, Balance);

				Balance -= _inventory[selection].Item.Price;
				_items.Add(_inventory[selection]);
			}
		}

		public string ReturnChange()
		{
			string result = "";

			AuditLog.GiveChange(Balance);

			double quarters = .25;
			double dimes = .10;
			double nickels = .05;

			int quarterCount = 0;
			int dimeCount = 0;
			int nickelCount = 0;

			while (Balance >= quarters)
			{
				Balance -= quarters;
				quarterCount++;
			}
			while (Balance >= dimes)
			{
				Balance -= dimes;
				dimeCount++;
			}
			while (Balance >= nickels)
			{
				Balance -= nickels;
				nickelCount++;
			}

			result = $"Your change is: {quarterCount} quarters, {dimeCount} dimes, and {nickelCount} nickels";

			return result;
		}

		public void FinishTransaction()
		{
			List<string> purchasedItems = new List<string>();
			foreach (var item in Items)
			{
				purchasedItems.Add(item.Item.Name);

			}

			Dictionary<string, double> itemNames = new Dictionary<string, double>();
			foreach (var item in _inventory)
			{
				itemNames.Add(item.Value.Item.Name, item.Value.Item.Price);

			}

			_salesReport.GenerateReportFile(itemNames, purchasedItems);
		}
		#endregion
	}
}