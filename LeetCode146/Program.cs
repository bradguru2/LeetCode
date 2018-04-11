using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode146
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            LRUCache cache=null;
            List<KeyValuePair<string, KeyValuePair<int, int?>>> execution = 
                new List<KeyValuePair<string, KeyValuePair<int, int?>>> 
                { 
                //["LRUCache","put","put","get","put","get","put","get","get","get"]
                //[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
                    new KeyValuePair<string, KeyValuePair<int, int?>>("LRUCache",
                        new KeyValuePair<int, int?>(2, null)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("put",
                        new KeyValuePair<int, int?>(1, 1)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("put",
                        new KeyValuePair<int, int?>(2, 2)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("get",
                        new KeyValuePair<int, int?>(1, null)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("put",
                        new KeyValuePair<int, int?>(3, 3)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("get",
                        new KeyValuePair<int, int?>(2, null)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("put",
                        new KeyValuePair<int, int?>(4, 4)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("get",
                        new KeyValuePair<int, int?>(1, null)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("get",
                        new KeyValuePair<int, int?>(3, null)),
                    new KeyValuePair<string, KeyValuePair<int, int?>>("get",
                        new KeyValuePair<int, int?>(4, null))
                };

            StringBuilder instructionHeader = new StringBuilder();
            StringBuilder instructions = new StringBuilder();
            StringBuilder instructionResults = new StringBuilder();

            instructionHeader.Append("[");
            instructions.Append("[");
            instructionResults.Append("[");

            List<BenchMark> benchMarks = new List<BenchMark>();

            foreach (var item in execution)
            {
                switch (item.Key)
                {
                    case "LRUCache":
                        benchMarks.Add(new BenchMark(() => cache = new LRUCache((int)item.Value.Key)));
                        benchMarks[benchMarks.Count - 1].ExecuteAction();
                        instructionHeader.Append(",LRUCache");
                        instructions.Append(",");
                        instructions.Append(item.Value.Key);
                        instructionResults.Append(",null");
                        break;
                    case "put":
                        instructionHeader.Append(",put");
                        instructions.Append(",[");
                        instructions.Append(item.Value.Key);
                        instructions.Append(",");
                        instructions.Append(item.Value.Value);
                        instructions.Append("]");
                        benchMarks.Add(new BenchMark(() => cache.Put(item.Value.Key, item.Value.Value.Value)));
                        benchMarks[benchMarks.Count - 1].ExecuteAction();
                        instructionResults.Append(",null");
                        break;
                    case "get":
                        instructionHeader.Append(",get");
                        instructions.Append(",[");
                        instructions.Append(item.Value.Key);
                        instructions.Append("]");
                        instructionResults.Append(",");
                        double result = double.MaxValue;
                        benchMarks.Add(new BenchMark(() => result=cache.Get(item.Value.Key)));
                        benchMarks[benchMarks.Count - 1].ExecuteAction();
                        instructionResults.Append(result);
                        break;
                }
            }
            DateTime endTime = DateTime.Now;

            instructionHeader.Append("]");
            instructions.Append("]");
            instructionResults.Append("]");

            Console.WriteLine(instructionHeader.Replace("[,","["));
            Console.WriteLine(instructions.Replace("[,","["));
            Console.WriteLine(string.Format("\nResults:\n{0}", instructionResults.Replace("[,","[")));
            Console.WriteLine(string.Format("\nExecuted in {0} milliseconds", benchMarks.Sum((item)=>item.TotalMilliseconds)));
		}
	}
}
