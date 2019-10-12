using System;
using System.Data;
using System.Data.SqlClient;

namespace MssqlMonitorLib.Utilities
{
    public class DAL
    {
        SqlConnection connection;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public DAL(string serverName, string user, string password)
        {
            connection = new SqlConnection("Data Source=" + serverName + ";User ID=" + user + ";Password=" + password);
            command.Connection = connection;
            adapter.SelectCommand = command;
        }

        public DBresponse fillAdapter(string sql)
        {
            DBresponse response = new DBresponse();
            DataTable temptable = new DataTable();

            try
            {
                command.CommandText = sql;
                adapter.Fill(temptable);
                temptable.TableName = "dd";
                response.table = temptable;
            }
            catch (Exception ex)
            {
                response.isValid = false;
                response.exception = ex.Message;
            }

            return response;
        }

        public DBresponse fillAdapter(string storedProcedure, SqlParameter[] param)
        {
            DBresponse response = new DBresponse();
            DataTable tbl = new DataTable();

            try
            {
                for (int index = 0; index <= param.Length - 1; index++)
                {
                    command.Parameters.Add(param[index]);
                }

                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                adapter.Fill(tbl);
                tbl.TableName = "dd";
                response.table = tbl;
            }
            catch (Exception ex)
            {
                response.isValid = false;
                response.exception = ex.Message;
            }
            finally
            {
                command.Parameters.Clear();
            }
            return response;
        }
    }

}
