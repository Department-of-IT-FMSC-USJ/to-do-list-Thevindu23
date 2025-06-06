using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolistnew
{
    class Stack
    {
        SlinglyList list = new SlinglyList();

        public void Push(Node task)
        {
            list.addItemToHead(task);
        }

        public void Pop() 
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
