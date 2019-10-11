using MssqlMonitorLib.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MssqlMonitorLib.Logic
{
    public class ConnectionManager : ManagerBase
    {
        public ConnectionManager(DAL _dal) : base(_dal)
        {
        }

        public DBresponse getConnections(string orderBy) {
            return null;
        }

        public DBresponse getConnection(int sessionId) {
            return null;
        }

        public DBresponse getConnection(string sqlHandle) {
            return null;
        }


    }
}
