using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerTrack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetServerLoadService" in both code and config file together.
    public class GetServerLoadService : IGetServerLoadService
    {
        int MinutesInHour = 60;
        int HoursInDay = 24;

        public ServerLoad[] GetServerData(string serverName)
        {
            ServerLoad[] load = new ServerLoad[1000];
            return load;
        }

        public ServerLoadsPerMinute[] GetServerLoadsPerMinute(string serverName)
        {
            int LastHour = MinutesInHour;
            ServerLoadsPerMinute[] mload = new ServerLoadsPerMinute[MinutesInHour];
            ServerLoads loads = ServerLoads.InstanceCreation();
            ServerLoad anItem;
            for (int i = loads.Count - 1; (LastHour > 0) && (i >= 0); i-- )
            {
                anItem = loads.item(i);
                if( (anItem != null) && (serverName == anItem.ServerName) )
                {
                    mload[MinutesInHour - LastHour] = new ServerLoadsPerMinute();
                    mload[MinutesInHour - LastHour].serverName = anItem.ServerName;
                    mload[MinutesInHour - LastHour].meanCPUByMinute = anItem.CPULoad;
                    mload[MinutesInHour - LastHour].meanMemByMinute = anItem.MemoryLoad;
                    LastHour--;
                }
            }
            return mload;
        }

        public ServerLoadsPerHour[] GetServerLoadsPerHour(string serverName)
        {
            int LastDay = HoursInDay;
            ServerLoadsPerHour[] hLoad = new ServerLoadsPerHour[HoursInDay];
            ServerLoadsPerMinute[] mload = new ServerLoadsPerMinute[MinutesInHour];
            ServerLoads loads = ServerLoads.InstanceCreation();
            ServerLoad anItem;
            int OffSet = 1;
            for (int i = loads.Count - 1; (LastDay > 0) && (i >= 0); i = i - OffSet)
            {
                
                int LastHour = MinutesInHour;
                double meanCPUByHour = 0;
                double meanMemByHour = 0;
                for (int j = i; (LastHour > 0) && (j >= 0); j-- ){

                    anItem = loads.item(j);
                    if ( (anItem != null) && (serverName == anItem.ServerName) )
                    {
                        meanCPUByHour += anItem.CPULoad;
                        meanMemByHour += anItem.MemoryLoad;
                        LastHour--;
                        OffSet++;
                    }

                }
                int SampleCount = MinutesInHour - LastHour;
                if ( SampleCount > 0 ) {
                    ServerLoadsPerHour serverLoadsPerHour = new ServerLoadsPerHour();
                    serverLoadsPerHour.serverName = serverName;
                    serverLoadsPerHour.meanCPUByHour = meanCPUByHour / SampleCount;
                    serverLoadsPerHour.meanMemByHour = meanMemByHour / SampleCount;
                    hLoad[HoursInDay - LastDay] = serverLoadsPerHour;
                }
                LastDay--;
            }
            
            return hLoad;
        }

    }
}
