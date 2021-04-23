using System;
using System.Collections.Generic;
using System.Text;

namespace Version1
{
   public  class nonPreemptivePriorityProcess
    {
        public int ProcessId { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int Priority { get; set; }
    }
}
