using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrack
{
    public class ServerLoad
    {
        public string ServerName { get;  set; }
        public double CPULoad { get;  set; }
        public double MemoryLoad { get;  set; }
//        public DateTime TimeStamp { get;  set; }  //each server calls every minutes
    }
}