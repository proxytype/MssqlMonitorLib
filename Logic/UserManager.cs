﻿using MssqlMonitorLib.Properties;
using MssqlMonitorLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MssqlMonitorLib.Logic
{
    public class UserManager : ManagerBase
    {
        /// <summary>
        /// create instance pass dal to base layer
        /// </summary>
        /// <param name="_dal">new instance of dal object</param>
        public UserManager(DAL _dal) : base(_dal, Tables.MASTER_SYS_SERVER_PRINCIPALS)
        {

        }

        /// <summary>
        /// retrun all known database users
        /// </summary>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getUsers(string orderBy)
        {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_SERVER_PRINCIPALS, string.Empty, orderBy);
            return fillTable(sql);
        }

        /// <summary>
        /// retrun all known database users by where condition
        /// </summary>
        /// <param name="where">optional will be ignored if empty</param>
        /// <param name="orderBy">optional will be ignored if empty</param>
        /// <returns></returns>
        public DBresponse getUsers(string where, string orderBy) {
            string sql = createQuery(Queries.QUERY_GENERIC_SELECT, Tables.MASTER_SYS_SERVER_PRINCIPALS, where, orderBy);
            return fillTable(sql);
         }
    }
}
