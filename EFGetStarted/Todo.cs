using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Todo() { }
        public Todo(int todoId, string name, bool isCompleted)
        {
            TodoId = todoId;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
