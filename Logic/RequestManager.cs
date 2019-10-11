using System;
using System.Collections.Generic;
using System.Text;
using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;

namespace MssqlMonitorLib.Logic
{
    public class RequestManager : ManagerBase
    {
        /// <summary>
        /// create instance pass dal to base layer
        /// </summary>
        /// <param name="_dal">new instance of dal object</param>
        public RequestManager(DAL _dal) : base(_dal, Tables.MASTER_SYS_DM_EXEC_REQUESTS)
        {

        }

        /// <summary>
        /// retrun all known database requests
        /// </summary>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getRequests(string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_REQUESTS, string.Empty, orderBy);
            return fillTable(sql);
        }

        /// <summary>
        /// retrun all known database requests by where condition
        /// </summary>
        /// <param name="where">optional will be ignored if empty</param>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getRequests(string where, string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_REQUESTS, where, orderBy);
            return fillTable(sql);
        }


    }
}
