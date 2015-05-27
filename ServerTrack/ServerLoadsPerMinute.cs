using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrack
{
    public class ServerLoadsPerMinute
    {
        public string serverName { get; set;}
        public double meanCPUByMinute { get; set; }
        public double meanMemByMinute { get; set; }
    }
}