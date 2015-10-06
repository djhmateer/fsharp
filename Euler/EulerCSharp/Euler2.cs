using System;
using System.Linq;

namespace EulerCSharp
{
    class Euler2
    {
        static void Main()
        {
            //Calculate the sum of all even Fibonacci numbers that are less than 4 million
            int previousValue = 0, newValue = 1;
            int answer = 0;

            while (true)
            {
                //Generate the next number in the sequence
                int tempValue = previousValue + newValue;

                //Check it's still less than 4 million
                if (tempValue > 4000000)
                    break;

                //Check if it's even, if it is add it to the answer value
                if (tempValue % 2 == 0)
                    answer += tempValue;

                //Move the values around so that we don't store anything more than the last two numbers in the sequence 
                previousValue = newValue;
                newValue = tempValue;
            }

            Console.WriteLine("Answer is: {0}", answer);
            Console.WriteLine($"Answer is: {answer}");
            Console.ReadLine();

        }
    }
}
