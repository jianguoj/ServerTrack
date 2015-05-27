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
            for (int i = loads.Count; (LastHour > 0) && (i > 0); i-- )
            {
                anItem = loads.item(i);
                if( (anItem != null) && (serverName == anItem.ServerName) )
                {
                    mload[LastHour].serverName = anItem.ServerName;
                    mload[LastHour].meanCPUByMinute = anItem.CPULoad;
                    mload[LastHour].meanMemByMinute = anItem.MemoryLoad;
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
            for (int i = loads.Count; (LastDay > 0) && (i > 0); i = i - OffSet)
            {
                anItem = loads.item(i);
                int LastHour = HoursInDay;
                for (int j = i; (LastHour > 0) && (j > 0); j-- ){
                    if ( (anItem != null) && (serverName == anItem.ServerName) )
                    {
                        hLoad[i].meanCPUByHour += anItem.CPULoad;
                        hLoad[i].meanMemByHour += anItem.MemoryLoad;
                        LastHour--;
                    }
                }
                hLoad[i].serverName = serverName;

            }
            
            return hLoad;
        }

    }
}
