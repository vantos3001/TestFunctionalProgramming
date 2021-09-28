using System;

namespace ConsoleApp
{
    public struct CrosswordSolutionWordData
    {
        public string Word { get; }
        public CrosswordPlaceData PlaceData { get; }

        public CrosswordSolutionWordData(string word, CrosswordPlaceData placeData)
        {
            Word = word;
            PlaceData = placeData;
        }
    }
}