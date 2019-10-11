using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MssqlMonitorLib.Logic
{
    public class UserManager : ManagerBase
    {
        public UserManager(DAL _dal) : base(_dal)
        {

        }

        public DBresponse getUsers(string orderBy)
        {
            DBresponse response = dal.fillAdapter(Resources.DB_ALL_USERS + " " + orderBy);
            fillColumns(response);
            return response;
        }

        public DBresponse getUser(string sId)
        {
            return null;

        }

        public DBresponse getUser(int principalId)
        {
            return null;
        }

    }
}
