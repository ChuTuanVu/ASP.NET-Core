using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL.Helper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string _ConnectionString { get; set; }
        public SqlConnection sqlConnection { get; set; }

        public DatabaseHelper(IConfiguration configuration)
        {
            _ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public void SetConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public string OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(_ConnectionString);
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CloseConnection()
        {
            try
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ExecuteNonQuery(string strquery)
        {
            string msgError = string.Empty;
            try
            {
                OpenConnection();
                using var sqlCommand = new SqlCommand(strquery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                msgError = exception.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return msgError;
        }

        public object ExecuteScalar(string strquery, out string msgError)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (var sqlCommand = new SqlCommand(strquery, sqlConnection))
                {
                    result = sqlCommand.ExecuteScalar();
                }
                msgError = string.Empty;
            }
            catch (Exception ex)
            {
                msgError = ex.StackTrace;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public DataTable ExecuteQueryToDataTable(string strquery, out string msgError)
        {
            msgError = string.Empty;
            var result = new DataTable();
            try
            {
                using var sqlConnection = new SqlConnection(_ConnectionString);
                using var sqlDataAdapter = new SqlDataAdapter(strquery, sqlConnection);
                sqlDataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                msgError = ex.ToString();
                result = null;
            }

            return result;
        }

        #region Execute StoreProcedure

        public string ExecuteProcedure(string sprocedureName, params object[] paramObjects)
        {
            string result = string.Empty;
            try
            {
                using var sqlConnection = new SqlConnection(_ConnectionString);
                using var cmd = new SqlCommand(sprocedureName, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();

                int parameterInput = paramObjects.Length / 2;
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
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                result = exception.ToString();
            }
            return result;
        }
        public List<string> ExecuteScalarProcedure(List<ProcedureParameter> procedureParameters)
        {
            var msgErrors = new List<string>();
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                using SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = connection };

                for (int p = 0; p < procedureParameters.Count; p++)
                {
                    try
                    {
                        cmd.CommandText = procedureParameters[p].ProcedureName;
                        int parameterInput = procedureParameters[p].ProcedureParams == null ? 0 : (procedureParameters[p].ProcedureParams.Count) / 2;
                        int j = 0;

                        if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                            cmd.Parameters.Clear();

                        for (int i = 0; i < parameterInput; i++)
                        {
                            string paramName = Convert.ToString(procedureParameters[p].ProcedureParams[j++]);
                            object value = procedureParameters[p].ProcedureParams[j++];
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

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        msgErrors.Add(exception.StackTrace);
                    }
                }
            }
            return msgErrors;
        }

        public object ExecuteScalarProcedure(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            msgError = string.Empty;
            object result = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection.Open();
                cmd.Connection = connection;
                int parameterInput = (paramObjects.Length) / 2;
                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("jsonb"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else if (paramName.ToLower().Contains("json"))
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
            }
            catch (Exception exception)
            {
                result = null;
                msgError = exception.ToString();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public List<object> ExecuteScalarProcedure(out List<string> msgErrors, List<ProcedureParameter> procedureParameters)
        {
            msgErrors = new List<string>();
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                using SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = connection };

                for (int p = 0; p < procedureParameters.Count; p++)
                {
                    try
                    {
                        cmd.CommandText = procedureParameters[p].ProcedureName;
                        int parameterInput = procedureParameters[p].ProcedureParams == null ? 0 : (procedureParameters[p].ProcedureParams.Count) / 2;
                        int j = 0;

                        if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                            cmd.Parameters.Clear();

                        for (int i = 0; i < parameterInput; i++)
                        {
                            string paramName = Convert.ToString(procedureParameters[p].ProcedureParams[j++]);
                            object value = procedureParameters[p].ProcedureParams[j++];
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
                        result.Add(null);
                        msgErrors.Add(exception.StackTrace);
                    }
                }
            }
            return result;
        }

        public DataTable ExecuteProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            DataTable tb = new DataTable();
            SqlConnection connection;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection = new SqlConnection(_ConnectionString);
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
                msgError = string.Empty;
            }
            catch (Exception exception)
            {
                tb = null;
                msgError = exception.ToString();
            }
            return tb;
        }

        public DataSet ExecuteProcedureReturnDataset(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            DataSet tb = new DataSet();
            SqlConnection connection;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection = new SqlConnection(_ConnectionString);
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

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(tb);
                cmd.Dispose();
                ad.Dispose();
                connection.Dispose();
                msgError = string.Empty;
            }
            catch (Exception exception)
            {
                tb = null;
                msgError = exception.ToString();
            }

            return tb;
        }
        public string ExecuteProcedure(SqlConnection npgsqlConnection, string sprocedureName, params object[] paramObjects)
        {
            string result = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                if (npgsqlConnection.State != ConnectionState.Open)
                {
                    return "CONNECTION_NOT_OPENING";
                }

                cmd.Connection = npgsqlConnection;
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
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                result = exception.ToString();
            }
            return result;
        }
        public List<Object> ReturnValuesFromExecuteProcedure(out string msgError, string sprocedureName, int outputParamCountNumber, params object[] paramObjects)
        {
            List<Object> result = new List<Object>();
            SqlConnection connection = new SqlConnection(_ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection.Open();
                cmd.Connection = connection;

                int numberOutput = outputParamCountNumber * 2;

                int parameterInput = (paramObjects.Length - numberOutput) / 2;

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

                for (int i = parameterInput * 2 - numberOutput; i < parameterInput * 2; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value) { Direction = ParameterDirection.Output, Size = 1000, IsNullable = true });
                }

                cmd.ExecuteNonQuery();

                foreach (SqlParameter sqlParameter in cmd.Parameters)
                    if (sqlParameter.Direction == ParameterDirection.Output)
                        result.Add(sqlParameter.Value);

                cmd.Dispose();
                msgError = string.Empty;
            }
            catch (Exception exception)
            {
                msgError = exception.ToString();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        #endregion
    }
}