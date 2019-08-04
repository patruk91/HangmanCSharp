using System.Collections.Generic;
using HangmanCSharp.dao.dataManager;

namespace HangmanCSharp.view
{
    public class Draw
    {
        private readonly FileManager _fileManager = new FileManager();
        private View _view;

        public Draw(View view)
        {
            _view = view;
        }

        public void DisplayHangman(int userLives)
        {
            List<string> hangmenDraws =
                _fileManager.ReadFile(@"F:\C#\PROJECTS\HangmanCSharp\HangmanCSharp\resources\draw_hangman.txt");
            DrawHangman(userLives, hangmenDraws);
        }

        private void DrawHangman(int userLives, List<string> hangmenDraws)
        {
            int sizeOfHangmanAsciiArt = 10;
            Dictionary<int, int> hangmanDraw = LivesAndDrawLineNumber(sizeOfHangmanAsciiArt);
            for (int i = 0; i < sizeOfHangmanAsciiArt; i++)
            {
                int currentLine = hangmanDraw[userLives];
                _view.DisplayMessage(hangmenDraws[i + currentLine]);
            }
        }

        private Dictionary<int, int> LivesAndDrawLineNumber(int sizeOfHangmanAsciiArt)
        {
            int lineNumber = 0;
            Dictionary<int, int> livesAndDrawLineNumber = new Dictionary<int, int>();

            for (int userLives = 10; userLives >= 0; userLives -= 2)
            {
                livesAndDrawLineNumber.Add(userLives, lineNumber);
                int oddUserLives = userLives - 1;
                livesAndDrawLineNumber.Add(oddUserLives, lineNumber);
                lineNumber += sizeOfHangmanAsciiArt;
            }
            return livesAndDrawLineNumber;
        }
    }
}


