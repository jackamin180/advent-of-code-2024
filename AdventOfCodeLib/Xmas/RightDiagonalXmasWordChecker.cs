using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Xmas;

namespace AdventOfCodeLib.XmasWordChecker
{
    //So instead of calculating everyting diagonally, we're just going to shift each line over by one
    //from the previous line. Then we're just going to just check the vertical lines for xmas. 
    // Left Diagonal
    //M M M S X X M A S M
    //  M S A M X M S M S A
    //    A M X S X M A A M M
    //      M S A M A S M S M X
    //        X M A S A M X A M M
    //          X X A M M X X A M A
    //            S M S M S A S X S S
    //              S A X A M A S A A A
    //                M A M M M X M M M M
    //                  M X M X A X M A S X


    // Right Diagonal
    //                  M M M S X X M A S M     
    //                M S A M X M S M S A
    //               A M X S X M A A M M
    //            M S A M A S M S M X
    //          X M A S A M X A M M
    //        X X A M M X X A M A
    //      S M S M S A S X S S
    //    S A X A M A S A A A
    //  M A M M M X M M M M
    //M X M X A X M A S X
    public class RightDiagonalXmasWordChecker: VerticalXmasWordChecker
    {
        public RightDiagonalXmasWordChecker(int lengthOfFile, int widthOfFile): 
            base(lengthOfFile, widthOfFile, widthOfFile-1)
        {
        }

        public int AddToSequence(char currentChar)
        {
            return base.AddToSequence(currentChar, base.WidthOfFile - base.LineNumber - 2, 2 * base.WidthOfFile - 1 - base.LineNumber);
        }
    }
}
