using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib
{
    public class ShouldIStart : StupidMemory
    {
        public static Dictionary<char, char> ExpectedNextCharLookup { get; } = new Dictionary<char, char>
        {
            {'d', 'o'},
            {'o', '('},
            {'(', ')'}
        };

        public MultiplyMe MemoryToChange { get; set; }

        public ShouldIStart(MultiplyMe memToChange)
        {
            MemoryToChange = memToChange;
        }

        public ShouldIStart AddToSequence(char currentChar)
        {
            if (Sequence.Length == 0 && currentChar != 'd')
            {
                return Fail();
            }
            if (Sequence.Length == 0 && currentChar == 'd')
            {
                Sequence.Append(currentChar);
                return Continue();
            }
            var lastChar = Sequence[Sequence.Length - 1];

            if (lastChar == '(' && currentChar == ')')
            {
                return Complete();
            }
            
            if (ExpectedNextCharLookup.TryGetValue(lastChar, out var currentExpectedCharValue) && currentExpectedCharValue == currentChar)
            {
                Sequence.Append(currentChar);
                return Continue();
            }

            return Fail();
        }

        public override ShouldIStart Fail()
        {
            Reset();
            return this;
        }

        public override ShouldIStart Complete()
        {
            MemoryToChange = MemoryToChange.GetLastLink();
            MemoryToChange.Start();
            Reset();
            return this;
        }

        public override ShouldIStart Continue()
        {
            return this;
        }

        public override void Reset()
        {
            Sequence.Clear();
        }
    }
}
