using System;
using System.Linq;

namespace ConditionalStatements_F84396_D.Mishev
{
    class Program
    {
        public static void Problem1(float V1,float V2)
        {
            Console.Write("For "+ V1 + " " + V2);
            if (V1 > V2)
            {
                float V3 = V1;
                V1 = V2;
                V2 = V3;
            }
            Console.WriteLine(" = " + V1 + " " + V2);
        }

        public static void Problem2(int V4)
        {
            Console.Write("For " + V4);
            if (V4 <= 0 || V4 > 9)
            {
                Console.WriteLine(" = invalid score");
            }
            else {
                if (V4 >= 1 && V4 <= 3)
                {
                    V4 *= 10;
                }
                else if (V4 >= 4 && V4 <= 6)
                {
                    V4 *= 100;
                }
                else if (V4 >= 7 && V4 <= 9)
                {
                    V4 *= 1000;
                }
                Console.WriteLine(" = " + V4);
            }
        } 

        public static void Problem3(object V5)
        {
            int[] validCardValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 74, 81, 75, 65 };

            Console.Write("Card '" + V5.ToString() + "'");
            try
            {
                char V6 = Convert.ToChar(V5);
                int value = Convert.ToInt16(V6);
                if (validCardValues.Contains(value))
                {
                    Console.WriteLine(" IS in a standart stack!");
                }
                else
                {
                    Console.WriteLine(" is NOT in a standart stack!");
                }
            }
            catch (InvalidCastException e) {
                Console.WriteLine(" is NOT in a standart stack!");
            }
        }

        public static void Problem4(Object a, Object b, Object c)
        {
            try
            {
                double V7 = Convert.ToDouble(a);
                double V8 = Convert.ToDouble(b);
                double V9 = Convert.ToDouble(c);
                Console.Write("For " + V7 + " " + V8 + " " + V9);
                if (V7 == 0 || V8 == 0 || V9 == 0)
                {
                    Console.WriteLine(" Result: 0");
                }
                else if ((V7 < 0 && (V8 > 0 && V9 > 0)) || (V8 < 0 && (V7 > 0 && V9 > 0)) || (V9 < 0 && (V7 > 0 && V8 > 0)) || (V8 < 0 && V9 < 0 && V7 < 0))
                {
                        Console.WriteLine(" Result: -");
                    }
                else
                {
                        Console.WriteLine(" Result: +");
                    }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(" is NOT in a standart stack!");
            }
        }

        static void Main(string[] args)
        {
            /*
            Problem 1.Exchange If Greater
            Write an if-statement that takes two integer variables a and b and exchanges their values if the first one
            is greater than the second one. As a result print the values a and b, separated by a space. 

            Examples:
                        a b       result
            5       2       2 5
            3       4       3 4
            5.5     4.5     4.5 5.5
            */
            Console.WriteLine("Problem 1.");
            Problem1(5, 2);
            Problem1(3, 4);
            Problem1(5.5F, 4.5F);
            Console.WriteLine();

            /*
            Problem 2.Bonus Score
            Write a program that applies bonus score to given score in the range[1…9] by the following rules:
            •	If the score is between 1 and 3, the program multiplies it by 10.
            •	If the score is between 4 and 6, the program multiplies it by 100.
            •	If the score is between 7 and 9, the program multiplies it by 1000.
            •	If the score is 0 or more than 9, the program prints “invalid score”.

            Examples:
                        score result
            2       20
            4       400
            9       9000
            - 1      invalid score
            10      invalid score
            */
            Console.WriteLine("Problem 2.");
            Problem2(2);
            Problem2(4);
            Problem2(9);
            Problem2(-1);
            Problem2(10);
            Console.WriteLine();

            /*
            Problem 3.Check for a Play Card
            Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
            Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise.

            Examples:
            character Valid card sign?
            5           yes
            1           no
            Q           yes
            q           no
            P           no
            10          yes
            500         no
            */
            Console.WriteLine("Problem 3.");
            Problem3(5);
            Problem3(1);
            Problem3('Q');
            Problem3('q');
            Problem3('P');
            Problem3(10);
            Problem3(500);
            Console.WriteLine();

            /*
            Problem 4.Multiplication Sign
            Write a program that shows the sign (+, -or 0) of the product of three real numbers, without calculating it.
            Use a sequence of if operators.

            Examples:
            a b       c result
            5    2   2   +
            -2 - 2   1   +
            -2   4   3   -
            0 - 2.5  4   0
            - 1 - 0.5 - 5.1 -
            */
            Console.WriteLine("Problem 4.");
            Problem4(5, 2, 2);
            Problem4(-2, -2, 1);
            Problem4(-2, 4, 3);
            Problem4(0, -2.5, 4);
            Problem4(-1, -0.5, -5.1);
            Console.WriteLine();
        }
    }
}
