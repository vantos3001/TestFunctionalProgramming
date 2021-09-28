using System;
using System.Collections.Immutable;

namespace ConsoleApp
{
    public struct CrosswordSolutionData
    {
        private ImmutableList<CrosswordSolutionWordData> Datas { get; }

        public CrosswordSolutionData(ImmutableList<CrosswordSolutionWordData> datas)
        {
            Datas = datas;
        }
            
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}