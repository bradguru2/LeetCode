using System;

namespace LeetCode24
{
	public class ListNode
	{
		public int val;
		public ListNode next;

		public ListNode (int x)
		{
			val = x;
		}
	}

	public class Solution
	{
		public ListNode SwapPairs (ListNode head)
		{

			if (head != null && head.next != null) {
				ListNode tmpNode = head.next;    
				ListNode tmpHead = head;//1
				ListNode newHead = null;

				head = tmpNode;//2
				tmpHead.next = tmpNode.next;//1->3
				head.next = tmpHead;//2->1

				while (tmpHead != null && tmpHead.next != null) {
					newHead = tmpHead.next.next; //4
					tmpNode = tmpHead.next; //3

					if (newHead != null) {
						tmpHead.next = newHead; //1->4
						tmpNode.next = newHead.next;//3->?
						newHead.next = tmpNode; //4->3
					}

					tmpHead = tmpNode;//3
				}
			}

			return head;
		}
	}
}

