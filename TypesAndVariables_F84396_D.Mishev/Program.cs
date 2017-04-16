using System;

namespace TypesAndVariables_F84396_D.Mishev
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Problem 1.	Declare Variables

            Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, 
            uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000. Choose a large enough type for 
            each number to ensure it will fit in it. Try to compile the code. Submit the source code of your Visual Studio project 
            as part of your homework submission.
            */
            ushort V1 = 52130;
            sbyte V2 = -115;
            int V3 = 4825932;
            byte V4 = 97;
            short V5 = -10000;
            Console.WriteLine("Problem 1.");
            Console.WriteLine("52130 = " + V1);
            Console.WriteLine("-115 = " + V2);
            Console.WriteLine("4825932 = " + V3);
            Console.WriteLine("97 = " + V4);
            Console.WriteLine("-10000 = " + V5);
            Console.WriteLine();

            /*
            Problem 2.	Float or Double?

            Which of the following values can be assigned to a variable of type float and which to a variable of type 
            double: 34.567839023, 12.345, 8923.1234857, 3456.091? Write a program to assign the numbers in variables and print them 
            to ensure no precision is lost.
            */
            var V6 = 34.567839023D;
            var V7 = 12.345F;
            var V8 = 8923.1234857D;
            var V9 = 3456.091F;
            Console.WriteLine("Problem 2.");
            Console.WriteLine("34.567839023 = " + V6);
            Console.WriteLine("12.345 = " + V7);
            Console.WriteLine("8923.1234857 = " + V8);
            Console.WriteLine("3456.091 = " + V9);
            Console.WriteLine();

            /*
            Problem 3.Boolean Variable

            Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender. Print it on the
            console.
            */
            Boolean isFemale = false;
            Console.WriteLine("Problem 3.");
            Console.WriteLine("false = " + isFemale);
            Console.WriteLine();

            /*
            Problem 4.	Strings and Objects

            Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the 
            concatenation of the first two variables (mind adding an interval between). Declare a third string variable and 
            initialize it with the value of the object variable (you should perform type casting).
            */
            string V10 = "Hello";
            string V11 = "World";
            Object V12 = (V10 + " " + V11);
            string V13 = (string)V12;
            Console.WriteLine("Problem 4.");
            Console.WriteLine(V13);
            Console.WriteLine();

            /*
            Problem 5.	Employee Data

            A marketing company wants to keep record of its employees. Each record would have the following characteristics:
            •	First name
            •	Last name
            •	Age (0...100)
            •	Gender (m or f)
            •	Personal ID number (e.g. 8306112507)
            •	Unique employee number (27560000…27569999)

            Declare the variables needed to keep the information for a single employee using appropriate primitive data types. 
            Use descriptive names. Print the data at the console.
            */
            MarketingPOCO V14 = new MarketingPOCO();
            V14.FirstName = "Billy";
            V14.LastName = "Bob";
            V14.Age = 64;
            V14.Gender = "Male";
            V14.PersonalID = 104;
            V14.EmployeeNumber = 27560002;

            Console.WriteLine("Problem 5.");
            Console.WriteLine("Billy : " + V14.FirstName);
            Console.WriteLine("Last Name: " + V14.LastName);
            Console.WriteLine("Age : " + V14.Age);
            Console.WriteLine("Gender : " + V14.Gender);
            Console.WriteLine("Personal ID : " + V14.PersonalID);
            Console.WriteLine("Employee number: " + V14.EmployeeNumber);
        }
    }
}
