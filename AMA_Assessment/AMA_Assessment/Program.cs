using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMA_Assessment
{
    class Handler {
        public static String ShiftingString(String input, int numShift)
        {
            int size = input.Length;
            StringBuilder result = new StringBuilder();
            if(numShift % size == 0) //Case 1: if the number is same as the string size, then it can return the same string directly.
            {
                return input;
            }
            else //Case 2: if the number is not same as the string size, then it can start process the shifting.
            {
                int remainder = numShift % size; //Get the remainder that can avoid wasting resource to loop.
                int startIndex = size - remainder;
                result.Append(input.Substring(startIndex));
                result.Append(input.Substring(0, startIndex));
            }
            return result.ToString(); //The return type is string, hence it has to use .ToString().
        }
        public static Boolean IsLetter(String input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$"); //Check is the string only contains alphabet and whitespace.
        }
        public static Boolean IsVaildNumber(String input)
        {
            int temp;
            bool result = int.TryParse(input, out temp); //Check is the string convertible to integer
            if (!result || temp < 0)
            {
                return false;
            }
            return result;
        }
    }
    class View
    {
        public static String ReadingFirstArg()
        {
            Console.WriteLine("Please enter the word \n Caution: It only accepts letters");
            return Console.ReadLine();
        }
        public static String ReadingSecondArg()
        {
            Console.WriteLine("Please enter the number of shifting the word \n Caution: It only accepts zero or greater number");
            return Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello Welcome to AMA assessment.");
                bool continueProcess = true;
                int attemped = 6; 
                String arg1 = View.ReadingFirstArg();
                while (!Handler.IsLetter(arg1))
                {
                    if (attemped < 1)
                    {
                        continueProcess = false;
                        break;
                    }
                    attemped--;
                    Console.WriteLine("The word you entered has contained non-letter character. Try it again.");
                    Console.WriteLine(attemped + " attemp(s) remaining");
                    arg1 = View.ReadingFirstArg();
                }
                if (!continueProcess) continue; //If the user attemped 6 times invalid input, then return back to the initial.
                String arg2 = View.ReadingSecondArg();
                attemped = 6; //Reset the attemp chances
                while (!Handler.IsVaildNumber(arg2))
                {
                    if (attemped < 1)
                    {
                        continueProcess = false;
                        break;
                    }
                    attemped--;
                    Console.WriteLine("The number you entered is not vaild. Try it again.");
                    Console.WriteLine(attemped + " attemp(s) remaining");
                    arg2 = View.ReadingSecondArg();
                }
                if (!continueProcess) continue; //If the user attemped 6 times invalid input, then return back to the initial.
                int numArg2 = int.Parse(arg2);
                Console.WriteLine(Handler.ShiftingString(arg1, numArg2));
            }
        }
    }
}
