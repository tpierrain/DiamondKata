namespace Diamonds
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Diamond
    {
        /// <summary>
        /// Generates a diamond ASCII-art figure defined from the specified upper-cased letter.
        /// </summary>
        /// <param name="letter">The upper cased letter to be used for the widest part of the diamond.</param>
        /// <returns>A diamond ASCII-art figure defined by the specified upper-cased letter.</returns>
        public static string GenerateAsciiArtFor(char letter)
        {
            GuardFromNonUpperCasedLetter(letter);

            if (letter == 'A')
            {
                return "A";
            }

            var firstHalf = BuildFirstHalf(letter);
            var completeDiamond = MirrorDiamond(firstHalf);

            return completeDiamond.ToString();
        }

        private static void GuardFromNonUpperCasedLetter(char letter)
        {
            if (letter < 65 || letter > 90)
            {
                throw new ArgumentOutOfRangeException("letter", "Should be an upper cased alphabetical letter");
            }
        }

        private static Diamond BuildFirstHalf(char stopLetter)
        {
            var diamond = new Diamond();

            int externalPaddingCount = stopLetter - 'A';
            IEnumerator<int> oddNumberProvider = new NumberProvider().GetOddNumbers();

            foreach (var character in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
            {
                var externalPadding = string.Empty.PadRight(externalPaddingCount, '.');
                externalPaddingCount--;

                var internalPadding = string.Empty.PadRight(oddNumberProvider.Current, '.');
                oddNumberProvider.MoveNext();

                if (character == 'A')
                {
                    diamond.AddLine(externalPadding + character + internalPadding + externalPadding);
                }
                else
                {
                    diamond.AddLine(externalPadding + character + internalPadding + character + externalPadding);
                }
                
                if (character == stopLetter)
                {
                    break;
                }
            }

            return diamond;
        }

        private static Diamond MirrorDiamond(Diamond incompleteDiamond)
        {
            var mirroredLines = new List<string>();
            for (var lineIndex = incompleteDiamond.LinesCount - 2; lineIndex >= 0; lineIndex--)
            {
                mirroredLines.Add(incompleteDiamond[lineIndex]);
            }

            var fullDiamond = MergeDiamondWithLines(incompleteDiamond, mirroredLines);
            return fullDiamond;
        }

        private static Diamond MergeDiamondWithLines(Diamond incompleteDiamond, IEnumerable<string> linesToAdd)
        {
            var diamond = new Diamond(incompleteDiamond);
            diamond.lines.AddRange(linesToAdd);
            
            return diamond;
        }

        private new string ToString()
        {
            var result = new StringBuilder();
            for(var lineCount = 0; lineCount < this.lines.Count; lineCount++)
            {
                result.Append(this.lines[lineCount]);
                if (this.IsNotLastLine(lineCount))
                {
                    result.Append("\n");
                }
            }

            return result.ToString();
        }

        #region Fields, Constructors & indexer

        private readonly List<string> lines;

        private Diamond()
        {
            this.lines = new List<string>();
        }

        private Diamond(Diamond diamond)
        {
            this.lines = new List<string>(diamond.lines);
        }

        private string this[int lineIndex]
        {
            get
            {
                return this.lines[lineIndex];
            }
        }

        #endregion

        private bool IsNotLastLine(int lineCount)
        {
            return lineCount != this.lines.Count - 1;
        }

        private void AddLine(string line)
        {
            this.lines.Add(line);
        }

        private int LinesCount
        {
            get
            {
                return this.lines.Count;
            }
        }
    }
}