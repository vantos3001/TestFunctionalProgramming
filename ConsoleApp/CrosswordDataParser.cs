using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleApp
{
    public static class CrosswordDataParser
    {
        public static ImmutableList<CrosswordWordData> ParseWords(string data)
        {
            var words = data.Split(" ").ToImmutableList();

            var wordDatas = words.Select(ParseWord);
            
            return wordDatas.ToImmutableList();
        }

        public static CrosswordWordData ParseWord(string word)
        {
            var wordPattern = ParseWordPattern(word);

            var data = new CrosswordWordData(word, wordPattern);

            return data;
        }

        public static string ParseWordPattern(string word)
        {
            var wordPattern = word.Select(DetectWordPatternLetter);

            return new string(wordPattern.ToArray());
        }

        public static char DetectWordPatternLetter(char letter)
        {
            var lowerLetter = Char.ToLower(letter);
            
            var vowels = new List<char>()
            {
                'a', 'ą', 'e', 'ę', 'ė', 'i', 'į', 'y', 'o', 'u', 'ų', 'ū'
            };

            var filteredVowels = vowels.Where(vowel => vowel == lowerLetter);

            return filteredVowels.Any() ? 'O' : 'X';
        }
        
        public static ImmutableList<CrosswordPlaceData> ParsePlaces(ImmutableList<string> datas)
        {
            var placeDatas = new List<CrosswordPlaceData>();
            
            datas.ForEach(data => placeDatas.Add(ParsePlace(data)));
            
            return placeDatas.ToImmutableList();
        }

        public static CrosswordPlaceData ParsePlace(string data)
        {
            var lines = data.Split(" ");
            
            var direction = ParseDirection(lines[0]);
            var xCoord = int.Parse(lines[1]);
            var yCoord = int.Parse(lines[2]);
            

            var placeData = new CrosswordPlaceData(direction, xCoord, yCoord, lines[3]);
            return placeData;
        }

        public static CrosswordDirection ParseDirection(string data)
        {
            if (data == "ltr")
            {
                return CrosswordDirection.LeftToRight;
            }

            if (data == "ttb")
            {
                return CrosswordDirection.TopToBottom;
            }

            //TODO: return null
            return CrosswordDirection.LeftToRight;
        }
    }
}