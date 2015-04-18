namespace Diamonds
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Diamond
    {
        public static string Generate(char letter)
        {
            GuardFromNonUpperCasedLetter(letter);

            if (letter == 'A')
            {
                return "A";
            }

            var diamond = new List<string>();
            
            var leftPaddingSize = letter - 'A';
            var oddNumberProvider = NumberProvider.GetOddNumbers();

            foreach (var character in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
            {
                var leftPadding = string.Empty.PadRight(leftPaddingSize, '.');
                leftPaddingSize--;
                
                var middlePadding = string.Empty.PadRight(oddNumberProvider.Current, '.');
                oddNumberProvider.MoveNext();

                if (character == 'A')
                {
                    diamond.Add(leftPadding + "A");
                }
                else
                {
                    diamond.Add(leftPadding + character.ToString() + middlePadding + character.ToString());
                    if (character == letter)
                    {
                        break;
                    }
                }
            }

            if (diamond.Count > 1)
            {
                var diamondSecondPart = new List<string>();
                for (var lineIndex = diamond.Count-2; lineIndex >= 0; lineIndex--)
                {
                    diamondSecondPart.Add(diamond[lineIndex]);
                }

                diamond.AddRange(diamondSecondPart);
            }

            return diamond.ExportDiamond();
        }

        private static string ExportDiamond(this List<string> list)
        {
            var result = new StringBuilder();
            for(var lineCount = 0; lineCount < list.Count; lineCount++)
            {
                result.Append(list[lineCount]);
                if (lineCount != list.Count - 1)
                {
                    result.Append("\n");
                }
            }

            return result.ToString();
        }

        private static void GuardFromNonUpperCasedLetter(char letter)
        {
            if (letter < 65 || letter > 90)
            {
                throw new ArgumentOutOfRangeException("letter", "Should be an upper cased alphabetical letter");
            }
        }
    }
}