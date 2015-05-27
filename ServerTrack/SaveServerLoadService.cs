using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
//using System.ServiceModel.Web;
using System.Text;

namespace ServerTrack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SaveServerLoadService : ISaveServerLoadService
    {
        public void SaveServerData(string serverName, double cpu, double memory)
        {
            try
            {
                ServerLoads loads = ServerLoads.InstanceCreation();
                ServerLoad load = new ServerLoad();
                load.ServerName = serverName;
                load.CPULoad = cpu;
                load.MemoryLoad = memory;
 //               load.TimeStamp = DateTime.UtcNow;
                loads.Add(load);
            }
            catch (Exception ex)
            {
                // TODO: error logging
            }

        }

        // below: temp debugging code
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
