using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedTopics_F84396_D.Mishev
{
    class Program
    {
        public static bool Problem1()
        {
            try
            {
                DateTime d1;
                DateTime d2;

                Console.WriteLine("Enter two dates int the format dd.MM.yyyy: ");
                Console.Write("Date 1: ");
                string line = Console.ReadLine();
                while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {
                    Console.WriteLine("Invalid date, please retry");
                    Console.Write("Date 1: ");
                    line = Console.ReadLine();
                }
                Console.Write("Date 2: ");
                line = Console.ReadLine();
                while (!DateTime.TryParseExact(line, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
                {
                    Console.WriteLine("Invalid date, please retry");
                    Console.Write("Date 2: ");
                    line = Console.ReadLine();
                }
                TimeSpan difference = d1 - d2;
                Console.WriteLine("Total time between those: " + Math.Abs(difference.TotalDays)  + ";");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid date!");
                return false;
            }
        }

        public static bool Problem2()
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
                Console.WriteLine("Sort Results:");
                numberList.Sort();
                foreach (int i in numberList) Console.Write(i + " ");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid integer!");
                return false;
            }
        }

        public static bool Problem3()
        {
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            Console.WriteLine("Enter two list with values separated by empty spaces (John Marry David): ");
            try
            {
                Console.Write("Enter first list : ");
                list1 = Console.ReadLine().Split(' ').Select(p => p.Trim()).ToList();

                Console.Write("Enter second list : ");
                list2 = Console.ReadLine().Split(' ').Select(p => p.Trim()).ToList();

                int count = list1.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    if (list2.Contains(list1.ElementAt(i)))
                        list1.RemoveAt(i);
                }
                Console.WriteLine("Filtered (first - second):");
                list1.ForEach(i => Console.Write(i + " "));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid list!");
                return false;
            }
        }

        public static bool Problem4()
        {
            List<string> list1 = new List<string>();
            Console.WriteLine("Enter any text: ");
            try
            {
                list1 = Console.ReadLine().Split(' ').Select(p => p.Trim()).ToList();
                IOrderedEnumerable<string> sorted = list1.OrderByDescending(n => n.Length);
                Console.Write("Longest word(s): ");
                int longestLength = sorted.FirstOrDefault().Length;
                foreach (var element in sorted)
                {
                    if (element.Length == longestLength)
                    {
                        Console.Write(element + " ");
                    }
                    else {
                        break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not a valid text!");
                return false;
            }
        }

        public static bool Problem5()
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

        static void Main(string[] args)
        {
            /*
            Problem 1.
            Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them.
            */
            Console.WriteLine("Problem 1.");
            while (!Problem1()) { };
            Console.WriteLine();

            /*
            Problem 2.
            Write a program that reads a number n and a sequence of n integers, sorts them and prints them.
            */

            Console.WriteLine("Problem 2.");
            while (!Problem2()) { };
            Console.WriteLine();

            /*
            Problem 3.
            Write a program that takes as input two lists of names and removes from the first list all names given in the
            second list.
            */
            Console.WriteLine("Problem 3.");
            while (!Problem3()) { };
            Console.WriteLine();

            /*
            Problem 4.
            Write a program to find the longest word in a text.
            */
            Console.WriteLine("Problem 4.");
            while (!Problem4()) { };
            Console.WriteLine();

            /*
            Problem 5.
            Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal
            number, the sum and the average of all numbers(displayed with 2 digits after the decimal point).The input starts by
            the number n(alone in a line) followed by n lines, each holding an integer number.DO NOT USE LOOPS FOR CALCULATIONS!!!
            */

            Console.WriteLine("Problem 5.");
            while (!Problem5()) { };
            Console.WriteLine();
        }
    }
}
