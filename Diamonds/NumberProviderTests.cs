namespace Diamonds
{
    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class NumberProviderTests
    {
        [Test]
        public void ShouldProvideOddNumbersOnly()
        {
            var oddNumbers = new NumberProvider().GetOddNumbers();

            Check.That(oddNumbers.Current).IsEqualTo(0);

            oddNumbers.MoveNext();
            Check.That(oddNumbers.Current).IsEqualTo(1);

            oddNumbers.MoveNext();
            Check.That(oddNumbers.Current).IsEqualTo(3);

            oddNumbers.MoveNext();
            Check.That(oddNumbers.Current).IsEqualTo(5);

            oddNumbers.MoveNext();
            Check.That(oddNumbers.Current).IsEqualTo(7);

            oddNumbers.MoveNext();
            Check.That(oddNumbers.Current).IsEqualTo(9);
        }
    }
}
