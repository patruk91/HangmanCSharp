namespace HangmanCSharp.view
{
    public class Validator
    {
        public bool IsInputEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}