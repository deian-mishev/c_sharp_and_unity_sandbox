using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops_F84396_D.Mishev
{
    class Program
    {
        public static bool Problem1()
        {
            try
            {
                Console.Write("Enter a positive integer: ");
                uint n = uint.Parse(Console.ReadLine());
                for (uint i = 1; i <= n; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine(";");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid positive integer!");
                return false;
            }
        }

        public static bool Problem2()
        {
            try
            {
                Console.Write("Enter a positive integer: ");
                uint n = uint.Parse(Console.ReadLine());
                for (uint i = 1; i <= n; i++)
                {
                    if (i % 3 != 0 && i % 7 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine(";");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid positive integer!");
                return false;
            }
        }

        public static bool Problem3()
        {
            List<int> numberList = new List<int>();
            Console.Write("Enter the number of integers to process: ");
            try
            {
                byte n = byte.Parse(Console.ReadLine());
                for (uint i = 0; i < n; i++)
                {
                    Console.Write("Enter integer number " + (i + 1) + " : ");
                    numberList.Add(int.Parse(Console.ReadLine()));
                }
                Console.WriteLine("Results:");
                Console.WriteLine("Min value: " + numberList.Min());
                Console.WriteLine("Max value: " + numberList.Max());
                Console.WriteLine("Sum value: " + numberList.Sum());
                Console.WriteLine("Avg value: " + Math.Round((decimal)numberList.Average(), 2));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid integer!");
                return false;
            }
        }

        public static bool Problem4()
        {
            try
            {
                Console.WriteLine("Enter integers 'n' and 'k' where (1 < k < n < 100);");
                Console.Write("k : ");
                double k = double.Parse(Console.ReadLine());
                Console.Write("n : ");
                double n = double.Parse(Console.ReadLine());
                if (1 < k && k < n && n < 100)
                {
                    double factorialN = 1;
                    double factorialK = 1;
                    for (int i = 1; i <= n; i++)
                    {
                        factorialN *= i;
                        if (i <= k)
                        {
                            factorialK *= i;
                        }
                    }
                    Console.WriteLine("The result of n!/k! is : " + (factorialN / factorialK));
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid input!");
                return false;
            }
        }

        public static bool Problem5()
        {
            try
            {
                Console.WriteLine("Enter an integer 'n' where (1 <= n <= 20);");
                byte n = byte.Parse(Console.ReadLine());
                if (1 <= n && n <= 20)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int m = 1 + i; m <= n + i; m++)
                        {
                            Console.Write(m);
                            if (m >= 10)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("  ");
                            }
                        }
                        Console.WriteLine();
                    }
                    return true;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid input!");
                return false;
            }
        }

        static void Main(string[] args)
        {
            /*
            Problem 1.
            Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single
            line, separated by a space
            */
            Console.WriteLine("Problem 1.");
            while (!Problem1()) { };
            Console.WriteLine();

            /*
            Problem 2.
            Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible
            by 3 and 7, on a single line, separated by a space.
            */
            Console.WriteLine("Problem 2.");
            while (!Problem2()) { };
            Console.WriteLine();

            /*
            Problem 3.
            Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal
            number, the sum and the average of all numbers(displayed with 2 digits after the decimal point).The input starts by
            the number n (alone in a line) followed by n lines, each holding an integer number. 
            */
            Console.WriteLine("Problem 3.");
            while (!Problem3()) { };
            Console.WriteLine();

            /*
            Problem 4.
            Write a program that calculates n! / k! for given n and k(1 < k < n < 100).Use only one loop
            */
            Console.WriteLine("Problem 4.");
            while (!Problem4()) { };
            Console.WriteLine();

            /*
            Problem 5.
            Write a program that reads from the console a positive integer number n(1 ≤ n ≤ 20) and prints a matrix like in the
            examples below.Use two nested loops.
            */
            Console.WriteLine("Problem 5.");
            while (!Problem5()) { };
            Console.WriteLine();
        }
    }
}