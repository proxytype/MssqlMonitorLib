using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;

namespace MssqlMonitorLib.Logic
{
    public class ConnectionManager : ManagerBase
    {
        /// <summary>
        /// create instance pass dal to base layer
        /// </summary>
        /// <param name="_dal">new instance of dal object</param>
        public ConnectionManager(DAL _dal) : base(_dal)
        {

        }

        /// <summary>
        /// retrun all known database connections
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DBresponse getConnections(string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_CONNECTIONS, string.Empty, orderBy);
            return fillTable(sql);
        }

        /// <summary>
        /// retrun all known database connections by where condition
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DBresponse getConnections(string where, string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_DM_EXEC_CONNECTIONS, where, orderBy);
            return fillTable(sql);
        }

    }
}
