using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class Tasks
    {
        public Tasks() { }
        public Tasks(int tasksid, string name, List<Todo> todos)
        {
            Tasksid = tasksid;
            Name = name;
            Todos = todos;
        }

        public int Tasksid { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }

    }
}
