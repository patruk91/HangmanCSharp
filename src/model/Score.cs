using System;

namespace HangmanCSharp.model
{
    public class Score
    {
        private readonly string _name;
        private readonly DateTime _dateTime;
        private readonly int _time;
        private readonly int _tries;
        private readonly int _capital;

        public Score(string name, DateTime dateTime, int time, int tries, int capital)
        {
            _name = name;
            _dateTime = dateTime;
            _time = time;
            _tries = tries;
            _capital = capital;
        }

        public override string ToString()
        {
            return $"{_name} | {_dateTime.Date} | {_time} | {_tries} | {_capital}";
        }
    }
}