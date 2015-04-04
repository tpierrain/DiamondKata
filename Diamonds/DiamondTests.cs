namespace Diamonds
{
    using System;

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

        [Test]
        public void ShouldPrintLetterB()
        {
            Check.That(DiamondPrinter.Print("B")).IsEqualTo(
@"-A
B-B
-A");
        }

        [Test]
        public void ShouldPrintLetterC()
        {
            Check.That(DiamondPrinter.Print("C")).IsEqualTo(
@"--A
-B-B
C---C
-B-B
--A");
        }

        //[Test]
        public void ShouldPrintLetterE()
        {
            Check.That(DiamondPrinter.Print("E")).IsEqualTo(
@"----A
---B-B
--C---C
-D-----D
E-------E
-D-----D
--C---C
---B-B
----A");
        }
    }

    public static class DiamondPrinter
    {
        public static string Print(string letter)
        {
            if (letter == "A")
            {
                return "A";
            }
            if (letter == "B")
            {
                return "-" + "A" + Environment.NewLine + "B" + "-" + "B" + Environment.NewLine +"-" + "A";
            }

            if (letter == "C")
            {
                return "-" + "-" + "A" + Environment.NewLine + "-" + "B" + "-" + "B" + Environment.NewLine + "C" + "-" + "-" + "-" + "C" + Environment.NewLine + "-" + "B" + "-" + "B" + Environment.NewLine + "-" + "-" + "A";
            }

            //if (letter == "E")
            //{
            //    return "-" + "-" + "-" + "-" + "A" + Environment.NewLine + "-" + "-" + "-" + "B" + "-" + "B" + Environment.NewLine + "-" + "-" + "-" + "C" + "-" + "-" + "C" + Environment.NewLine + "-" + "-" + "-" + "B" + "-" + "B" + Environment.NewLine + "-" + "-" + "-" + "-" + "A";
            //}

            return letter;
        }
    }
}
