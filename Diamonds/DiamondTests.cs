namespace Diamonds
{
    using System;
    using System.Security.Cryptography;

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
        public void ShouldDisplayDiamond()
        {
            Check.That(Diamond.Generate('D')).IsEqualTo("...A\n"+
                                                        "..B.B\n"+
                                                        ".C...C\n"+
                                                        "D.....D\n"+
                                                        ".C...C\n" +
                                                        "..B.B\n" +
                                                        "...A");
        }
    }
}
