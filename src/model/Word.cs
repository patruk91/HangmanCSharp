using System;
using System.Collections.Generic;

namespace HangmanCSharp.model
{
    public class Word
    {
        private readonly Random _random;

        public Word(Random random)
        {
            this._random = random;
        }

        public Country GetRandomCountry(List<Country> countries)
        {
            const int counterArraySize = 1;
            int randomIndex = _random.Next(0, countries.Count - counterArraySize);
            return countries[randomIndex];
        }


        public string MakeDashWord(Player player, Country secretCountry)
        {
            player.BadGuesses.ToString();
            string dashedWord = "";
            string capital = secretCountry.CapitalName.ToUpper();
            for (int i = 0; i < capital.Length; i++)
            {
                string letter = char.ToString(capital[i]);
                dashedWord += player.GoodGuesses.Contains(letter) ? $"{letter}" : letter == " " ? "   " : " _ ";
            }

            return dashedWord;
        }
    }
}