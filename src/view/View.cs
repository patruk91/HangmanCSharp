using System;

namespace HangmanCSharp.view
{
    public class View
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayString(string message)
        {
            Console.Write(message);
        }

        public void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}!");
        }
    }
}