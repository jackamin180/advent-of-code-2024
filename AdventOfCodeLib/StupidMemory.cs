using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLib
{
    public abstract class StupidMemory
    {
        public StringBuilder Sequence { get; set; }
        
        public bool IsStopped { get; set; }

        public StupidMemory() 
        {
            Sequence = new StringBuilder();
            IsStopped = false;
        }

        public abstract StupidMemory Fail();

        public abstract StupidMemory Complete();

        public abstract StupidMemory Continue();

        public abstract void Reset();

        public void Stop()
        {
            IsStopped = true;
            Reset();
        }

        public void Start()
        {
            IsStopped = false;
        }
    }
}
