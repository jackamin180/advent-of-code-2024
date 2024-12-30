using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib.XmasWordChecker
{
    public class XmasWordCalculator
    {
        public static Dictionary<char, char> ExpectedNextCharLookup { get; } = new Dictionary<char, char>
        {
            {'X', 'M'},
            {'M', 'A'}
        };

        public static Dictionary<char, char> ReverseExpectedNextCharLookup { get; } = new Dictionary<char, char>
        {
            {'S', 'A'},
            {'A', 'M'}
        };

        public StringBuilder Sequence { get; set; }
        
        public StringBuilder ReverseSequence { get; set; }

        public XmasWordCalculator()
        {
            Sequence = new StringBuilder();
            ReverseSequence = new StringBuilder();
        }

        public int AddToSequence(char currentChar)
        {
            return CheckSequential(currentChar) + CheckReverse(currentChar);
        }

        public int CheckSequential(char currentChar)
        {
            if (Sequence.Length == 0 && currentChar != 'X')
            {
                Sequence.Clear();
                return 0;
            }
            if (Sequence.Length != 0 && currentChar == 'X')
            {
                Sequence.Clear();
                Sequence.Append(currentChar);
                return 0;
            }
            if (Sequence.Length == 0 && currentChar == 'X')
            {
                Sequence.Append(currentChar);
                return 0;
            }

            var lastChar = Sequence[Sequence.Length - 1];

            if (lastChar == 'A' && currentChar == 'S')
            {
                Sequence.Clear();
                return 1;
            }

            if (ExpectedNextCharLookup.TryGetValue(lastChar, out var currentExpectedCharValue) && currentExpectedCharValue == currentChar)
            {
                Sequence.Append(currentChar);
                return 0;
            }

            Sequence.Clear();
            return 0;
        }

        public int CheckReverse(char currentChar)
        {
            if (ReverseSequence.Length == 0 && currentChar != 'S')
            {
                ReverseSequence.Clear();
                return 0;
            }
            if (ReverseSequence.Length != 0 && currentChar == 'S')
            {
                ReverseSequence.Clear();
                ReverseSequence.Append(currentChar);
                return 0;
            }

            if (ReverseSequence.Length == 0 && currentChar == 'S')
            {
                ReverseSequence.Append(currentChar);
                return 0;
            }

            var lastChar = ReverseSequence[ReverseSequence.Length - 1];

            if (lastChar == 'M' && currentChar == 'X')
            {
                ReverseSequence.Clear();
                return 1;
            }

            if (ReverseExpectedNextCharLookup.TryGetValue(lastChar, out var currentExpectedCharValue) && currentExpectedCharValue == currentChar)
            {
                ReverseSequence.Append(currentChar);
                return 0;
            }

            ReverseSequence.Clear();
            return 0;
        }
    }
}
