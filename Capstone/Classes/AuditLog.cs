using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.CLIMenus;

namespace Capstone.Classes
{
	public static class AuditLog
	{
		public static void PurchaseItem(Item item, string loc, double balance)
		{
			double postBalance = balance - item.Price;
			
			string result = String.Format("{0, -25}{1, -15}{2, -20}{3, -10}", DateTime.Now, item.Name + loc, balance.ToString("c"), postBalance.ToString("c"));
			
			WriteFile(result);
		}

		public static void FeedMoney(double initialBal, double balance)
		{
			string result = String.Format("{0, -25}{1, -15}{2, -20}{3, -10}", DateTime.Now, "FEED MONEY:", initialBal.ToString("c"), balance.ToString("c"));

			WriteFile(result);
		}

		public static void GiveChange(double balance)
		{
			double postBalance = 0.00;

			string result = String.Format("{0, -25}{1, -15}{2, -20}{3, -10}", DateTime.Now, "GIVE CHANGE:", balance.ToString("c"), postBalance.ToString("c"));

			WriteFile(result);
		}

		private static void WriteFile(string input)
		{
			string filePath = Environment.CurrentDirectory;
			filePath = Path.Combine(filePath, "Log.txt");

			using (StreamWriter sw = new StreamWriter(filePath, true))
			{
				sw.WriteLine(input);
			}
		}
	}
}
