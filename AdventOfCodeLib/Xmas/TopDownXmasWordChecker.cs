using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Xmas;

namespace AdventOfCodeLib.XmasWordChecker
{
    public class TopDownXmasWordChecker: VerticalXmasWordChecker
    {
        public TopDownXmasWordChecker(int lengthOfFile, int widthOfFile): 
            base(lengthOfFile, widthOfFile, 0)
        {
        }

        public int AddToSequence(char currentChar)
        {
            return base.AddToSequence(currentChar, 0, base.WidthOfFile);
        }
    }
}
