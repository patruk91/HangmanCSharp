using System;
using System.Diagnostics;

namespace HangmanCSharp.time
{
    public class Timer
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        
        public void StartTime()
        {
            _stopwatch.Start();
        }

        public void EndTime()
        {
            _stopwatch.Stop();
        }

        public int TotalTimeTakenInSeconds()
        {
            return Convert.ToInt32(_stopwatch.ElapsedMilliseconds / 1000);
        }



    }
}