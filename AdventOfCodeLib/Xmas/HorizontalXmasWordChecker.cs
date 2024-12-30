using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.XmasWordChecker;

namespace AdventOfCodeLib.Xmas
{
    public class HorizontalXmasWordChecker
    {
        public List<XmasWordCalculator> WordCalculators { get; set; }

        public int LineNumber { get; set; }

        public int IndexOnLine { get; set; }

        public int WidthOfFile { get; set; }

        public int LengthOfFile { get; set; }

        public int StartingIndexOnLine { get; set; }

        public HorizontalXmasWordChecker(int lengthOfFile, int widthOfFile)
        {
            WordCalculators = new List<XmasWordCalculator>();
            LineNumber = 0;
            WidthOfFile = widthOfFile;
            LengthOfFile = lengthOfFile;

            for (int i = 0; i < LengthOfFile; i++)
            {
                WordCalculators.Add(new XmasWordCalculator());
            }
        }

        public int AddToSequence(char currentChar)
        {

            if (IndexOnLine >= WidthOfFile)
            {
                LineNumber++;
                IndexOnLine = 0;
            }

            var result = WordCalculators[LineNumber].AddToSequence(currentChar);
            IndexOnLine++;
            return result;
        }
    }
}
