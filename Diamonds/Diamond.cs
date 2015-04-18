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

            List<string> diamond = BuildFirstHalf(letter);

            if (diamond.Count > 1)
            {
                diamond = BuildFullDiamond(diamond);
            }

            return ToString(diamond);
        }

        private static List<string> BuildFullDiamond(IReadOnlyList<string> diamond)
        {
            var result = new List<string>(diamond);

            var diamondSecondPart = new List<string>();
            for (var lineIndex = diamond.Count - 2; lineIndex >= 0; lineIndex--)
            {
                diamondSecondPart.Add(diamond[lineIndex]);
            }

            result.AddRange(diamondSecondPart);
            return result;
        }

        private static List<string> BuildFirstHalf(char letter)
        {
            var diamond = new List<string>();

            int leftPaddingCount = letter - 'A';
            IEnumerator<int> oddNumberProvider = new NumberProvider().GetOddNumbers();

            foreach (var character in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
            {
                var leftPadding = string.Empty.PadRight(leftPaddingCount, '.');
                leftPaddingCount--;

                var middlePadding = string.Empty.PadRight(oddNumberProvider.Current, '.');
                oddNumberProvider.MoveNext();

                if (character == 'A')
                {
                    diamond.Add(leftPadding + character + middlePadding);
                }
                else
                {
                    diamond.Add(leftPadding + character + middlePadding + character);
                }
                
                if (character == letter)
                {
                    break;
                }
            }

            return diamond;
        }

        private static string ToString(this List<string> list)
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