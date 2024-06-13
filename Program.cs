﻿namespace GTC_Formatter
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Enter path to file");
				return;
			}
			if (!File.Exists(args[0]))
			{
				Console.WriteLine("File doesn't exist");
				return;
			}
			string filePath = args[0];
			string fileContents = File.ReadAllText(filePath);

			List<string> tokenizedFile = Tokenizer.Tokenize(fileContents);

			Formatter formatter = new();
			string formattedFile = formatter.FormatCode(tokenizedFile);

			File.WriteAllText(filePath, formattedFile);
			Console.WriteLine("File Formatted! Remember to run your formatter of choice in order to make it look nice");
			Console.WriteLine("Would you like to undo the changes? (y/n)");
			string? response = Console.ReadLine();
			if (response != null)
				response = response.ToLower();
			if (response == "y" || response == "yes")
			{
				File.WriteAllText(filePath, fileContents);
				Console.WriteLine("Formatting undone!");
			}
		}
	}
}