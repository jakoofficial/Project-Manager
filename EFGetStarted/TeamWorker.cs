﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class TeamWorker
    {
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int WorkerId { get; set; }
        public Worker? Worker { get; set; }
    }
}
