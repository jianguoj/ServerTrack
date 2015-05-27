using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrack
{
    public class ServerLoads {
        private static int count = 0;
        public int Count { get{return count;}  }
        private ServerLoads() {}
        private volatile static ServerLoads ServerLoadsObject;
        List<ServerLoad> serverLoads = new List<ServerLoad>();
        public static ServerLoads InstanceCreation()
        {
            if(ServerLoadsObject == null)
            {
                ServerLoadsObject = new ServerLoads();
            }
            return ServerLoadsObject;
        }

        public void Add(ServerLoad aLoad) 
        {
            try
            {
                serverLoads.Add(aLoad);
                ServerLoads.count += 1;
            }
            catch (Exception ex) { }
        }

        public ServerLoad item(int theIndex)
        {
            if (theIndex < serverLoads.Count)
            {
                return serverLoads[theIndex];
            }
            else
            {
                return null;
            }
        }

        public int Delete(int size)
        {
            int status = 0; // Ok
            try
            {
                if (serverLoads.Count >= size)
                    serverLoads.RemoveRange(serverLoads.Count, size);
            }
            catch (Exception ex)
            {
                status = ex.HResult; // get the exception code for further processing.
            }
            return status;
        }

    }
}