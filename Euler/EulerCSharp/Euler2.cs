using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerCSharp
{
    class Euler2
    {
        //http://basildoncoder.com/blog/project-euler-problems-1-and-2.html
        static void Main()
        {
            var result = Fibs().TakeWhile(f => f < 4000000).Where(f => f % 2 == 0).Sum();
            Console.WriteLine(result);
        }

        static IEnumerable<long> Fibs()
        {
            long a = 0, b = 1;
            while (true)
            {
                yield return b;
                b = a + b;
                a = b - a;
            }
        }
    }
}
