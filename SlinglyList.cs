using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolistnew
{
    class SlinglyList

    {
     
            private Node head;
            private Node tail;

            internal Node Head { get => head; set => head = value; }
            internal Node Tail { get => tail; set => tail = value; }

            public SlinglyList()
            {
                head = null;
                tail = null;
            }

            public void addItemToHead(Node item)
            {
                if (head == null)
                {
                    head = item;
                    head.Next = tail;
                }
                else
                {
                    item.Next = head;
                    head = item;
                }
            }

       
            public void addItemToTail(Node item)
            {
                if (head == null)
                {
                    head = item;
                    head.Next = tail;
                }
                else
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    item.Next = tail;
                    current.Next = item;

                }
            }

            public void addItemAtPosition(Node item, Task searchItem)
            {
                if (head == null)
                {
                    head = item;
                    head.Next = tail;
                }
                else
                {
                    Node current = head;
                    while (current != null && current.Data != searchItem)
                    {
                        current = current.Next;
                    }

                    if (current == null)
                    {
                        return; 
                    }

             
                    item.Next = current.Next;
                    current.Next = item;
                }
            }

            public Node searchNode(int searchItem)
            {
                if (head == null)
                {
                    return null;
                }

                Node current = head;
                while (current != null && current.Data.Id != searchItem)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    return null; 
                }
                return current;

            }

        public void deleteNodeAt(int searchItem)
        {
            if (head == null)
            {
                return;
            }

            Node current = head;
            Node prevCurrent = null;

            while (current != null && current.Data.Id != searchItem)
            {
                prevCurrent = current;
                current = current.Next;
            }

            if (current == null)
            {
                return; // Item not found
            }

            if (current == head)
            {
                head = head.Next; // Delete head
            }
            else
            {
                prevCurrent.Next = current.Next; // Delete middle or end
            }
        }


        public void deleteLast()
            {
                if (head == null)
                {
                    return;
                }

                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current = null;
            }

            public void deleteFirst()
            {
                if (head == null)
                {
                    return;
                }
                head = head.Next;
            }

            public void showList()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty");
                    return;
                }

                Node current = head;
                while (current != null)
                {
                    Console.Write(current.Data + " -> ");
                    current = current.Next;
                }
                Console.WriteLine("null");
            }
        }
    }

