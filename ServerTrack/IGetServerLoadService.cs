using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerTrack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetServerLoadService" in both code and config file together.
    [ServiceContract]
    public interface IGetServerLoadService
    {

        [OperationContract]
        ServerLoad[] GetServerData(string serverName);

        [OperationContract]
        ServerLoadsPerMinute[] GetServerLoadsPerMinute(string serverName);

        [OperationContract]
        ServerLoadsPerHour[] GetServerLoadsPerHour(string serverName);

    }
}
