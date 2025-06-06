using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolistnew
{
    class Queue
    {
        private SlinglyList list = new SlinglyList();

        public void Enqueue(Node task)
        {
         
            list.addItemToTail(task);
        }

        public void DequeueTail() 
        {
            list.deleteFirst();
        }

        public Node Peek()
        {
            return list.Head;
        }

        public void Display()
        {
            list.showList();
        }
    }
}
