using System;

namespace LeetCode24
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ListNode node = new ListNode (1);
			node.next = new ListNode (2);
			node.next.next = new ListNode (3);
			node.next.next.next = new ListNode (4);

			ListNode tmpNode = node;

			Console.WriteLine ("List before processing:");

			while (tmpNode!=null) {
				Console.Write (tmpNode.val);
				Console.Write (" ");
				tmpNode = tmpNode.next;
			}

			Console.WriteLine ();

			Solution sol = new Solution ();
			node = sol.SwapPairs (node);
			tmpNode = node;

			Console.WriteLine ("List after processing:");

			while (tmpNode!=null) {
				Console.Write (tmpNode.val);
				Console.Write (" ");
				tmpNode = tmpNode.next;
			}
		}
	}
}
