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

        public DBresponse executeQuery(string sql)
        {
            DBresponse response = new DBresponse();

            response.isValid = true;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.isValid = false;
                response.exception = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return response;

        }

        public DBresponse executeQuery(string storedProcedure, SqlParameter[] param)
        {

            DBresponse response = new DBresponse();
            response.isValid = true;

            try
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < param.Length; i++)
                {
                    command.Parameters.Add(param[i]);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.isValid = false;
                response.exception = ex.Message;
            }
            finally
            {
                connection.Close();
                command.Parameters.Clear();
            }

            return response;

        }


        public DBresponse executeScalar(string sql)
        {
            DBresponse response = new DBresponse();
            response.isValid = true;

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                connection.Open();
                response.data = command.ExecuteScalar();
            }
            catch (Exception ex)
            {

                response.isValid = false;
                response.exception = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return response;

        }

        public DBresponse executeScalar(string storedProcedure, SqlParameter[] param)
        {
            DBresponse response = new DBresponse();
            response.isValid = true;

            try
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < param.Length; i++)
                {
                    command.Parameters.Add(param[i]);
                }

                connection.Open();
                response.data = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                response.isValid = false;
                response.exception = ex.Message;
            }
            finally
            {
                connection.Close();
                command.Parameters.Clear();
            }

            return response;
        }

        public DBresponse fillAdapter(string sql)
        {
            DBresponse response = new DBresponse();
            response.isValid = true;

            command.CommandText = sql;
            DataTable temptable = new DataTable();
            try
            {
                adapter.Fill(temptable);
                temptable.TableName = "dd";
                response.data = temptable;
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
            response.isValid = true;

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
                response.data = tbl;
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
