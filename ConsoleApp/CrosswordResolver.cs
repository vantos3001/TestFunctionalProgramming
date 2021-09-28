using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleApp
{
    public static class CrosswordResolver
    {
        public static ImmutableList<CrosswordSolutionData?> GetAllSolutions(CrosswordData crosswordData)
        {
            // var solutions = CheckNextSolutionStage(crosswordData.Words, crosswordData.Places, new List<CrosswordSolutionWordData>().ToImmutableList()).Where(data => data != null);

            var solutionOrders = GetSolutionOrders(crosswordData);

            var test = new List<CrosswordSolutionData?>().ToImmutableList();

            return test;
        }

        // public static ImmutableList<ImmutableList<int>> GetSolutionOrders(CrosswordData crosswordData)
        // {
        //     var orders = new List<int[]>();
        //
        //     var wordsCount = crosswordData.Words.Count;
        //     
        //     orders.Add(new int[wordsCount]);
        //
        //     var placeIndexesWasUsed = new List<int>();
        //
        //     for (int i = 0; i < wordsCount; i++)
        //     {
        //         var solutionCount = 0;
        //         var currentOrderCount = orders.Count;
        //
        //         for (int j = 0; j < wordsCount; j++)
        //         {
        //             if (placeIndexesWasUsed.Contains(j) || crosswordData.Words[i].WordPattern != crosswordData.Places[j].WordPattern) {continue;}
        //             
        //             solutionCount++;
        //             placeIndexesWasUsed.Add(j);
        //
        //             if (solutionCount == 1)
        //             {
        //                 foreach (var order in orders)
        //                 {
        //                     order[i] = j;
        //                 }
        //             }
        //             else
        //             {
        //
        //                 for (int k = 0; k < currentOrderCount; k++)
        //                 {
        //                     var newOrder = new int[wordsCount];
        //                     var orderForCopy = orders[k];
        //                     
        //                     orderForCopy.CopyTo(newOrder, 0);
        //                     newOrder[i] = j;
        //                     orders.Add(newOrder);
        //                 }
        //             }
        //         }
        //     }
        //
        //     var totalOrderList = new List<ImmutableList<int>>();
        //
        //     foreach (var order in orders)
        //     {
        //         var immutableOrder = order.ToImmutableList();
        //         
        //         totalOrderList.Add(immutableOrder);
        //     }
        //
        //     return totalOrderList.ToImmutableList();
        // }
        
        public static ImmutableList<ImmutableList<int>> GetSolutionOrders(CrosswordData crosswordData)
        {
            var orders = new List<int[]>();

            var wordsCount = crosswordData.Words.Count;
            
            orders.Add(new int[wordsCount]);

            var placeIndexesWasUsed = new List<int>();

            for (int placeIndex = 0; placeIndex < wordsCount; placeIndex++)
            {
                if (placeIndexesWasUsed.Contains(placeIndex))
                {
                    continue;
                }
                
                placeIndexesWasUsed.Add(placeIndex);
                
                var currentPlaceIndexes = new List<int>();
                currentPlaceIndexes.Add(placeIndex);

                for (int otherPlaceIndex = placeIndex + 1; otherPlaceIndex < wordsCount; otherPlaceIndex++)
                {
                    if (placeIndexesWasUsed.Contains(otherPlaceIndex))
                    {
                        continue;
                    }
                    
                    placeIndexesWasUsed.Add(otherPlaceIndex);
                    currentPlaceIndexes.Add(otherPlaceIndex);
                }

                if (currentPlaceIndexes.Count == 1)
                {
                    var wordIndex = crosswordData.Words.FindIndex(word => word.WordPattern == crosswordData.Places[placeIndex].WordPattern);
                    
                    for (int orderIndex = 0; orderIndex < orders.Count; orderIndex++)
                    {
                        orders[orderIndex][placeIndex] = wordIndex;
                    }
                    
                    continue;
                }

                var currentWordIndexes = new List<int>();

                for (int wordIndex = 0; wordIndex < wordsCount; wordIndex++)
                {
                    if (crosswordData.Places[placeIndex].WordPattern == crosswordData.Words[wordIndex].WordPattern)
                    {
                        currentWordIndexes.Add(wordIndex);
                    }
                }

                for (int i = 0; i < currentPlaceIndexes.Count; i++)
                {
                    for (int j = 0; j < currentWordIndexes.Count; j++)
                    {
                        //TODO: use combinatorics for creating new orders
                    }
                }
            }
            

            var totalOrderList = new List<ImmutableList<int>>();

            foreach (var order in orders)
            {
                var immutableOrder = order.ToImmutableList();
                
                totalOrderList.Add(immutableOrder);
            }

            return totalOrderList.ToImmutableList();
        }

        // public static ImmutableList<CrosswordSolutionData?> CheckNextSolutionStage(
        //     ImmutableList<CrosswordWordData> words, ImmutableList<CrosswordPlaceData> places, ImmutableList<CrosswordSolutionWordData> currentSolutionWords)
        // {
        //     if (words.IsEmpty)
        //     {
        //         var solutionList = new List<CrosswordSolutionData?> {new CrosswordSolutionData(currentSolutionWords)} ;
        //         return solutionList.ToImmutableList();
        //     }
        //
        //     var currentWord = words[0];
        //
        //     var suitablePlaces = places.FindAll(place => place.WordPattern == currentWord.WordPattern);
        //
        //     var list = new List<CrosswordSolutionData?>();
        //     var newWords = words.Remove(currentWord);
        //
        //     foreach (var currentPlace in suitablePlaces)
        //     {
        //         list.AddRange(CheckNextSolutionStage(newWords, places.Remove(currentPlace), currentSolutionWords.Add(new CrosswordSolutionWordData(currentWord.Word, currentPlace))));
        //     }
        //
        //     return list.ToImmutableList();
        // }
        
        
    }
}