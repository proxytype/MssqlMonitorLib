using System;
using System.Collections.Generic;
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
                response.table = fixDatatableType(temptable);
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
                response.table = fixDatatableType(tbl);
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

        private DataTable fixDatatableType(DataTable input) {

            List<DataColumn> overwriteColumnIndex = new List<DataColumn>();
            List<string> addedColumns = new List<string>();

            for (int i = 0; i < input.Columns.Count; i++)
            {
                if (input.Columns[i].DataType == typeof(byte[])) {

                    overwriteColumnIndex.Add(input.Columns[i]);

                    string newColumnName = input.Columns[i].ColumnName + "_str";

                    addedColumns.Add(newColumnName);

                    DataColumn dataColumn = new DataColumn(newColumnName, typeof(string));
                    input.Columns.Add(dataColumn);
                }
            }


            if (overwriteColumnIndex.Count != 0) {
                for (int z = 0; z < input.Rows.Count; z++)
                {
                    DataRow row = input.Rows[z];
                    for (int m = 0; m < overwriteColumnIndex.Count; m++)
                    {
                        if (row[overwriteColumnIndex[m]] != DBNull.Value) {
                            row[addedColumns[m]] = ByteArrayToHexString((byte[])row[overwriteColumnIndex[m]]);
                        }
                        
                    }
                }
            }

            return input;
        }

        private string ByteArrayToHexString(byte[] p)
        {
            byte b;
            char[] c = new char[p.Length * 2 + 2];
            c[0] = '0'; c[1] = 'x';
            for (int y = 0, x = 2; y < p.Length; ++y, ++x)
            {
                b = ((byte)(p[y] >> 4));
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(p[y] & 0xF));
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }
    }

}
