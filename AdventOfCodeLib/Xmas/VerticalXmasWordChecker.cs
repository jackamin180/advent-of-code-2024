using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.XmasWordChecker;

namespace AdventOfCodeLib.Xmas
{

    public class VerticalXmasWordChecker
    {
        public List<XmasWordCalculator> WordCalculators { get; set; }

        public int LineNumber { get; set; }

        public int IndexOnLine { get; set; }

        public int WidthOfFile { get; set; }

        public int LengthOfFile { get; set; }

        public int StartingIndexOnLine { get; set; }

        public VerticalXmasWordChecker(int lengthOfFile, int widthOfFile, int startingIndexOnLine)
        {
            // I just got this equation from counting from the example.
            // We could remove -6 calculators by removing the first 3 and last 3 vertical lines from the count because they will at most be 3 characters in length
            // and will never have xmas in it because it's 4 characters in length. However I didn't want to spend more time on this.
            var howManyVerticalCalculatorsDoWeNeed = lengthOfFile - 1 + widthOfFile;
            WordCalculators = new List<XmasWordCalculator>();
            LineNumber = 0;
            IndexOnLine = startingIndexOnLine;
            WidthOfFile = widthOfFile;
            LengthOfFile = lengthOfFile;

            for (int i = 0; i < howManyVerticalCalculatorsDoWeNeed; i++)
            {
                WordCalculators.Add(new XmasWordCalculator());
            }
        }

        public int AddToSequence(char currentChar, int startingIndexOnLine, int lineResetIndex)
        {

            if (IndexOnLine >= lineResetIndex)
            {
                LineNumber++;
                IndexOnLine = startingIndexOnLine;
            }

            var result = WordCalculators[IndexOnLine].AddToSequence(currentChar);
            IndexOnLine++;
            return result;
        }
    }
}
