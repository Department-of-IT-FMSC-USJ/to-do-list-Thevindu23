using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolistnew
{
    class Node
    {
        private Task data; 
        private Node next; 

        internal Task Data { get => data; set => data = value; }
        internal Node Next { get => next; set => next = value; }

        // Constructor
        public Node(Task task)
        {
            Data = task;
            Next = null;
        }
    }
}
