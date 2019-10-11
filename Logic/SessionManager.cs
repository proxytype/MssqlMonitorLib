using System;
using System.Collections.Generic;
using System.Text;
using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;

namespace MssqlMonitorLib.Logic
{
    public class SessionManager : ManagerBase
    {
        /// <summary>
        /// create instance pass dal to base layer
        /// </summary>
        /// <param name="_dal">new instance of dal object</param>
        public SessionManager(DAL _dal) : base(_dal)
        {

        }

        /// <summary>
        /// retrun all known database sessions
        /// </summary>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getSessions(string orderBy)
        {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_SESSIONS, string.Empty, orderBy);
            return fillTable(sql);
        }

        /// <summary>
        /// retrun all known database sessions by where condition
        /// </summary>
        /// <param name="where">optional will be ignored if empty</param>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getSessions(string where, string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_SESSIONS, where, orderBy);
            return fillTable(sql);
        }

    }
}
