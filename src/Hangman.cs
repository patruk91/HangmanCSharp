using System;
using HangmanCSharp.controller;
using HangmanCSharp.view;

namespace HangmanCSharp
{
    class Hangman
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.run();
        }
    }
}
