using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Baja
{
    public enum Token
    {
        EOF = -1,
        DEF = -2,
        EXTERN = -3,
        IDENTIFIER = -4,
        NUMBER = -5,
    }

    public class Lexer
    {
        private string identifier;
        private double numVal;
        private const int EOF = -1;
        private readonly TextReader reader;
        private readonly StringBuilder identifierBuilder = new();
        private readonly StringBuilder numberBuilder = new();
        private readonly Dictionary<char, int> binopPrecedence;

        public string GetLastIdentifier()
        {
            return this.identifier;
        }

        public double GetLastNumber()
        {
            return this.numVal;
        }

        public int GetNextTokenImpl()
        {
            int c = ' ';
            // Skip any whitespace
            while (char.IsWhiteSpace((char)c))
            {
                c = this.reader.Read();
            }

            if (char.IsLetter((char) c)) // identifier: [a-zA-Z][a-zA-Z0-9]*
            {
                this.identifierBuilder.Append((char) c);
                while (char.IsLetterOrDigit((char)(c = this.reader.Read())))
                {
                    this.identifierBuilder.Append((char)c);
                }

                this.identifier = this.identifierBuilder.ToString();
                this.identifierBuilder.Clear();

                if (string.Equals(identifier, "def", StringComparison.Ordinal))
                {
                    return (int)Token.DEF;
                }
                else if (string.Equals(identifier, "extern", StringComparison.Ordinal))
                {
                    return (int)Token.EXTERN;
                }
                else
                {
                    return (int)Token.IDENTIFIER;
                }
            }

            // Number: [0-9.]+
            if (char.IsDigit((char) c) || c == '.')
            {
                do
                {
                    this.numberBuilder.Append((char)c);
                    c = this.reader.Read();
                } while (char.IsDigit((char)c) || c == '.');
                this.numVal = double.Parse(this.numberBuilder.ToString());
                this.numberBuilder.Clear();
                return (int)Token.NUMBER;
            }

            if (c == '#')
            {
                // Comment until end of line.
                do
                {
                    c = this.reader.Read();
                } while (c != EOF && c != '\n' && c != '\r');

                if (c != EOF)
                {
                    return this.GetNextTokenImpl();
                }
            }

            // Check for end of file. Don't eat the EOF.
            if (c == EOF)
            {
                return (int)Token.EOF;
            }

            return this.reader.Read();
        }
    }
}
