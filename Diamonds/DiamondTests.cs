namespace Diamonds
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void ShouldDisplayA()
        {
            Check.That(Diamond.Generate('A')).IsEqualTo("A");
        }
       
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowAnExceptionWhenNotAnUpperCaseLetter()
        {
            Check.That(Diamond.Generate('a')).IsEqualTo("A");
        }

        [Test]
        public void ShouldDisplayLettersInTheOrder()
        {
            Check.That(Diamond.Generate('B')).IsEqualTo("ABBA");
        }
    }

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

            foreach (var character in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
            {
                if (character == 'A')
                {
                    diamond.Add("A");
                }
                else
                {
                    //string leftPadding = ".";
                    //diamond.Add(leftPadding);
                    diamond.Add(character.ToString()+character.ToString());
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
                //if (lineCount != list.Count - 1)
                //{
                //    result.Append("\n");
                //}
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
