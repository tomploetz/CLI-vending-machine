using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLIMenus
{
	public class MainMenu
	{
		private VendingMachine _vendingMachine = new VendingMachine();

		#region Display
		public void Display()
		{
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("*********VENDO-MATIC 500*********");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("Please choose from the following:");
				Console.WriteLine("(1) Display Vending Machine Items");
				Console.WriteLine("(2) Purchase");
				Console.WriteLine("(Q) Quit application");

				Console.Write("Which option would you like to select? ");
				char input = Console.ReadKey().KeyChar;

				if (input == '1')
				{
					exit = true;
					DisplayItems();
				}
				else if (input == '2')
				{
					exit = true;
					Purchase();
				}
				else if (input == 'Q' || input == 'q')
				{
					return;
				}
			}
		}
		#endregion

		#region DisplayItems
		private void DisplayItems(bool ignorePressKey = false)
		{
			bool exit = false;

			do
			{
				Console.Clear();
				Console.WriteLine("Location \t Item \t $ Price");
				Console.WriteLine("------------------------------------");

				_vendingMachine.Display();

				Console.WriteLine();
				Console.WriteLine("(P) Go To Purchase Menu");
				Console.WriteLine("(Q) Quit application");
				Console.WriteLine("Which option would you like to select? ");
				char input = Console.ReadKey().KeyChar;

				if (input == 'p')
				{
					exit = true;
					Purchase();
				}
				else if (input == 'q')
				{
					return;
				}
				else
				{
					Console.WriteLine("Please enter a valid option");
				}
			} while (!exit);
		}
		#endregion

		#region Purchase
		private void Purchase()
		{
			bool exit = false;
			do
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("*********VENDO-MATIC 500*********");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("Purchase Menu");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("(1) Feed Money");
				Console.WriteLine("(2) Select Product");
				Console.WriteLine("(3) Finish Transaction");
				Console.WriteLine("(4) Go Back To Main Menu");
				Console.WriteLine($"Current Money Provided: {_vendingMachine.Balance.ToString("c")}");

				Console.Write("Which option would you like to select? ");
				char input = Console.ReadKey().KeyChar;

				if (input == '1')
				{
					exit = true;
					FeedMoney();
				}
				else if (input == '2')
				{
					exit = true;
					SelectProduct();
				}
				else if (input == '3')
				{
					exit = true;
					FinishTransaction();
				}
				else if (input == '4')
				{
					exit = true;
					Display();
				}
				else
				{
					Console.WriteLine("Invalid selection, please try again...");
				}
			} while (!exit);
		}
		#endregion

		#region FeedMoney
		private void FeedMoney()
		{

			bool exit = false;

			do
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("*********VENDO-MATIC 500*********");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("Feed Money");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("Please choose an amount from the following options:");
				Console.WriteLine("(1) $1");
				Console.WriteLine("(2) $2");
				Console.WriteLine("(3) $5");
				Console.WriteLine("(4) $10");
				Console.WriteLine("(5) Go Back To Main Menu");
				Console.WriteLine($"Current Money Provided: {_vendingMachine.Balance.ToString("c")}");

				Console.Write("Which option would you like to select? ");
				string input = Console.ReadLine();

				if (input == "1")
				{
					_vendingMachine.Deposit(1);
				}
				else if (input == "2")
				{
					_vendingMachine.Deposit(2);
				}
				else if (input == "3")
				{
					_vendingMachine.Deposit(5);
				}
				else if (input == "4")
				{
					_vendingMachine.Deposit(10);
				}
				else if (input == "5")
				{
					exit = true;
					Display();
				}

			} while (!exit);
		}
		#endregion

		#region SelectProduct
		private void SelectProduct()
		{
			Console.Clear();
			bool exit = false;

			do
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("*********VENDO-MATIC 500*********");
				Console.WriteLine("---------------------------------");
				Console.WriteLine("Select Product");
				Console.WriteLine("---------------------------------");

				_vendingMachine.Display();

				Console.WriteLine();
				Console.WriteLine("F) Finish selecting");
				Console.WriteLine("Q) Quit application");
				Console.WriteLine($"Current Money Provided: {_vendingMachine.Balance.ToString("c")}");
				Console.WriteLine("Please enter the location to select product: ");
				string selection = Console.ReadLine().ToUpper();

				if (selection == "Q" || selection == "q")
				{
					return;
				}
				else if (selection == "f" || selection == "F")
				{
					exit = true;
					Purchase();
				}
				else
				{
					try
					{
						_vendingMachine.AddItem(selection);
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message + " Press any key to try again...");
						Console.ReadKey();
					}
				}
			} while (!exit);
		}
		#endregion

		#region FinishTransaction
		private void FinishTransaction()
		{
			Console.Clear();
			Console.WriteLine("Thank you for shopping at VENDO-MATIC 500!");
			Console.WriteLine();
			Console.WriteLine(_vendingMachine.ReturnChange());
			Console.WriteLine();

			_vendingMachine.FinishTransaction();
			foreach (var item in _vendingMachine.Items)
			{
				Console.WriteLine(item.Item.Consume());
			}

			Console.WriteLine();
			Console.WriteLine("Press any key to exit the application...");
			Console.ReadKey();
			return;
		}
		#endregion
	}
}
