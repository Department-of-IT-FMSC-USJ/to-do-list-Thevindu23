using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolistnew
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }

    class Task
    {

        private int id;
        private string name;
        private string description;
        private DateOnly date;
        private TaskStatus status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateOnly Date { get => date; set => date = value; }
        public TaskStatus Status { get => status; set => status = value; }


        public Task(int id, string name, string description, DateOnly date)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            status = TaskStatus.ToDo;
        }

        public override string? ToString()
        {
            return $"Task : {Name}, Due at: {Date}, Status: {Status}";
        }
    }

}
    

