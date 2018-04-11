using System;

namespace LeetCode146
{
    public class BenchMark
    {
        private readonly Action action;
        private DateTime startTime;
        private DateTime endTime;

        public BenchMark(Action benchmarkAction)
        {
            action = benchmarkAction;
        }

        public void ExecuteAction()
        {
            startTime = DateTime.Now;
            action();
            endTime = DateTime.Now;
        }

        public double TotalMilliseconds 
        {
            get{ return new TimeSpan(endTime.Ticks - startTime.Ticks).TotalMilliseconds; }
        }
    }
}

