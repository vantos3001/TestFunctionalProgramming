namespace ConsoleApp
{
    public struct CrosswordWordData
    {
        public string Word { get; }
        public string WordPattern { get; }

        public CrosswordWordData(string word, string wordPattern)
        {
            Word = word;
            WordPattern = wordPattern;
        }
    }
}