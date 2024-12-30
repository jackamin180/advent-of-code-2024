using System;
using System.Text;

namespace AdventOfCodeLib
{
    public class MultiplyMe : StupidMemory
    {
        public static Dictionary<char, char> ExpectedNextCharLookup { get; } = new Dictionary<char, char>
        {
            {'m', 'u'},
            {'u', 'l'},
            {'l', '('}
        };

        public MultiplyMe? NextLink { get; set; }

        public MultiplyMe? PrevLink { get; set; }

        public int DigitsInARowCount { get; set; }

        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public MultiplyMe()
        {
            DigitsInARowCount = 0;
            FirstNumber = 0;
            SecondNumber = 0;
            IsStopped = false;
        }

        public MultiplyMe AddToSequence(char currentChar)
        {
            if (IsStopped)
            {
                return this;
            }
            if (Sequence.Length == 0 && currentChar != 'm')
            {
                return Fail();
            }
            if (Sequence.Length == 0 && currentChar == 'm')
            {
                Sequence.Append(currentChar);
                return Continue();
            }


            var lastChar = Sequence[Sequence.Length - 1];
            var currentCharIsDigit = char.IsDigit(currentChar);
            var isLastCharADigit = char.IsDigit(lastChar);

            if (currentCharIsDigit)
            {
                DigitsInARowCount++;
            }
            if (DigitsInARowCount > 3)
            {
                return Fail();
            }

            if (currentChar == ',' && isLastCharADigit)
            {
                var firstNumberString = Sequence.ToString(Sequence.Length - DigitsInARowCount, DigitsInARowCount);
                FirstNumber = int.Parse(firstNumberString);
                Sequence.Append(currentChar);
                DigitsInARowCount = 0;
                return Continue();
            }

            if ((lastChar == '(' | lastChar == ',' | isLastCharADigit) && currentCharIsDigit)
            {
                Sequence.Append(currentChar);
                return Continue();
            }


            if (ExpectedNextCharLookup.TryGetValue(lastChar, out var currentExpectedCharValue) && currentExpectedCharValue == currentChar)
            {
                Sequence.Append(currentChar);
                DigitsInARowCount = 0;
                return Continue();
            }

            if (currentChar == ')' && isLastCharADigit)
            {
                var secondNumberString = Sequence.ToString(Sequence.Length - DigitsInARowCount, DigitsInARowCount);
                SecondNumber = int.Parse(secondNumberString);
                Sequence.Append(currentChar);
                DigitsInARowCount = 0;
                return Complete();
            }

            return Fail();
        }

        public void Stop()
        {
            IsStopped = true;
            Reset();
        }

        public void Start()
        {
            IsStopped = false;
        }
        
        public int Multiply()
        {
            return FirstNumber * SecondNumber;
        }

        public override MultiplyMe Fail()
        {
            Reset();
            return this;
        }

        public override MultiplyMe Complete()
        {
            var newMulti = new MultiplyMe();
            newMulti.PrevLink = this;
            this.NextLink = newMulti;
            return newMulti;
        }

        public override MultiplyMe Continue()
        {
            return this;
        }

        public override void Reset()
        {
            Sequence.Clear();
            DigitsInARowCount = 0;
            FirstNumber = 0;
            SecondNumber = 0;
        }

        public MultiplyMe GetLastLink()
        {
            var lastLink = this;

            while (lastLink.NextLink != null)
            {
                lastLink = lastLink.NextLink;
            }

            return lastLink;
        }
    }
}
