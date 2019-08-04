using System;
using HangmanCSharp.model;

namespace HangmanCSharp.view
{
    public class Validator
    {
        public bool IsInputEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public bool IsACorrectWord(Country secretCountry, string userGuess)
        {
            return string.Equals(secretCountry.CapitalName, userGuess, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}