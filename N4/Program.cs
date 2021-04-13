using System;
using System.Collections.Generic;

namespace N4
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var start = DateTime.Now;

				DataGenerator dataGenerator = new DataGenerator();
				List<Person> persons = dataGenerator.GeneratePeople(Int32.Parse(args[0]), args[1]);

				var deltaForGenerate2 = new TimeSpan((DateTime.Now - start).Ticks);

				WriteResult(persons);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		static void WriteResult(List<Person> persons)
		{
			ServiceStack.Text.CsvConfig.ItemSeperatorString = ";";
			string csvstring = ServiceStack.Text.CsvSerializer.SerializeToCsv(persons);

			Console.OutputEncoding = System.Text.Encoding.Unicode;
			Console.WriteLine(csvstring);
		}
	}
}
