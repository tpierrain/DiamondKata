namespace Diamonds
{
    using System.Collections.Generic;

    public class NumberProvider
    {
        public IEnumerator<int> GetOddNumbers()
        {
            for (var number = 0; number <= int.MaxValue; number++)
            {
                if (number % 2 == 0)
                {
                    continue;
                }
                yield return number;
            }
        }
    }
}