using System;

namespace HangmanCSharp.view
{
    public class Reader
    {
        private readonly View _view;
        private readonly Validator _validator;

        public Reader(View view, Validator validator)
        {
            _view = view;
            _validator = validator;
        }

        private string GetInput()
        {
            return Console.ReadLine();
        }

        public string GetNotEmptyString()
        {
            string input = "";
            while (_validator.IsInputEmpty(input))
            {
                input = GetInput();
                if (_validator.IsInputEmpty(input))
                {
                    _view.DisplayError("Please, provide not empty data");
                }
            }
            return input;
        }
    }
}