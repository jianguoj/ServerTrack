using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrack
{
    public class ServerLoadsPerHour
    {
        public string serverName { get; set; }
        public double meanCPUByHour { get; set; }
        public double meanMemByHour { get; set; }
    }
}