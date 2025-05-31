﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    class ToDO
    {
        public class TaskManager
        {
            private Node toDoHead;
            private Node inProgressHead;
            private Node completedHead;
            private Node completedTail;

            public TaskManager()
            {
                toDoHead = null;
                inProgressHead = null;
                completedHead = null;
                completedTail = null;
            }

            public void InsertToDoTask(Task task)
            {
                Node newNode = new Node(task);

                if (toDoHead == null || task.Date < toDoHead.Task.Date)
                {
                    newNode.Next = toDoHead;
                    toDoHead = newNode;
                    return;
                }

                Node current = toDoHead;
                while (current.Next != null && current.Next.Task.Date <= task.Date)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            public bool MoveToInProgress(int taskId)
            {
                Task taskToMove = RemoveFromToDo(taskId);
                if (taskToMove == null)
                {
                    Console.WriteLine($"Task with ID {taskId} not found in To-Do list.");
                    return false;
                }

                taskToMove.Status = "In Progress";
                Node newNode = new Node(taskToMove);
                newNode.Next = inProgressHead;
                inProgressHead = newNode;

                Console.WriteLine($"Task '{taskToMove.TaskName}' moved to In Progress.");
                return true;
            }

            public bool CompleteTask()
            {
                if (inProgressHead == null)
                {
                    Console.WriteLine("No tasks in progress.");
                    return false;
                }

                Task taskToComplete = inProgressHead.Task;
                inProgressHead = inProgressHead.Next;

                taskToComplete.Status = "Completed";
                Node newNode = new Node(taskToComplete);

                if (completedHead == null)
                {
                    completedHead = newNode;
                    completedTail = newNode;
                }
                else
                {
                    completedTail.Next = newNode;
                    completedTail = newNode;
                }

                Console.WriteLine($"Task '{taskToComplete.TaskName}' completed.");
                return true;
            }

            private Task RemoveFromToDo(int taskId)
            {
                if (toDoHead == null) return null;

                if (toDoHead.Task.ID == taskId)
                {
                    Task task = toDoHead.Task;
                    toDoHead = toDoHead.Next;
                    return task;
                }

                Node current = toDoHead;
                while (current.Next != null && current.Next.Task.ID != taskId)
                {
                    current = current.Next;
                }

                if (current.Next != null)
                {
                    Task task = current.Next.Task;
                    current.Next = current.Next.Next;
                    return task;
                }

                return null;
            }

            public void DisplayToDoTasks()
            {
                Console.WriteLine("\n=== TO-DO TASKS ===");
                DisplayList(toDoHead);
            }

            public void DisplayInProgressTasks()
            {
                Console.WriteLine("\n=== IN-PROGRESS TASKS (Stack) ===");
                DisplayList(inProgressHead);
            }

            public void DisplayCompletedTasks()
            {
                Console.WriteLine("\n=== COMPLETED TASKS (Queue) ===");
                DisplayList(completedHead);
            }

            private void DisplayList(Node head)
            {
                if (head == null)
                {
                    Console.WriteLine("No tasks.");
                    return;
                }

                Node current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Task.ToString());
                    current = current.Next;
                }
            }
            public bool HasToDoTasks()
            {
                return toDoHead != null;
            }

            public bool HasInProgressTasks()
            {
                return inProgressHead != null;
            }
        }
    }
}
