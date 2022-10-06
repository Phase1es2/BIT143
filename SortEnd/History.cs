using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Helpdesk
{
    class History
    {
        
        public static LinkedList<string> nodeLinkedList = new LinkedList<string>();
        public static LinkedListNode<string> cur=new LinkedListNode<string>("");
        public static string LastValue = "";
        public static string FirstValue = "";
        public static bool flag = false;
        public void PrintAll()
        {
            Console.WriteLine(); // visual spacer
            Console.WriteLine("History:");
           
            if (nodeLinkedList.Count > 0)
            {
                if (cur.Value!="")
                {
                    Console.WriteLine("Previously visited pages:");
                    LinkedListNode<string> cur1 = cur;
                    if (flag)
                    {
                        Console.WriteLine(cur.Value);
                    }
                    while (cur1.Next != null)
                    {
                        Console.WriteLine(cur1.Next.Value);
                        cur1 = cur1.Next;
                    }
                    Console.WriteLine("Pages in your 'future':");
                    if (!flag)
                    {
                        Console.WriteLine(cur.Value);
                    }
                    LinkedListNode<string> cur2 = cur;
                    while (cur2.Previous != null)
                    {
                        Console.WriteLine(cur2.Previous.Value);
                        cur2 = cur2.Previous;
                    }
                }
                else
                {
                    Console.WriteLine("Previously visited pages:");
                    foreach (var item in nodeLinkedList)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Pages in your 'future':");
                }
            }
            else
            {
                Console.WriteLine("Previously visited pages:");
                Console.WriteLine("Pages in your 'future':");
            }
           
            
        }

        public void MoveBackwards()
        {
            if (LastValue != "")
            {
                cur = nodeLinkedList.Find(LastValue);
                if (cur.Next != null)
                {
                    if (flag)
                    {
                        flag = false;
                    }
                    LastValue = cur.Next.Value;
                }
                else
                {
                    flag = false;
                    LastValue = "";
                    FirstValue = cur.Value;
                }
            }
            else
            {
                Console.WriteLine("No Page Can Move!");
            }
        }

        public void MoveForwards()
        {
            if (FirstValue == "")
            {
                Console.WriteLine("No Page Can Move!");
                return;
            }
            if (LastValue != "")
            {
                cur = nodeLinkedList.Find(LastValue);
                if (cur.Previous != null)
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    LastValue = cur.Previous.Value;
                    cur = cur.Previous;
                }
                else
                {
                    if (LastValue == FirstValue)
                    {
                        FirstValue = "";
                    }
                }
            }
            else
            {
                cur = nodeLinkedList.Find(FirstValue);
                if (cur.Previous != null)
                {
                    FirstValue = cur.Previous.Value;
                    cur = cur.Previous;
                }
                else
                {
                    flag = true;
                    FirstValue = "";
                    LastValue = cur.Value;
                }
            }
        }

        public void VisitPage(string desc)
        {
            if (cur.Value != "")
            {
                
                LinkedListNode<string> cur2 = cur;
                ArrayList list=new ArrayList();
                while (cur2.Previous != null)
                {
                    list.Add(cur2.Previous);
                    cur2 = cur2.Previous;
                }

                foreach (LinkedListNode<string> item in list)
                {
                    nodeLinkedList.Remove(item);
                }
                if (!flag)
                {
                    nodeLinkedList.Remove(cur);
                }
                flag = false;
                cur = new LinkedListNode<string>("");
            }

            if (LastValue == "" && FirstValue == "")
            {
                LastValue = desc;
                FirstValue = desc;
            }
            else
            {
                LastValue = desc;
            }
            nodeLinkedList.AddFirst(desc);
        }
    }
}
