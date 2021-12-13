using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Connect
{
    public partial class DBContext: IDBContext
    {
        public string DB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        //public string StrConnection { get; set; }
        public SqlConnection sqlConnection { get; set; }
        public SqlTransaction sqlTransaction { get; set; }
        public DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            DataTable tb = new DataTable();
            SqlConnection connection;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection = new SqlConnection(DB());
                cmd.Connection = connection;

                int parameterInput = (paramObjects.Length) / 2;

                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]).Trim();
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(tb);
                cmd.Dispose();
                ad.Dispose();
                connection.Dispose();
                msgError = "";
            }
            catch (Exception exception)
            {
                tb = null;
                msgError = exception.ToString();
            }
            return tb;
        }
        public List<object> ExecuteScalarSProcedureWithTransaction(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos)
        {
            msgErrors = new List<string>();
            bool isSuccess = true;
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(DB()))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;

                        for (int p = 0; p < storeParameterInfos.Count; p++)
                        {
                            try
                            {
                                cmd.CommandText = storeParameterInfos[p].StoreProcedureName;
                                int parameterInput = storeParameterInfos[p].StoreProcedureParams == null ? 0 : (storeParameterInfos[p].StoreProcedureParams.Count) / 2;
                                int j = 0;

                                if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                                    cmd.Parameters.Clear();

                                for (int i = 0; i < parameterInput; i++)
                                {
                                    string paramName = Convert.ToString(storeParameterInfos[p].StoreProcedureParams[j++]);
                                    object value = storeParameterInfos[p].StoreProcedureParams[j++];
                                    if (paramName.ToLower().Contains("json"))
                                    {
                                        cmd.Parameters.Add(new SqlParameter()
                                        {
                                            ParameterName = paramName,
                                            Value = value ?? DBNull.Value,
                                            SqlDbType = SqlDbType.NVarChar
                                        });
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                                    }
                                }

                                var rresult = cmd.ExecuteScalar();
                                result.Add(rresult);
                            }
                            catch (Exception exception)
                            {
                                isSuccess = false;
                                result.Add(null);
                                msgErrors.Add(exception.StackTrace);
                            }
                        }
                    }
                    if (isSuccess)
                        transaction.Commit();
                    else
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return result;
        }
        public object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            msgError = "";
            object result = null;
            using (SqlConnection connection = new SqlConnection(DB()))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sprocedureName;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;

                        int parameterInput = (paramObjects.Length) / 2;
                        int j = 0;
                        for (int i = 0; i < parameterInput; i++)
                        {
                            string paramName = Convert.ToString(paramObjects[j++]);
                            object value = paramObjects[j++];
                            if (paramName.ToLower().Contains("json"))
                            {
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = paramName,
                                    Value = value ?? DBNull.Value,
                                    SqlDbType = SqlDbType.NVarChar
                                });
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                            }
                        }

                        result = cmd.ExecuteScalar();
                        cmd.Dispose();
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {

                        result = null;
                        msgError = exception.ToString();
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return result;
        }


    }
}
