namespace Diamonds.Tests
{
    using System;
    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void ShouldGenerateAsciiArtForA()
        {
            Check.That(Diamond.GenerateAsciiArtFor('A')).IsEqualTo("A");
        }
       
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowAnExceptionWhenNotAnUpperCaseLetter()
        {
            Check.That(Diamond.GenerateAsciiArtFor('a')).IsEqualTo("A");
        }

        // Following the strategy suggested by Seb Rose, the next test has been successfully 
        // recycled to cover a new property at a time. In my case: 
        // 
        //  - ShouldGenerateLettersInTheProperOrder()   // ABC
        //  - ShouldGenerateDoubleLetters()             // ABBCC
        //  - ShouldGenerateLettersInMirror()           // ABBCCBBA
        //  - ShouldGenerateALineForEveryLetter()       // A\nBB\nCC\nBB\nA
        //  - ShouldIntroduceLeftPadding()              // ....
        //  - ShouldIntroduceMiddlePadding()
        //    ...
        //  - ShouldGenerateAsciiArtForD()
        [Test]
        public void ShouldGenerateAsciiArtForD()
        {
            Check.That(Diamond.GenerateAsciiArtFor('D')).IsEqualTo( "...A...\n"+
                                                                    "..B.B..\n"+
                                                                    ".C...C.\n"+
                                                                    "D.....D\n"+
                                                                    ".C...C.\n" +
                                                                    "..B.B..\n" +
                                                                    "...A...");
        }
    }
}
