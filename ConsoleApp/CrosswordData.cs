using System.Collections.Immutable;

namespace ConsoleApp
{
    public struct CrosswordData
    {
        public ImmutableList<CrosswordWordData> Words { get; }
        
        public ImmutableList<CrosswordPlaceData> Places { get; }

        public CrosswordData(string wordsData, ImmutableList<string> places)
        {
            Words = CrosswordDataParser.ParseWords(wordsData);

            Places = CrosswordDataParser.ParsePlaces(places);
        }
    }
}