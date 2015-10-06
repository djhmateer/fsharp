using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EulerCSharp
{
    class Euler206
    {
        static void Main206()
        {

            //Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0,
            //where each “_” is a single digit.

            BigInteger maxNumber = 1929394959697989990;
            BigInteger minNumber = 1020304050607080900;

            BigInteger workingNumber = 0;
            BigInteger min = 0, previousInt = 2, currentInt = 2;

            bool correctAnswer;

            while (true)
            {
                currentInt *= 12;
                workingNumber = BigInteger.Pow(currentInt, 2);

                if (workingNumber >= minNumber)
                {
                    break;
                }
                else
                {
                    min = BigInteger.Max(currentInt, min);
                    previousInt = currentInt;
                }

                //Console.WriteLine("Finding Min: {0}", previousInt);
            }

            min = previousInt;
            currentInt = 0;
            //Console.WriteLine("Minimum value found: {0}^2 = {1}", min, BigInteger.Pow(min, 2));

            while (true)
            {
                currentInt += 1;
                workingNumber = BigInteger.Pow(min + currentInt, 2);

                correctAnswer = Regex.IsMatch(workingNumber.ToString(), "^1.2.3.4.5.6.7.8.9.0$");

                if (correctAnswer)
                {
                    Console.WriteLine("Correct answer!!!! {0}^2 = {1}", (min + currentInt), workingNumber);
                    break;
                }
                else
                {
                    //if (currentInt % 100000 == 0)
                    //{
                    //    Console.WriteLine("Incorrect:\t{0}", workingNumber);
                    //    Console.WriteLine("\t\t1_2_3_4_5_6_7_8_9_0");
                    //}
                }
            }

            Console.Read();



            //BigInteger low = 1020304050607080900;
            //var lowsq = Math.Sqrt((long)low);
            //low = (BigInteger)Math.Round(lowsq / 10) * 10;
            //var go = true;
            //var startTime = DateTime.Now;
            //while (go)
            //{
            //    var str = BigInteger.Pow(low, 2).ToString();

            //    if (!(str.IndexOf("0", 18) == 18 
            //        && str.IndexOf("9", 16) == 16 
            //        && str.IndexOf("8", 14) == 14 
            //        && str.IndexOf("7", 12) == 12
            //        && str.IndexOf("6", 10) == 10 
            //        && str.IndexOf("5", 8) == 8 
            //        && str.IndexOf("4", 6) == 6 
            //        && str.IndexOf("3", 4) == 4
            //        && str.IndexOf("2", 2) == 2
            //        && str.IndexOf("1", 0) == 0))
            //    {
            //        low = low + 10;
            //    }
            //    else
            //    {
            //        var endTime = DateTime.Now;
            //        var difference = endTime - startTime;
            //        Console.WriteLine("Success:" + low);
            //        Console.WriteLine(difference);
            //        Console.ReadLine();
            //        go = false;
            //    }
            //}
        }

    }
}
