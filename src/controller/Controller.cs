using System;
using System.Collections.Generic;
using System.Linq;
using HangmanCSharp.dao.dataManager;
using HangmanCSharp.model;
using HangmanCSharp.time;
using HangmanCSharp.view;

namespace HangmanCSharp.controller
{
    public class Controller
    {
        private readonly View _view;
        private readonly Validator _validator;
        private readonly Reader _reader;
        private readonly FileManager _fileManager;
        private readonly Word _word;
        private readonly Timer _timer;
        private readonly List<Country> _countries;
        private bool _gameWon;

        public Controller(View view, Reader reader, FileManager fileManager, Word word, Timer timer, Validator validator)
        {
            _view = view;
            _validator = validator;
            _reader = reader;
            _fileManager = fileManager;
            _word = word;
            _timer = timer;
            _countries = fileManager.GetCountries();
            _gameWon = false;
        }

        public void Run(string[] args)
        {
            Console.Clear();
            _view.DisplayString("Please enter your name:");
            string userName = _reader.GetNotEmptyString();
            Player player = new Player(userName);
            Draw draw = new Draw(_view);

            bool quitGame = false;
            while (!quitGame)
            {
                Country secretCountry = _word.GetRandomCountry(_countries);
                _timer.StartTime();
                HandleGame(args, draw, player, secretCountry);
                quitGame = Restart(player);
            }
        }

        private void HandleGame(string[] args, Draw draw, Player player, Country secretCountry)
        {
            do
            {
                Console.Clear();
                draw.DisplayHangman(player.Lives);
                DisplaySecretWordInDemonstrationMode(args, secretCountry);
                DisplayPlayerInformation(player, secretCountry);
                GetHint(player, secretCountry);
                string userGuess = _reader.GetNotEmptyString().ToUpper();
                if (userGuess.Length > 1)
                {
                    HandleWordGuess(secretCountry, userGuess, player);
                }
                else
                {
                    HandleLetterGuess(secretCountry, userGuess, player);
                }

                player.IncreaseTries();
                HandleWinScreen(player, secretCountry, draw);
            } while (player.Lives > 0 && !_gameWon);
        }

        private void GetHint(Player player, Country country)
        {
            if (player.Lives <= 5)
            {
                _view.DisplayMessage("HINT: The capital of: " + country.CountryName);
            }
        }

        private bool Restart(Player player)
        {
            _view.DisplayMessage("Do you want to continue? (y/n): ");
            string restart = _reader.GetNotEmptyString();
            bool quitGame = PlayAgain(restart, player);
            return quitGame;
        }
        private void HandleWinScreen(Player player, Country secretCountry, Draw draw)
        {
            if (_gameWon)
            {
                Console.Clear();
                _timer.EndTime();
                int totalTimeTaken = _timer.TotalTimeTakenInSeconds();
                DisplayWinScreen(player, totalTimeTaken, secretCountry.CapitalName);
                SaveScoreToFile(player, secretCountry, totalTimeTaken);
            }
            else if (player.Lives <= 0)
            {
                Console.Clear();
                _view.DisplayMessage("YOU LOSE!");
                draw.DisplayHangman(player.Lives);
            }
        }

        private void SaveScoreToFile(Player player, Country secretCountry, int totalTimeTaken)
        {
            string pathToSave = @"F:\C#\PROJECTS\HangmanCSharp\HangmanCSharp\resources\Score.txt";
            DateTime dateTime = DateTime.Now;
            Score score = new Score(player.Name, dateTime, totalTimeTaken, player.Tries, secretCountry.CapitalName);
            _fileManager.SaveToFile(pathToSave, score.ToString());
        }

        private void HandleLetterGuess(Country secretCountry, string userGuess, Player player)
        {
            if (!secretCountry.CapitalName.Contains(userGuess) && !player.BadGuesses.Contains(userGuess))
            {
                const int amountToDecrease = 1;
                player.DecreaseLives(amountToDecrease);
                player.AddBadGuess(userGuess);
            }
            else
            {
                player.AddGoodGuess(userGuess);
                _gameWon = player.GoodGuesses.Count == secretCountry.CapitalName.Select(x => x).Distinct().Count();
            }
        }

        private void HandleWordGuess(Country secretCountry, string userGuess, Player player)
        {
            if (_validator.IsACorrectWord(secretCountry, userGuess))
            {
                _gameWon = true;
            }
            else
            {
                const int amountToDecrease = 2;
                player.DecreaseLives(amountToDecrease);
                player.AddBadGuess(userGuess);
            }
        }

        private bool PlayAgain(string restart, Player player)
        {
            if (restart == "y")
            {
                player.ResetPlayerStatsToDefault();
                return false;
            }
            return true;
        }

        private void DisplayWinScreen(Player player, int totalTime, string capital)
        {
            Console.WriteLine($"{player.Name} you guessed after {player.Tries} tries." +
                              $" It took you {totalTime} seconds. Capital: {capital}");
        }

        private void DisplayPlayerInformation(Player player, Country secretCountry)
        {
            Console.WriteLine("Lives: " + player.Lives);
            Console.WriteLine("Tries: " + player.Tries);
            Console.WriteLine("User fault letters/words: " + string.Join(",", player.BadGuesses));
            Console.WriteLine("User good letters/words: " + string.Join(",", player.GoodGuesses));
            Console.WriteLine(_word.MakeDashWord(player, secretCountry));
        }

        private void DisplaySecretWordInDemonstrationMode(string[] args, Country secretCountry)
        {
            if (args.Length > 0 && args[0] == ("-demo"))
            {
                _view.DisplayMessage($"Secret word: [{secretCountry}]");
            }
        }
    }
}