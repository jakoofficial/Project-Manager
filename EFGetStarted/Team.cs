using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public List<TeamWorker> Workers { get; set; } = new();

        public Tasks? Current {get;set;}
        public List<Tasks>? TeamTasks{get;set;} = new();
    }
}
