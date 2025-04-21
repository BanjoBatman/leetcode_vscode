namespace LeetCodeListNode
{
    /// <summary>
    /// Definition for singly-linked list.
    /// this is used in many of the problems in leetcode
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class ListNodes
    {
        /// <summary>
        /// removes the node at the nth from last position
        /// </summary>
        /// <param name="head">a linked list</param>
        /// <param name="n">the offset from the end to remove</param>
        /// <returns></returns>
        public ListNode? RemoveNthFromEnd(ListNode? head, int n)
        {
            ListNode? temp = head;
            ListNode? canary = head;

            if (head == null || head.next == null)
            {
                return null;
            }

            // send the canary first
            for (int i = n; i > 0; i--)
            {
                canary = canary?.next;
            }

            if (canary == null)
            {
                // remove the head
                return head.next;
            }

            // otherwise, move down the path until cannary is null, and remove that node
            while (canary != null)
            {
                canary = canary.next;
                if (canary != null)
                {
                    temp = temp?.next;
                }
            }

            // the canary is at the end, and the temp is pointing to the node prior to the one we want to remove
            // remove the next node by making it point to the one after it.
            if (temp != null)
            {
                temp.next = temp.next?.next;
            } // end of temp!=null

            return head;
        }

        /// <summary>
        /// merges two sorted listnodes into a single listnode
        /// </summary>
        /// <param name="list1">a sorted list</param>
        /// <param name="list2">a sorted list</param>
        /// <returns>a listnode containing all of the elements from both lists</returns>
        public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            ListNode? result = null;
            ListNode? temp = result;
            ListNode? right = list1;
            ListNode? left = list2;

            // initialize the result and temp
            if (right != null && left != null)
            {
                // both lists have elements
                // start the list with the smaller of the two
                if (right?.val < left?.val)
                {
                    result = right;
                    temp = result;
                    right = right?.next;
                }
                else
                {
                    result = left;
                    temp = result;
                    left = left?.next;
                }
            }
            else
            {
                // one, or both of the lists are null
                if (left == null && right == null)
                {
                    // both lists are null, the result is null
                    return null;
                }
                if (right != null)
                {
                    // the right list has elements, the left list is null;
                    // the right element is the result
                    return right;
                }
                if (left != null)
                {
                    // the left list has elements, the right list is null;
                    // the left element is the result
                    return left;
                }
            }

            while (right != null || left != null)
            {
                if (right != null && left != null)
                {
                    // both lists have elements
                    if (right.val < left.val)
                    {
                        // the right element is smaller, add it to the result
                        temp!.next = right;
                        temp = temp?.next;
                        right = right?.next;
                    }
                    else
                    {
                        // the left element is smaller, add it to the result
                        temp!.next = left;
                        temp = temp?.next;
                        left = left?.next;
                    }
                }
                else
                {
                    // one of the lists is null
                    if (right != null)
                    {
                        // the right list has elements, the left list is null;
                        // add the right elements to the result
                        temp!.next = right;
                        temp = temp?.next;
                        right = right?.next;
                        break;
                    }
                    if (left != null)
                    {
                        // the left list has elements, the right list is null;
                        // add the left elements to the result
                        temp!.next = left;
                        temp = temp?.next;
                        left = left?.next;
                        break;
                    }
                }
            }

            return result;
        } // end of MergeTwoLists
    }
}
