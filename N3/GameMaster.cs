using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3
{
	class GameMaster
	{
		public const string QuitText = "Q";

		public int UserScore { get; set; }
		public int CompScore { get; set; }
		public string[] Elements { get; set; }

		private int elementsHalf;
		private string hmacText;
		private string hmacKey;

		public GameMaster(string[] elements)
		{
			this.Elements = elements;

		}

		public void Start()
		{
			try
			{
				HandleElements();

				bool isWantToQuit = false;
				while (!isWantToQuit)
				{
					int userChoice, compChoice;

					compChoice = GenerateCompMove();
					ConsoleEx.WriteLineColor($"HMAC: {hmacText}");

					WriteAvailableMoves();

					userChoice = HandleInput(out isWantToQuit);
					if (isWantToQuit) continue;

					HandleRoundResultForUser(userChoice, compChoice);
					ConsoleEx.WriteLineColor($"HMAC key: {hmacKey}\n");
				}

			}
			catch(Exception ex)
			{
				ConsoleEx.WriteLineColor(ex.Message, ConsoleColor.Red);
			}
			finally
			{
				Quit();
			}
		}

		private void WriteAvailableMoves()
		{
			ConsoleEx.WriteLineColor("Available moves:", ConsoleColor.Cyan);
			for (int i = 0; i < Elements.Length; i++)
				ConsoleEx.WriteLineColor($"\t{i} - {Elements[i]};");

			ConsoleEx.WriteLineColor($"\t{QuitText} - for exit.");
		}

		private int GenerateCompMove()
		{
			int compChoice = System.Security.Cryptography.RandomNumberGenerator.GetInt32(Elements.Length);
			(hmacText, hmacKey) = Hmac.Generate(Elements[compChoice]);
			return compChoice;
		}

		private int HandleInput(out bool isWantToResume)
		{
			isWantToResume = true;
			int userChoice;

			string input = Console.ReadLine();
			while (!Int32.TryParse(input, out userChoice) && userChoice >= 0 && userChoice < Elements.Length)
			{
				if (input == QuitText)
				{
					isWantToResume = false;
					return -1;
				}

				ConsoleEx.WriteLineColor("Incorrect input, try one more");
				WriteAvailableMoves();
				input = Console.ReadLine();
			}

			return userChoice;
		}

		private void HandleRoundResultForUser(int userChoice, int compChoice)
		{
			ConsoleEx.WriteLineColor($"You choose '{Elements[userChoice]}' [{userChoice}], " + 
				$"computer - '{Elements[compChoice]}' [{compChoice}]");

			if (userChoice == compChoice)
			{
				ConsoleEx.WriteLineColor("It's a DRAW!", ConsoleColor.Yellow);
			}
			else if ( (compChoice > userChoice && Math.Abs(userChoice - compChoice) <= elementsHalf) ||
				(compChoice < userChoice && Math.Abs(userChoice - compChoice) > elementsHalf))
			{
				ConsoleEx.WriteLineColor("You LOSE!", ConsoleColor.Yellow);
				CompScore++;
			}
			else
			{
				ConsoleEx.WriteLineColor("You WIN!", ConsoleColor.Yellow);
				UserScore++;
			}
			ConsoleEx.WriteLineColor($"The score is: User {UserScore} : {CompScore} Computer", ConsoleColor.Cyan);
		}

		private void HandleElements()
		{
			if (Elements.Length == 0)
			{
				ConsoleEx.WriteLineColor("Default parameters", ConsoleColor.Yellow);
				Elements = new string[] { "Rock", "Paper", "Scissors" };
			}
			if (Elements.Length % 2 == 0)
			{
				throw new Exception("The number of elements must be odd. For example: Rock Paper Scissors");
			}
			if (Elements.Distinct().Count() != Elements.Length)
			{
				throw new Exception("All elements must be unique. For example: Rock Paper Scissors");
			}

			elementsHalf = (int)Math.Floor((double)Elements.Length / 2);
		}

		private void Quit()
		{
			ConsoleEx.WriteLineColor("Press any key...", ConsoleColor.Cyan);
			Console.ReadKey(true);
		}
	}
}
