namespace GTC_Formatter
{
	internal class Tokenizer
	{
		public static List<string> Tokenize(string input)
		{
			List<string> tokenizedString = [];

			string token = "";
			bool isQuote = false;
			bool isLineComment = false;

			foreach (char c in input)
			{
				switch (c)
				{
					case ' ':
					case '\t':
						if (!isQuote && !isLineComment)
						{
							if (token != "")
								tokenizedString.Add(token);
							tokenizedString.Add(c.ToString());
							token = "";
						}
						else
							goto default;
						break;

					case '\r':
						break;

					case '"':
						isQuote ^= true;
						goto default;

					case '/':
						if (token == "/")
							isLineComment = true;
						goto default;

					case '\n':
						if (isLineComment)
							isLineComment = false;
						goto case ',';
					case '(':
					case ')':
					case '{':
					case '}':
					case '[':
					case ']':
					case ';':
					case ',':
						if (!isQuote && !isLineComment)
						{
							if (token != "")
								tokenizedString.Add(token);
							token = "";
							tokenizedString.Add(c.ToString());
							token = "";
						}
						else
							goto default;
						break;

					default:
						token += c;
						break;
				}
			}

			return tokenizedString;
		}
	}
}
