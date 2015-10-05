using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EulerCSharp
{
    class Euler1
    {
        static void Main()
        {
            // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
            // Find the sum of all the multiples of 3 or 5 below 1000.

            // Iterative approach
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i%3 == 0 || i % 5 == 0) sum += i;
            }
            Console.WriteLine(sum);

            // F# inspired solution - using IEnumerable
            var result = Enumerable.Range(1, 999).Where(x => x%3==0 || x%5==0).Sum();
            Console.WriteLine(result);
        }
    }
}
