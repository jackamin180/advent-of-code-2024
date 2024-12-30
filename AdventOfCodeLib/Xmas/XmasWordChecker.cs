using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.XmasWordChecker;

namespace AdventOfCodeLib.Xmas
{
    public class XmasWordChecker
    {
        public int WidthOfFile { get; set; }

        public int LengthOfFile { get; set; }

        public int XmasCount { get; set; }

        public TopDownXmasWordChecker TopDownXmasWordChecker { get; set; }
        
        public HorizontalXmasWordChecker LeftRightWordChecker { get; set; }

        public RightDiagonalXmasWordChecker RightDiagonalXmasWordChecker { get; set; }

        public LeftDiagonalXmasWordChecker LeftDiagonalXmasWordChecker { get; set; }


        public XmasWordChecker(int lengthOfFile, int widthOfFile) 
        {
            XmasCount = 0;
            WidthOfFile = widthOfFile;
            LengthOfFile = lengthOfFile;
            TopDownXmasWordChecker = new TopDownXmasWordChecker(lengthOfFile, widthOfFile);
            LeftRightWordChecker = new HorizontalXmasWordChecker(lengthOfFile, widthOfFile);
            RightDiagonalXmasWordChecker = new RightDiagonalXmasWordChecker(lengthOfFile, widthOfFile);
            LeftDiagonalXmasWordChecker = new LeftDiagonalXmasWordChecker(lengthOfFile, widthOfFile);
        }

        public int AddToSequence(char currentChar)
        {
            XmasCount += TopDownXmasWordChecker.AddToSequence(currentChar);
            XmasCount += LeftRightWordChecker.AddToSequence(currentChar);
            XmasCount += RightDiagonalXmasWordChecker.AddToSequence(currentChar);
            XmasCount += LeftDiagonalXmasWordChecker.AddToSequence(currentChar);
            return XmasCount;
        }

        public int GetXmasCount()
        {
            return XmasCount;
        }
    }
}
