using System;
using System.Collections.Generic;
using System.Text;
using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;

namespace MssqlMonitorLib.Logic
{
    public class DatabaseManager : ManagerBase
    {
        /// <summary>
        /// create instance pass dal to base layer
        /// </summary>
        /// <param name="_dal">new instance of dal object</param>
        public DatabaseManager(DAL _dal) : base(_dal)
        {

        }

        /// <summary>
        /// retrun all known databases
        /// </summary>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getDatabases(string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DATABASES, string.Empty, orderBy);
            return fillTable(sql);
        }

        /// <summary>
        /// retrun all known databases by where condition
        /// </summary>
        /// <param name="where">optional will be ignored if empty</param>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getDatabases(string where, string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DATABASES, where, orderBy);
            return fillTable(sql);
        }
    }
}
