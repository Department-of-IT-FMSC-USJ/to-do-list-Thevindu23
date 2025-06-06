namespace Todolistnew
{
    internal class Program
    {
       static SlinglyList todolist = new SlinglyList();
       static Stack Inprogress = new Stack();
       static Queue Completed = new Queue();
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("---------todolist menu----------");
                Console.WriteLine("1.Add task");
                Console.WriteLine("2.View All Taska");
                Console.WriteLine("3.Move Task to inprogress");
                Console.WriteLine("4.Move Task to Comlpeted");
                Console.WriteLine("5.Exit");

                Console.WriteLine("Select your option to proceed :");
                string input = Console.ReadLine();

                switch (input) {
                        case "1":
                        AddTask();
                        break;
                        case "2":
                        ViewAllTask(); 
                        break;
                        case "3":
                        MoveToProgess();
                        break;
                        case "4":
                        MoveToComplete(); break;
                        case "5":
                        return;
                        default:
                        Console.WriteLine("Invalid option ");
                        break;



                    }
            }


            static void AddTask() {
                Console.WriteLine("Enter Task ID :");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Task Name :");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Task Description :");
                string descripton = Console.ReadLine();
                Console.WriteLine("Enter Task due date :");
                DateOnly date = DateOnly.Parse(Console.ReadLine());

                Task task = new Task(id, name, descripton, date);

                Node newNode = new Node(task);
                InsertTaskInOrder(newNode);

            }
            static void InsertTaskInOrder(Node node)
            
            {
                if (todolist.Head == null)
                {

                    todolist.Head = node;
                }
                else
                {

                    Node current = todolist.Head;
                    if (current.Data.Date > node.Data.Date) {
                        node.Next = current;
                        todolist.Head = node;
                        return;
                    }
                    while (current != null && current.Next.Data.Date >= node.Data.Date) {
                    
                        current = current.Next;
                    }
                    node.Next = current.Next;
                    current.Next = node;
                }
             
            }
            static void ViewAllTask() 
            { Console.WriteLine("----------------TODO Tasks-------------");
                todolist.showList();

                Console.WriteLine("--------------In Progress Tasks-----------");
                Inprogress.Display();

                Console.WriteLine("---------------Completed tasks---------------");
                Completed.Display(); 
            }
            static void MoveToProgess()
            {
                Console.WriteLine("Enter Task ID to move: ");
                int id = int.Parse(Console.ReadLine());

               Node SelectNode =  todolist.searchNode(id);

               

                SelectNode.Data.Status = TaskStatus.InProgress;

                Node newstackNode = new Node(SelectNode.Data);


                Inprogress.Push(newstackNode);
                todolist.deleteNodeAt(id);

            }
            static void MoveToComplete()
            {
                Node selectionNode = Inprogress.Peek();

                selectionNode.Data.Status = TaskStatus.Completed;
                Inprogress.Pop();

                Completed.Enqueue(selectionNode);
            }
        }
    }
}
