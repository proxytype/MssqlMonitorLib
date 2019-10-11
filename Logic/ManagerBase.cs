using MssqlMonitorLib.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MssqlMonitorLib.Logic
{
    public class ManagerBase
    {

        public string[] columns = null;
        protected DAL dal;

        public ManagerBase(DAL _dal)
        {
            dal = _dal;
        }

        protected DBresponse fillColumns(DBresponse response) {

            if (response.isValid && columns == null) {
                try
                {
                    DataTable table = (DataTable)response.data;
                    columns = new string[table.Columns.Count];
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        columns[i] = table.Columns[i].ColumnName;
                    }
                }
                catch (Exception ex)
                {
                    response.isValid = false;
                    response.exception = ex.ToString();
                }
            }

            return response;
        }

        protected DBresponse fillTable(string sql) {
            return fillColumns(dal.fillAdapter(sql));
        }

        protected string createQuery(string statement, string where, string orderBy) {
            string sql = statement + " " + where + " " + orderBy;
            sql = sql.Trim();
            return sql;
        }
    }
}
