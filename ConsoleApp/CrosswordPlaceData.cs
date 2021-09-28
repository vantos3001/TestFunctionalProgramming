namespace ConsoleApp
{
    public struct CrosswordPlaceData
    {
        public CrosswordDirection Direction { get; }
        public int XCoord { get; }
        public int YCoord { get; }
        public string WordPattern { get; }
        
        public CrosswordPlaceData(CrosswordDirection direction, int xCoord, int yCoord, string wordPattern)
        {
            Direction = direction;
            XCoord = xCoord;
            YCoord = yCoord;
            WordPattern = wordPattern;
        }
    }
}