using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiquidThinkingTest
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Declare vars
            string output = " ";
            bool outputDetails = false;
            DateTime start = DateTime.Now;
            bool exitLoop = false;

            // Check if the array args has elements
            if (args.Length > 1)
            {
                //Take the last argument >> String
                output = args[args.Length - 1];
                //Remove last argument not to break the loop
                args = args.Take(args.Length - 1).ToArray();
                //go through all the args to perform the operations
                foreach (string arg in args)
                {
                    switch (arg)
                    {
                        case "-w":
                            output = methodW(output);
                            break;
                        case "-l":
                            output = methodL(output);
                            break;
                        case "-v":
                            outputDetails = true;
                            break;
                        default:
                            output = helpMethod();
                            exitLoop = true; 
                            break;
                    }
                    //If there's an incorrect parameter
                    if (exitLoop) break;
                }

                //Launch the -v if it was requested
                if (outputDetails)
                {
                    output = methodV(output, start);
                }

            }
            else if (args.Length == 1)
            {
                //Take the last argument >> String
                output = args[args.Length - 1];
                //Check if the string is an option, if so, we show help option
                if (!output.Equals("-w") && !output.Equals("-l") && !output.Equals("-v"))
                {
                    output = "Missing string \n " + helpMethod();
                }
            }
            else
            {
                output = "Missing arguments";
            }

            //Prints the result
            Console.WriteLine(output);
        }

        public static string methodW(string text)
        {
            string[] textArray = text.Split(' ');
            Array.Reverse(textArray);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string str in textArray)
            {
                sb.Append(str + " ");
            }
            return sb.ToString();
        }

        public static string methodL(string text)
        {
            string[] textArray = text.Split(' ');
            char[] charArray;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string str in textArray)
            {
                charArray = str.ToCharArray();
                Array.Reverse(charArray);
                sb.Append(new string(charArray) + " ");
            }
            return sb.ToString();
        }

        public static string methodV(string text, DateTime start)
        {
            string details = string.Format("Reversing {0} words with {1} letters in total:", text.Split(' ').Length, text.Length);
            string timeString = string.Format("Completed in {0} milliseconds", (DateTime.Now - start).TotalMilliseconds);
            return string.Format("{0}\n{1}\n{2}", details, text, timeString);
        }

        public static string helpMethod()
        {
            string help = "usage: LiquidThinkingTest.exe input [-l] [-w] [-v] \n";
            help += "Reverses the string inputs \n";
            help += "-l Reverse the letters in the string \n";
            help += "-w Reverse the words in the string \n";
            help += "-v Verbose mode \n";
            return help;
        }
    }
}

