using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class SalesReport
	{
		private Dictionary<string, int> _salesReport = new Dictionary<string, int>();

		public void GenerateReportFile(Dictionary<string, double> itemNames, List<string> itemsPurchased)
		{
			//check if file exists
			string sourceFilePath = "SalesReport.txt";
			if (!Path.IsPathRooted(sourceFilePath))
			{
				sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);
			}
			//if it does, read the report file ReadReportFile()
			if (File.Exists(sourceFilePath))
			{
				ReadReportFile(sourceFilePath);
			}
			//if it doesnt, dont read in, populate dictionary with itemNames and initialize to 0
			else
			{
				foreach(var i in itemNames)
				{
					if (!_salesReport.ContainsKey(i.Key))
					{
						_salesReport.Add(i.Key, 0);
					}
				}
			}
			//update the dictionary with the itemsPurchased
			foreach(var i in itemsPurchased)
			{
				if(_salesReport.ContainsKey(i))
				{
					_salesReport[i] += 1;
				}
			}

			double grossSales = 0;
			foreach(var item in _salesReport)
			{
				grossSales += item.Value * itemNames[item.Key];
			}

			WriteReportFile(sourceFilePath, grossSales);
		}
		private void ReadReportFile(string filePath)
		{
			//read in salesreport.txt and put into salesreport dictionary
			using (StreamReader sr = new StreamReader(filePath))
			{
				while(!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					if (line.Contains('|'))
					{
						string[] item = line.Split('|');
						_salesReport.Add(item[0], int.Parse(item[1]));
					}
				}
			}
		}
		//method to get list of inventory items
		private void WriteReportFile(string filePath, double sales)
		{
			using (StreamWriter sw = new StreamWriter(filePath, false))
			{
				foreach (var item in _salesReport)
				{
					sw.WriteLine(item.Key + "|" + item.Value);
				}
				sw.WriteLine();
				sw.WriteLine("TOTAL GROSS SALES: " + sales.ToString("c"));
			}
		}
	}
}
