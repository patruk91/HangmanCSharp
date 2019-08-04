using System;
using HangmanCSharp.controller;
using HangmanCSharp.dao.dataManager;
using HangmanCSharp.model;
using HangmanCSharp.time;
using HangmanCSharp.view;

namespace HangmanCSharp
{
    class Hangman
    {
        static void Main(string[] args)
        {
            View view = new View();
            Validator validator = new Validator();
            Reader reader = new Reader(view, validator);
            FileManager fileManager = new FileManager();
            Word word = new Word(new Random());
            Timer timer = new Timer();
            Controller controller = new Controller(view, reader, fileManager, word, timer, validator);
            controller.Run(args);
        }
    }
}
