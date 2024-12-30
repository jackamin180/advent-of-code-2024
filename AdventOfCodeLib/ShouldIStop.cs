using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib
{
    public class ShouldIStop : StupidMemory
    {
        public static Dictionary<char, char> ExpectedNextCharLookup { get; } = new Dictionary<char, char>
        {
            {'d', 'o'},
            {'o', 'n'},
            {'n', '\''},
            {'\'', 't'},
            {'t', '('},
            {'(', ')'}
        };
        public MultiplyMe MemoryToChange { get; set; }

        public ShouldIStop(MultiplyMe memToChange)
        {
            MemoryToChange = memToChange;
        }

        public StupidMemory AddToSequence(char currentChar)
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

        public override StupidMemory Complete()
        {
            MemoryToChange = MemoryToChange.GetLastLink();
            MemoryToChange.Stop();
            Reset();
            return this;
        }

        public override StupidMemory Continue()
        {
            return this;
        }

        public override StupidMemory Fail()
        {
            Reset();
            return this;
        }

        public override void Reset()
        {
           Sequence.Clear();
        }
    }
}
