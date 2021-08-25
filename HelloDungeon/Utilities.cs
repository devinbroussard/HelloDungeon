using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    static class Utilities
    {
        //Function that saves time typing Console.ReadKey()
        public static void WriteRead(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
        }

        //Generic function that asks for user input; can be used multiple times 
        public static int GetInput(string description, string option1, string option2)
        {
            int inputRecieved = 0;

            while (!(inputRecieved == 1 || inputRecieved == 2))
            {
                //Displays character options and asks for input
                Console.WriteLine(description + "\n");
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");
                string getInput = Console.ReadLine().ToLower();

                //Gives player two different outcomes depending on their input
                if (getInput == "1" || getInput == option1.ToLower())
                {
                    inputRecieved = 1;
                }
                else if (getInput == "2" || getInput == option2.ToLower())
                {
                    inputRecieved = 2;
                }
                //..displays error message
                else
                {
                    Console.WriteLine("\nInvalid input!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return inputRecieved;
        }
    }
}
