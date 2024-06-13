namespace GTC_Formatter
{
	internal class Formatter
	{
		int labelCounter = 0;

		public string FormatCode(List<string> code)
		{
			for (int i = 0; i < code.Count; i++)
			{
				if (code[i] == "for")
				{
					int j = i;
					for (; !(code[j] == "(" || j == code.Count - 1); j++)
					{
					}
					j++;
					string variableInit = "";
					for (; !(code[j] == ";" || j == code.Count - 1); j++)
					{
						variableInit += code[j];
					}
					j++;
					string condition = "";
					for (; !(code[j] == ";" || j == code.Count - 1); j++)
					{
						condition += code[j];
					}
					j++;
					string action = "";
					for (; !(code[j] == ")" || j == code.Count - 1); j++)
					{
						action += code[j];
					}
					j++;
					int braceCount = 0;
					string content = "";
					for (; !(code[j] == "{" || j == code.Count - 1); j++)
					{
					}
					j++;
					for (; !((code[j] == "}" && braceCount == 0) || j == code.Count - 1); j++)
					{
						content += code[j];
						if (code[j] == "{")
							braceCount++;
						else if (code[j] == "}")
							braceCount--;
					}
					j++;
					string formattedFor = $"{{\n{variableInit};\nlabel{labelCounter}:\nif({condition}){{{content}\n{action};\n\ngoto label{labelCounter};\n}}\n}}";
					labelCounter++;
					code.RemoveRange(i, j - i);
					code.Insert(i, formattedFor);
					code = Tokenizer.Tokenize(string.Join("", code));
					FormatCode(code);
				}
				else if (code[i] == "while")
				{
					int j = i;
					for (; !(code[j] == "(" || j == code.Count - 1); j++)
					{
					}
					j++;
					string condition = "";
					for (; !(code[j] == ")" || j == code.Count - 1); j++)
					{
						condition += code[j];
					}
					j++;
					int braceCount = 0;
					string content = "";
					for (; !(code[j] == "{" || j == code.Count - 1); j++)
					{
					}
					j++;
					for (; !((code[j] == "}" && braceCount == 0) || j == code.Count - 1); j++)
					{
						content += code[j];
						if (code[j] == "{")
							braceCount++;
						else if (code[j] == "}")
							braceCount--;
					}
					j++;
					string formattedFor = $"{{\nlabel{labelCounter}:\nif({condition}){{{content}\n\ngoto label{labelCounter};\n}}\n}}";
					labelCounter++;
					code.RemoveRange(i, j - i);
					code.Insert(i, formattedFor);
					code = Tokenizer.Tokenize(string.Join("", code));
					FormatCode(code);
				}
			}
			return string.Join("", code);
		}
	}
}
