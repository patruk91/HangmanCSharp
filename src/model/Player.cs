using System.Collections.Generic;

namespace HangmanCSharp.model
{
    public class Player
    {
        private List<string> GoodGuesses;
        private List<string> BadGuesses;

        public Player(string name)
        {
            GoodGuesses = new List<string>();
            BadGuesses = new List<string>();
            Tries = 0;
            Lives = 10;
            Name = name;
        }

        public int Tries { get; private set; }
        public int Lives { get; private set; }
        public string Name { get; set; }
        public List<string> GetGoodGuesses { get; }
        public List<string> GetBadGuesses { get; }

        public void AddGoodGuess(string guess)
        {
            GoodGuesses.Add(guess);
        }

        public void AddBadGuess(string guess)
        {
            BadGuesses.Add(guess);
        }

        public void IncreaseTries()
        {
            Tries++;
        }

        public void DecreaseLives(int amount)
        {
            Lives -= amount;
        }

        public void ResetPlayerStatsToDefault()
        {
            Lives = 10;
            Tries = 0;
            BadGuesses.Clear();
            GoodGuesses.Clear();
        }
    }
}