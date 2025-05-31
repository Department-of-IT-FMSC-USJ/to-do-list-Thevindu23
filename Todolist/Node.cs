using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    class Node
    {
       private Task task;
       private Node next;

        internal Task Task { get => task; set => task = value; }
        internal Node Next { get => next; set => next = value; }

        public Node(Task task)
        {
            this.task = task;
            this.next = null;
        }
    }
}
