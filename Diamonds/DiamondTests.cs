namespace Diamonds
{
    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void ShouldPrintLetterA()
        {
            Check.That(DiamondPrinter.Print("A")).IsEqualTo("A");
        }

        public static class DiamondPrinter
        {
            public static string Print(string letter)
            {
                return letter;
            }
        }
    }
}
